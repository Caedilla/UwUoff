using DSharpPlus;
using System.Configuration;
using System.Threading.Tasks;

namespace UwUoff
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = ConfigurationManager.AppSettings["DISCORD_KEY"],
                TokenType = TokenType.Bot
            });

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().StartsWith("test"))
                    await e.Message.RespondAsync("response");
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
