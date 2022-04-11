using Discord;
using Discord.Commands;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Michiru
{
    public class LogChannel : ModuleBase<SocketCommandContext>
    {
        private string cd = Directory.GetCurrentDirectory();

        private string time = DateTime.Now.ToString();

        [Command("SetLogChannel")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task SetBotLogChannel([Remainder] ulong IChannel)
        {
            await Context.Message.DeleteAsync();
            string Message = "Command **!setlogchannel** requested by " + Context.User.Username + ">" + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> with value: *" + IChannel + "*";
            Config.BotChannelId = IChannel;
            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
            return;
        }
    }
}