using System.Data;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

namespace CrewGangSim.Modules
{
    public class Game
    {
        [Command("register")]

        public async Task Register()
        {

        }

        [Command("createturf")]

        public async Task CreateTurf(string name)
        {
            var messages = await Context.Channel.GetMessagesAsync(1).FlattenAsync();
            Turf turf = new Turf(Context.Message.Content.Replace(">>createturf ", ""), 30, 100, Convert.ToString(Context.User.Id));

            try
            {
                MySQLConnection mySqlConnection = new MySQLConnection();
                mySqlConnection.TurfInsert(turf);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var builder = new EmbedBuilder()
                .AddField("Creating a turf.", turf.ToString(), true);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
