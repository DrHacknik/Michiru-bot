using Discord;
using Discord.Commands;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Michiru
{
    public class SetLogMode : ModuleBase<SocketCommandContext>
    {
        private string cd = Directory.GetCurrentDirectory();

        private string time = DateTime.Now.ToString();

        [Command("SetLogMode")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task SetMode([Remainder] bool IMode)
        {
            //Not implemented

            /*string Message = "Command **!setlogmode** requested by <@" + Context.Message.Author.Id + ">" + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> with bool: *" + IMode + "*";*/

            string Message = "Command **!setlogmode** requested by " + Context.User.Username + ">" + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> This command is not implemented";
            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
            return;
        }
    }
}