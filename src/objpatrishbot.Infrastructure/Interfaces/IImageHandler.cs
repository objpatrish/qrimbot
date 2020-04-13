using System.Threading.Tasks;

namespace objpatrishbot.Infrastructure.Interfaces
{
    // TAttachment is the return type of the attachment.
    public interface IImageHandler
    {
        /// <summary>
        /// Gets a random image of a specified user.
        /// </summary>
        /// <param name="user">User's name</param>
        /// <returns>An image of type TAttachment</returns>
        Task SendImage(string user, string channel);

    }
}
