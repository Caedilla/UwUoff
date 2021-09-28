using DSharpPlus;
using System.Configuration;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace UwUoff
{
    class Program
    {
        private const long myID = 887375280451223582;

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
                if (e.Message.Content.ToLower().StartsWith("test") && e.Message.Author.Id != myID)
                    await e.Message.RespondAsync("test response");

                bool isMe = e.Message.Author.Id == myID;
                var joyEmoji = DiscordEmoji.FromUnicode("😂");

                if (isMe)
                    await e.Message.CreateReactionAsync(joyEmoji);
            };
            
        
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
