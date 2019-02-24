using System;
using System.Collections.Generic;
using System.Text;

namespace objpatrishbot.ImageHandler.Interface
{
    // TAttachment is the return type of the attachment.
    interface IImageHandler <TAttachment>
    {
        /// <summary>
        /// Gets a random image of a specified user.
        /// </summary>
        /// <param name="user">User's name</param>
        /// <returns>An image of type TAttachment</returns>
        TAttachment GetImage(string user);

    }
}
