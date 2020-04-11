using System.Threading.Tasks;

namespace objpatrishbot.ChatClient
{
    public abstract class ChatClient
    {
        protected ChatClient(ChatClientConfig config)
        {
            this.config = config;
        }
        
        protected ChatClientConfig config;

        public abstract Task Run();
        public abstract Task Shutdown();
        public abstract void ConfigUpdateHandler(ChatClientConfig newConfig);
    }
}