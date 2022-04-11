using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Michiru.Modules
{
    public class MdWarn : ModuleBase<SocketCommandContext>
    {
        [Command("Warn")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Warn(SocketGuildUser WarnedUser, [Remainder] string WarningReason)
        {
            string CurrentTime = DateTime.Now.ToString();
            await Context.Message.DeleteAsync();

            string Imessage = WarnedUser.Mention + " | **Please read the rules on the channel #rules" + Environment.NewLine + "" +
                "You have been formally warned!**" + Environment.NewLine +
                "You were warned for: " + WarningReason;
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithColor(new Color(255, 0, 0));
            Embed.WithDescription(Imessage);
            await Context.Channel.SendMessageAsync(String.Empty, false, Embed.Build());

            string Message = "Command **!warn** requested by " + Context.User.Username + "> to <" + WarnedUser.Mention + ">" + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> with warning reason: *" + WarningReason + "*";
            EmbedBuilder EmbedLog = new EmbedBuilder();
            EmbedLog.WithColor(new Color(236, 183, 4));
            EmbedLog.WithDescription(Message);
            Embed.WithTimestamp(DateTime.UtcNow);

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}