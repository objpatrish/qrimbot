
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

using objpatrishbot.ChatClient;

namespace objpatrishbot
{
    class Program
    {
        public string defaultConfigPath = "config.ini";
        public Dictionary<string, Dictionary<string, string>> config;
        public List<ChatClient.ChatClient> clients;
        public static void Main(string[] args)
            => new Program().MainAsync(args).GetAwaiter().GetResult();

        public async Task MainAsync(string[] args)
        {
            Log($"Starting up objpatrishbot..");
            #region parsecfg

            string envConfigPath = Environment.GetEnvironmentVariable("CONFIG");
            LoadConfig(envConfigPath != null ? envConfigPath : defaultConfigPath);

            Dictionary<string, string> botcfg;
            Dictionary<string, string> commoncfg;
            string cfgClients = "";

            if (!config.TryGetValue("bot", out botcfg) || !botcfg.TryGetValue("clients", out cfgClients) || !config.TryGetValue("common", out commoncfg))
            {
                Log($"Fatal error, could not parse config, did you make a typo?");
                return;
            }

            #endregion


            #region initclients

            clients = new List<ChatClient.ChatClient>();

            foreach (string client in (cfgClients as string).Split(','))
            {
                Log($"initializing client {client}..");
                Dictionary<string, string> cl;
                if (!config.TryGetValue(client, out cl))
                {
                    Log($"could not load client config for {client}");
                    return;
                }

                ChatClientConfig ccl = new ChatClientConfig() { common = commoncfg, client = cl };

                switch (client)
                {
                    case "discord":
                        {
                            clients.Add(new ChatClient.Discord.DiscordClient(ccl));
                            break;
                        }
                    case "telegram":
                        {
                            Log("Telegram client not yet implemented. Skipping..");
                            break;
                        }
                    default:
                        break;
                }
            }

            #endregion


            foreach (ChatClient.ChatClient client in clients)
            {
                Log($"Starting up client {client.GetType().Name}");
                await client.Run();
            }
        }

        public void LoadConfig(string configPath)
        {
            Log($"Loading config from {Path.GetFullPath(configPath)}..");

            config = new Dictionary<string, Dictionary<string, string>>();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(configPath);

            foreach (SectionData section in data.Sections)
            {
                Dictionary<string, string> sectionDict = new Dictionary<string, string>();

                foreach (KeyData key in section.Keys)
                {
                    sectionDict.Add(key.KeyName, key.Value);
                }
                config.Add(section.SectionName, sectionDict);
            }
        }

        public static void Log(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow}: {message}");
        }
    }
}
