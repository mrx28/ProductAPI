using System;

namespace ProductsAPI.Exceptions
{
    public class NotFoundException :Exception
    {
        public NotFoundException(string mess):base(mess)
        {

        }
    }
}
