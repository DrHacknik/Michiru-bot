using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace Michiru
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();
        private string time = DateTime.Now.ToString();

        [Command("Help")]
        public async Task SendHelp()
        {
            await Context.Message.DeleteAsync();

            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithTitle("Bot Usage:");
            Embed.WithColor(new Color(236, 183, 4));
            Embed.WithImageUrl("https://github.com/DrHacknik/Michiru/blob/master/Splash_256.png?raw=true");
            Embed.WithDescription(Environment.NewLine +
                Environment.NewLine + "**/warn <@user>** : Warns the mentioned user." +
                Environment.NewLine + "**/hug <@user>** : Hugs the mentioned user." +
                Environment.NewLine + "**/kick <@user>** : Kicks the mentioned user." +
                Environment.NewLine + "**/ban <@user>** : Bans the mention user.Admins only." +
                Environment.NewLine + "**/about** : Shows the latest bot information." +
                Environment.NewLine + "**/input <value>** : Sends the remainder of the command message as its own message." +
                Environment.NewLine + "**/userinfo <@user> <image size: One value only, ex 64. If null, then 128 is used>** : Shows the mentioned user's information and avatar image." +
                Environment.NewLine + "**/delete <value>** : Deletes the specified amount of previous messages." + Environment.NewLine +
                "Dedicated Website: https://skyline-emu.github.io");
            Embed.WithTimestamp(DateTime.Now);
            await Context.Channel.SendMessageAsync(string.Empty, false, Embed.Build());

            string Message = "Command **/help** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}