using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace Michiru.Modules
{
    public class MdInput : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();
        private string time = DateTime.Now.ToString();

        [Command("input")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task DoThatInput([Remainder] string IMessage)
        {
            await Context.Message.DeleteAsync();
            string Message = "Command **!input** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";
            await Context.Channel.SendMessageAsync(IMessage);

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }

        [Command("input-embed")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task InputEmdbed([Remainder] string IMessage)
        {
            await Context.Message.DeleteAsync();

            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithTitle("Message:");
            Embed.WithColor(new Color(236, 183, 4));
            Embed.WithDescription(IMessage);
            await Context.Channel.SendMessageAsync(String.Empty, false, Embed.Build());

            string Message = "Command **!input** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}