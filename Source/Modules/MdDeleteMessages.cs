using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Michiru.Modules
{
    public class MdDeleteMessages : ModuleBase<SocketCommandContext>
    {
        [Command("Delete")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task DeleteMessages(int Number, [Remainder] string Reason = null)
        {
            var Messages = ((SocketTextChannel)Context.Channel).GetMessagesAsync(Number + 1).FlattenAsync();

            await ((SocketTextChannel)Context.Channel).DeleteMessagesAsync(Messages.Result, null);

            await Context.Message.DeleteAsync();

            string Message = "Command **!delete " + Number.ToString() + "** requested by " + Context.User.Username + ">" + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + Environment.NewLine +
                "with reason: *" + Reason + "*";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));

            const int Delay = 5000;
            var LastMsg = await Context.Channel.SendMessageAsync($"Delete completed. _This message will be deleted in {Delay / 1000} seconds._");

            await Task.Delay(Delay);

            await LastMsg.DeleteAsync();
        }
    }
}