using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using objpatrishbot.Commands;
using objpatrishbot.Commands.Attributes;
using objpatrishbot.Infrastructure.Discord;

namespace objpatrishbot.Bot
{
    public class DiscordCommandHandler : IDiscordCommandHandler
    {
        // The work of LoadCommands and these lists will be hidden under a base generic class,
        // so when a Telegram one is made it will do the exact same thing but only grab its commands
        // without any further tweaking.
        private readonly ILogger<DiscordCommandHandler> _logger;
        private readonly List<IDiscordCommand> _commandInstances = new List<IDiscordCommand>();
        private readonly List<DiscordCommandAttribute> _commandAttributes = new List<DiscordCommandAttribute>();

        public DiscordCommandHandler(ILogger<DiscordCommandHandler> logger)
        {
            _logger = logger;
            _logger.LogInformation("Discord Command Handler loading commands...");
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            LoadCommands(); 
            _logger.LogInformation($"Discord Command Handler commands loaded successfully. Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Stop();
        }
        public void LoadCommands()
        {
            var commands = 
                from t in typeof(DiscordCommandAttribute).Assembly.GetTypes()
                let attribute = t.GetCustomAttribute(typeof(DiscordCommandAttribute), true)
                where attribute != null
                select new {Type = t, Attribute = attribute};

            foreach (var obj in commands)
            {
                _commandInstances.Add((IDiscordCommand)Activator.CreateInstance(obj.Type));
                _commandAttributes.Add(obj.Attribute as DiscordCommandAttribute);
            }
        }

        public async Task<bool> HandleMessageAsync(SocketMessage message, int prefixIndex)
        {
            for (int i = 0; i < _commandAttributes.Count; i++)
            {
                if (message.Content.ToLower().Contains(_commandAttributes[i].TriggerString))
                {
                    // handle options...
                   await message.Channel.SendMessageAsync(_commandInstances[i].GetReply(message));
                   return true;
                }
            }
            return false;
        }
    }
}