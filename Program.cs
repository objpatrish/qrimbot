using System;
using System.IO;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace objpatrishbot
{
    class Program
    {
        static ITelegramBotClient botClient;
        static bool isRunning = false;
        static string apitokenpath = ".apitoken";
        static string apitoken = "";
        static void Main(string[] args)
        {
            if (File.Exists(apitokenpath))
            {
                apitoken = File.ReadAllText(apitokenpath);
                Console.WriteLine($"api token loaded from disk: {apitoken}");
            }
            else
            {
                Console.Write("api token could not be loaded from disk. Please enter api token: ");
                apitoken = Console.ReadLine();
            }
            try
            {
                botClient = new TelegramBotClient(apitoken);
                var me = botClient.GetMeAsync().Result;
                Console.WriteLine($"Jag känner en bot.\n\tid: {me.Id} \n\tname: {me.FirstName}\n\tuser: {me.Username}.");
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Exception occured while initializing bot client\n\t {e.Message}");
                return;
            }
            
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            
            isRunning = botClient.IsReceiving;
            Thread.Sleep(int.MaxValue);

            
            while (isRunning)
            {
                if (Console.ReadLine() == "exit")
                {
                    Console.WriteLine("shutting down..");
                    botClient.StopReceiving();
                    return;
                }
                Thread.Sleep(2000);
            }
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"\tchat: {e.Message.Chat.Id}\n\tmsg: {e.Message.Text}");
                
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text:   "ack! msg:\n" + e.Message.Text
                );
            }
        }
    }
}
