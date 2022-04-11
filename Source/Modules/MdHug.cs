using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Michiru.Modules
{
    public class MdHug : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();
        private string[] Hugs;

        [Command("hug")]
        public async Task Kissed(SocketGuildUser MentionedUser)
        {
            Random rand;

            rand = new Random();
            Hugs = new string[] {
                "https://media1.tenor.com/images/506aa95bbb0a71351bcaa753eaa2a45c/tenor.gif?itemid=7552075",
                "https://thumbs.gfycat.com/WellgroomedVapidKitten-small.gif",
                "https://media.giphy.com/media/l2QDM9Jnim1YVILXa/giphy.gif",
                "https://i.imgur.com/nrdYNtL.gif",
                "https://media.tenor.com/images/ac5a0c47918dece5e69c1cc9fbb416a9/tenor.gif",
                "https://78.media.tumblr.com/18fdf4adcb5ad89f5469a91e860f80ba/tumblr_oltayyHynP1sy5k7wo1_500.gif",
                "http://gifimage.net/wp-content/uploads/2017/06/anime-hug-gif-16.gif",
                "https://78.media.tumblr.com/5dfb67d0a674fe5f81950478f5b2d4ed/tumblr_ofd4e2h8O81ub9qlao1_500.gif",
                "https://i.imgur.com/BPLqSJC.gif",
                "https://i.kym-cdn.com/photos/images/original/000/906/455/51f.gif",
                "https://media1.tenor.com/images/d0c2e7382742f1faf8fcb44db268615f/tenor.gif?itemid=5853736",
                "https://gifer.com/i/F1s1.gif",
                "http://i.imgur.com/pME21N2.gif"
            };

            await Context.Message.DeleteAsync();
            int randomIndex = rand.Next(Hugs.Length);
            string HugPost = Hugs[randomIndex];

            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithTitle(MentionedUser.Username + " you have been hugged by " + Context.User.Username);
            Embed.WithColor(new Color(236, 183, 4));
            Embed.WithImageUrl(HugPost);
            Embed.WithDescription("UwU Hug~");
            Embed.WithTimestamp(DateTime.UtcNow);
            await Context.Channel.SendMessageAsync(String.Empty, false, Embed.Build());

            string Message = "Command **!hug** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}