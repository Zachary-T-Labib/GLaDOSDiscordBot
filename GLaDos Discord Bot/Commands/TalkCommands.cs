using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Net;
using DSharpPlus.SlashCommands;
using static System.Net.WebRequestMethods;

namespace GLaDos_Discord_Bot.Commands
{
    public class TalkCommands : ApplicationCommandModule
    {

        [SlashCommand("talk", "Amuse yourself (real)")]

        public async Task Talk(InteractionContext ctx)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);


            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"Unbelievable! You, {ctx.User.Username} , must be the pride of [Subject Hometown Here]."));
        }

        [SlashCommand("8Ball", "Ask the Aperature Science 8Ball™ a question and you shall recieve a 100% valid answer.")]

        public async Task Ball(InteractionContext ctx, [Option("Question", "Question to ask")] string input)
        {
            string[] ballResponses = { "absolutely not", "practically impossible", "no, just no", "try again lol", "idk up to u ig", "only god knows", "100% absolutely", "no denying it", "yes" };

            Random rnd = new Random();

            string result = ballResponses[rnd.Next(ballResponses.Length)];
            
            DiscordEmbedBuilder response = new DiscordEmbedBuilder
            {
                Color = DiscordColor.VeryDarkGray,
                Description = $":8ball: {result} ",
            };

            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            var msg = await new DiscordMessageBuilder()
                .WithEmbed(response)
                .WithReply(ctx.InteractionId, true)
                .SendAsync(ctx.Channel);

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($":grey_question: *{input}* :grey_question:"));

            //await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource);
            //await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent(" "));

        }

        [SlashCommand("CoinFlip", "Flip a Coin!!!")]

        public async Task Coin(InteractionContext ctx)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);
            Random rnd = new Random();

            int coin;
            coin = rnd.Next(1, 3);

            DiscordEmbedBuilder response;

            Console.WriteLine(coin);

            if (coin == 1)
            {
                response = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.VeryDarkGray,
                    Title = "Results are in!:",
                    Description = ":sparkles: Heads :sparkles:",
                    // ImageUrl = "https://commons.wikimedia.org/wiki/File:2006_Quarter_Proof.png",
                };

                var msg = await new DiscordMessageBuilder()
                    .WithEmbed(response)
                    .WithReply(ctx.InteractionId, true)
                    .SendAsync(ctx.Channel);
            } else if (coin == 2)
            {
                response = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.VeryDarkGray,
                    Description = ":sparkles: Tails :sparkles:",
                    Title = "Results are in!:",
                    // ImageUrl = "https://en.wikipedia.org/wiki/File:98_quarter_reverse.png",
                };

                var msg = await new DiscordMessageBuilder()
                    .WithEmbed(response)
                    .WithReply(ctx.InteractionId, true)
                    .SendAsync(ctx.Channel);
            }

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("*☆ﾟ°˖* ᕕ( ᐛ )ᕗ*☆ﾟ°˖*"));
        }

        [SlashCommand("ManualOverride", "Hands control over to your gud pal ;]")]

        public async Task MannualOverride(InteractionContext ctx, [Option("Text", "Text to manuallly state")] string input)
        {
            Console.WriteLine(ctx.Channel);

            if (ctx.User.Id == 788059890924912641)
            {
                await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

                var msg = await new DiscordMessageBuilder()
                    .WithContent(input)
                    .WithReply(ctx.InteractionId, true)
                    .SendAsync(ctx.Channel);

                await ctx.DeleteResponseAsync();
            } else
            {
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"nice try {ctx.User.Username} :P"));
            }
        }
        
        [SlashCommand("PrintLog", "Log a new 3D print event w/ multiple printers")]

        public async Task Log(InteractionContext ctx, [Option("printer1", "Current Status (ordered from left to right)")] string print1Input, [Option("printer2", "Current Status (ordered from left to right)")] string print2Input, [Option("printer3", "Current Status (ordered from left to right)")] string print3Input)
        {
            DateTime date = DateTime.Now;

            DiscordEmbedBuilder response = new DiscordEmbedBuilder
            {
                Color = DiscordColor.CornflowerBlue,
                Description = $"**Flashforge #1** ➜ `{print1Input}` \n **Flashforge #2** ➜ `{print2Input}` \n **Flashforge #3** ➜ `{print3Input}` ",
            };

            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            var msg = await new DiscordMessageBuilder()
                .WithEmbed(response)
                .WithReply(ctx.InteractionId, true)
                .SendAsync(ctx.Channel);

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($":loudspeaker: **Log**  ☆ﾟ°˖  Date & Time: `{date}`  ☆ﾟ°˖  User: `{ctx.User.Username}`" ));

            //await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource);
            //await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent(" "));

        }
        

    }
}
