using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Michiru
{
    public class MdUserInfo : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();
        private string time = DateTime.Now.ToString();

        [Command("Userinfo")]
        public async Task SendImage(SocketGuildUser MentionedUser, ushort AvatarSize = 128)
        {
            try
            {
                EmbedBuilder Embed = new EmbedBuilder();
                Embed.WithTitle("User info for: " + MentionedUser.Username);
                Embed.WithColor(new Color(236, 183, 4));
                Embed.WithImageUrl(MentionedUser.GetAvatarUrl(ImageFormat.Auto, AvatarSize));
                Embed.WithDescription("**" + MentionedUser.Username + "**" + Environment.NewLine +
                    "**Account made:** " + MentionedUser.CreatedAt + Environment.NewLine +
                    "**Avatar ID:** " + MentionedUser.AvatarId + Environment.NewLine +
                    "**User ID:**  " + MentionedUser.Id + Environment.NewLine +
                    "**User is a bot?** " + MentionedUser.IsBot + Environment.NewLine +
                    "**User Status:** " + MentionedUser.Status + Environment.NewLine +
                    "**Requested Avatar Size (ushort value):** " + AvatarSize + Environment.NewLine +
                    "**Requested Avatar Size (in pixels):** " + AvatarSize + "x" + AvatarSize);
                Embed.WithTimestamp(DateTime.UtcNow);
                await Context.Channel.SendMessageAsync(String.Empty, false, Embed.Build());

                await Context.Message.DeleteAsync();

                await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", ""));
            }
            catch (Exception ex)
            {
                await Context.Message.DeleteAsync();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the 'await' operator to the result of the call.
                Context.Channel.SendMessageAsync("The value cannot be" + AvatarSize + "for the ushort `(AvatarSize).` Please use a value such as 64 or 128." + Environment.NewLine +
                    "**Example:** !userinfo @user 64" + Environment.NewLine + "**Exception:** " + Environment.NewLine + "```" + ex + "```");
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the 'await' operator to the result of the call.
                return;
            }
        }
    }
}