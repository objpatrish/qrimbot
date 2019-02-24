using System;
using System.Collections.Generic;
using System.Text;
using objpatrishbot.ImageHandler.Interface;

namespace objpatrishbot.ImageHandler.Factory
{
    class ImageHandlerFactory <TAttachment>
    {
        public IImageHandler<TAttachment> Create(string user, string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
