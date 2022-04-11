using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace Michiru.Modules
{
    public class UserManagement : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("Kick")]
        [RequireBotPermission(GuildPermission.KickMembers)]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task KickUser(IGuildUser user, [Remainder] string reason)
        {
            await Context.Message.DeleteAsync();
            await user.KickAsync(reason);
            string Message = "Command **!kick** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + "Mentioned User: <" + user.Mention + ">" + " Kick reason: <" + reason + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }

        [Command("Ban")]
        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task BanUser(IGuildUser user, [Remainder] string reason)
        {
            await Context.Message.DeleteAsync();
            await user.Guild.AddBanAsync(user, 1, reason);
            string Message = "Command **!ban** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + "Mentioned User: <" + user.Mention + ">" + " Ban reason: <" + reason + ">";
            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }

        [Command("Mute")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.MuteMembers)]
        public async Task MuteUser(IGuildUser user, [Remainder] string reason)
        {
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync("This Command isn't ready yet.");
            string Message = "Command **!mute** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + "Mentioned User: <" + user.Mention + ">" + " Mute reason: <" + reason + ">";
            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}