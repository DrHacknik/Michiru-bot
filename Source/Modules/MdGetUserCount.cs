using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace Michiru
{
    public class MdGetUserCount : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();

        private string time = DateTime.Now.ToString();

#pragma warning disable CS0414 // The field 'MdGetUserCount.key_stat' is assigned but its value is never used
        private string key_stat = "ubuntu-x64";
#pragma warning restore CS0414 // The field 'MdGetUserCount.key_stat' is assigned but its value is never used

        [Command("getusercount")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task SendCount()
        {
            /*var count = Context.Guild.GetUsersAsync();
            var users = count.Count();*/
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithTitle("User count for ");
            Embed.WithColor(new Color(236, 183, 4));
            Embed.WithDescription("This server has {users} users.");
            Embed.WithTimestamp(DateTime.UtcNow);
            await Context.Channel.SendMessageAsync(String.Empty, false, Embed.Build());

            await Context.Message.DeleteAsync();

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", ""));
        }
    }
}