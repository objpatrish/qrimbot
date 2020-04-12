using System.Threading.Tasks;
using System.Collections.Generic;

namespace objpatrishbot.ChatClient
{
    public class ChatClient
    {
        protected List<ChatModule> modules;
        protected ChatClient(ChatClientConfig config)
        {
            this.config = config;
        }

        protected static string clientType = "base";

        protected ChatClientConfig config;

        protected bool InitModules() 
        {
            try
            {
                System.Type moduletype;
                foreach (string module in config.client["modules"].Split(','))
                {
                    switch (module)
                    {
                        case "admin":
                        {
                            moduletype = typeof(AdminModule);
                        }
                        case "badword":
                        {
                            moduletype = typeof(BadwordModule);
                        }
                        case "imagesearch":
                        {
                            moduletype = typeof(AdminModule);
                        }
                        case "qrimpics":
                        {
                            moduletype = typeof(QrimpicsModule);
                        }
                        
                        default:
                    }
                    modules.Add(new ChatModule<moduletype>());
                }
                return true;
            }
            catch (System.Exception e)
            {
                Program.Log($"Exception occured while initializing bot client modules for {clientType}\n\t {e.Message}");
                return false;
            }
        }


        public virtual Task Run() { return null; }
        public virtual Task Shutdown() { return null; }
        public virtual void ConfigUpdateHandler(ChatClientConfig newConfig) { return; }
    }
}