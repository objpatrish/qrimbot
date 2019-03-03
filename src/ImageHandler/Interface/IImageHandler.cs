using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace objpatrishbot.ImageHandler.Interface
{
    // TAttachment is the return type of the attachment.
    interface IImageHandler
    {
        /// <summary>
        /// Gets a random image of a specified user.
        /// </summary>
        /// <param name="user">User's name</param>
        /// <returns>An image of type TAttachment</returns>
        Task SendImage(string user, string channel);

    }
}
