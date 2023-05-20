using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace GLaDos_Discord_Bot
{
	public class StatusCommands : ApplicationCommandModule
	{
        [SlashCommand("setactivity", "Sets activity of GLaDOS")]

        private async Task SetActivity(InteractionContext ctx, [Option("status", "Status to set")] string input)
        {
            if (ctx.User.Id == 788059890924912641)
            {
                DiscordActivity activity = new DiscordActivity();
                DiscordClient discord = ctx.Client;
                activity.Name = input;
                await discord.UpdateStatusAsync(activity);
                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Success! My status is now {input}."));
            }
            else
            {
                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("It didn't work :/"));
            }
        }
    }
}

