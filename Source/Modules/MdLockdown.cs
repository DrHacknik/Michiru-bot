using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace Michiru.Modules
{
    public class Lockdown : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("Lockchannel")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(GuildPermission.ManageChannels)]
        public async Task LockChannel(IGuildChannel chn, [Remainder] string reason)
        {
            await Context.Message.DeleteAsync();
            string Message = "Command **!lockchannel** requested by " + Context.User.Mention + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> " + "Channel: " + chn.Id + " Lock reason: " + reason;
            string IMessage = "Command **!lockchannel** requested by " + Context.User.Mention + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> " + "Channel: " + chn.Id + " Lock reason: " + reason;

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }

        [Command("Unlockchannel")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(GuildPermission.ManageChannels)]
        public async Task UnlockChannel(IGuildChannel chn, [Remainder] string reason)
        {
            await Context.Message.DeleteAsync();
            string Message = "Command **!unlockchannel** requested by " + Context.User.Mention + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> " + "Channel: " + chn.Id + " Lock reason: " + reason;
            string IMessage = "Command **!unlockchannel** requested by " + Context.User.Mention + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> " + "Channel: " + chn.Id + " Lock reason: " + reason;

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
            await this.Context.Channel.SendMessageAsync(IMessage);
        }
    }
}