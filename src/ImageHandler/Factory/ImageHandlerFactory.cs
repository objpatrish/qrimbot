using System;
using objpatrishbot.ImageHandler.Implementations;
using objpatrishbot.ImageHandler.Interface;

namespace objpatrishbot.ImageHandler.Factory
{
    /// <summary>
    /// Image handler factory. The idea behind this is that based off a configuration value, it will automatically create
    /// and instance of an Image Handler for the appropriate chat service. 
    /// </summary>
    /// <typeparam name="TAttachment">The type of attachment the service expects to return.</typeparam>
    static class ImageHandlerFactory
    {
        /// <summary>
        /// Creates an image handler.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IImageHandler Create(string connectionString)
        {
            return new DiscordImageHandler();
        }
    }
}
