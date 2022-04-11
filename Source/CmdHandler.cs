using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;
using System.Threading.Tasks;

namespace Michiru
{
    public class CommandHandler : ModuleBase<SocketCommandContext>
    {
        private DiscordSocketClient DiscordClient;
        private CommandService CmdService;

        public CommandHandler(DiscordSocketClient client)
        {
            DiscordClient = client;
            CmdService = new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Verbose, // Tell the logger to give Verbose debug information
                DefaultRunMode = RunMode.Async, // Force all commands to run async by default
                CaseSensitiveCommands = false // Ignore letter case when executing commands
            });

#pragma warning disable CS0411 // The type arguments for method 'CommandService.AddModuleAsync<T>(IServiceProvider)' cannot be inferred from the usage. Try specifying the type arguments explicitly.
            CmdService.AddModuleAsync(Assembly.GetEntryAssembly());
#pragma warning restore CS0411 // The type arguments for method 'CommandService.AddModuleAsync<T>(IServiceProvider)' cannot be inferred from the usage. Try specifying the type arguments explicitly.
            DiscordClient.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage SocketMsg)
        {
            SocketUserMessage UserMsg = (SocketUserMessage)SocketMsg;
            int ArgPos = 0;
            SocketCommandContext Context = new SocketCommandContext(DiscordClient, UserMsg);

            if (UserMsg == null) return;

            if (UserMsg.HasCharPrefix('/', ref ArgPos))
            {
#pragma warning disable CS1501 // No overload for method 'ExecuteAsync' takes 2 arguments
                var Result = await CmdService.ExecuteAsync(Context, ArgPos);
#pragma warning restore CS1501 // No overload for method 'ExecuteAsync' takes 2 arguments
                if (!Result.IsSuccess && Result.Error != CommandError.UnknownCommand)
                {
                    await Context.Message.DeleteAsync();

                    await Context.Channel.SendMessageAsync(Result.ErrorReason);

                    string ErrorMessage = "ERROR: The command requested was invalid or syntax was the incorrect";

                    await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", ErrorMessage));
                    await this.Context.Channel.SendMessageAsync(ErrorMessage);
                }
            }
        }
    }
}