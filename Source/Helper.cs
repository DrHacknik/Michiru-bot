using Discord;
using Discord.WebSocket;
using Michiru.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Michiru
{
    public static class Helper
    {
        public static DiscordSocketClient _DiscordClient;

        /*
         Basic Logging function
         */

        public static async Task LoggingAsync(LogMessage LogMsg)
        {
            string CurrentTime = DateTime.Now.ToString();

            Console.WriteLine(CurrentTime + " > " + Environment.NewLine + LogMsg.Message);

            //if (Config.LogWithoutStamp == false)
            //{
            //    SvcLog.Logged += "\r\n" + CurrentTime + " > " + Environment.NewLine + LogMsg.Message;
            //}
            //else if (Config.LogWithoutStamp == true)
            //{
            //    SvcLog.Logged += "\r\n" + Environment.NewLine + LogMsg.Message;
            //}
            //else if (Config.LogWithoutStamp == null)
            //{
            //    Console.WriteLine("\r\nValue cannot be null.");
            //    return;
            //}
            //else
            //{
            //    Console.WriteLine("\r\nValue is invalid, but not null.");
            //    return;
            //}

            SvcLog.DumpLog();
            string[] HTTPMethods = { "DELETE", "GET", "PATCH", "POST", "PUT" };

            if (!HTTPMethods.Contains(LogMsg.Message.Split(' ').First()))
            {
                EmbedBuilder Embed = new EmbedBuilder();
                Embed.WithTitle(LogMsg.Source + " > " + CurrentTime);
                Embed.WithColor(new Color(236, 183, 4));
                Embed.WithDescription(LogMsg.Message);

                const int Delay = 500;
                await Task.Delay(Delay);
                await ((IMessageChannel)_DiscordClient.GetChannel(Config.BotChannelId)).SendMessageAsync(String.Empty, false, Embed.Build());
            }
        }

        /*
         * Run Async function as Sync one.
         */

        public static void RunAsync(Task task)
        {
            task.ContinueWith(t => { }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}