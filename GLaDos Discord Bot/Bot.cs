using System;
using System.Text;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Newtonsoft.Json;
using GLaDos_Discord_Bot.Commands;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace GLaDos_Discord_Bot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        //public SlashCommandsExtension Commands { get; private set; }

        public Bot(IServiceProvider services)
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json =  sr.ReadToEnd();

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            Console.WriteLine(configJson.Prefix);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                Intents = DiscordIntents.All,
                // LogLevel = LogLevel.Debug,
                // UseInternalLogHandler = true
            };

            Client = new DiscordClient(config);
            Client.Ready += OnClientReady;

            var commandsConfig = new SlashCommandsConfiguration
            {
                Services = services
            };

            var Commands = Client.UseSlashCommands(commandsConfig);



            Commands.RegisterCommands<TalkCommands>(797274273189330996);
            Commands.RegisterCommands<StatusCommands>(797274273189330996);
            Commands.RegisterCommands<TalkCommands>(1103126992355868784);
            Commands.RegisterCommands<StatusCommands>(1103126992355868784);
            Client.ConnectAsync();

            Client.GuildMemberAdded += AnnounceJoinedUser;
            Client.GuildMemberRemoved += AnnounceRemovedUser;
            Client.Ready += SetStatus;
        }

        private Task OnClientReady(DiscordClient client, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }

        public async Task SetStatus(DiscordClient sender, ReadyEventArgs e)
        {
            DiscordActivity activity = new DiscordActivity();
            activity.Name = "Portal 2";
            DiscordClient discord = Client;
            await discord.UpdateStatusAsync(activity);
        }

        public async Task AnnounceJoinedUser(DiscordClient sender, GuildMemberAddEventArgs current)
        {
            DiscordChannel channel = await Client.GetChannelAsync(1103126992901115965);

            DiscordEmbedBuilder response = new DiscordEmbedBuilder
            {
                Color = DiscordColor.SpringGreen,
                Title = $"*thanks for obliging to {current.Guild.Name}*",
                Description = $"**- please observe the rules**",
                Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                {
                    Url = current.Member.AvatarUrl
                },
                Author = new DiscordEmbedBuilder.EmbedAuthor
                {
                    Name = ">" + current.Member.DisplayName + "#" + current.Member.Discriminator
                },
                ImageUrl = "https://rare-gallery.com/uploads/posts/549465-futuristic-video.jpg",
                
                Footer = new DiscordEmbedBuilder.EmbedFooter
                {
                    Text = $"congrats on being our {current.Guild.MemberCount}th member!!!"
                }
                
            };

            var msg = await new DiscordMessageBuilder()
                .WithEmbed(response)
                .WithContent($"✩°｡* Greetings, {current.Member.Mention}!")
                .SendAsync(channel);

            var role = current.Guild.GetRole(1103814357692981278);
            await current.Member.GrantRoleAsync(role);
        }

        public async Task AnnounceRemovedUser(DiscordClient sender, GuildMemberRemoveEventArgs current)
        {
            DiscordChannel channel = await Client.GetChannelAsync(1103126992901115965);

            var msg = await new DiscordMessageBuilder()
                .WithContent($"Goodbye **{current.Member.Mention}** from **{current.Guild.Name}**, a bitter, unlikable loner who's passing shall not be mourned...")
                .SendAsync(channel);
        }

    }

}



