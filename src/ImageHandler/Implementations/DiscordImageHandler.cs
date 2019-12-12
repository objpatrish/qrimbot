using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Discord;
using objpatrishbot.ChatClient.Implementation;
using objpatrishbot.ImageHandler.Interface;

namespace objpatrishbot.ImageHandler.Implementations
{
    class DiscordImageHandler: IImageHandler
    {
        public async Task SendImage(string user, string channel)
        {
            var qrimPics = Directory.GetFiles("").Where(file => !file.Contains(".mp3")).ToArray();
            var guild = DiscordClient.client.Guilds.Single(g => g.Name == "Obj. Patrish");
            var discordChannel = guild.TextChannels.Single(ch => ch.Name == channel);
            await discordChannel.SendFileAsync(qrimPics[new Random().Next(0, qrimPics.Length - 1)], "Sick nasty");
        }
    }
}
