using System;
namespace ElectronColorCodeWebAPI.Exceptions
{
    public class APIException
    {
        public APIException(Exception ex)
        {
            // Exception is checking the name and not color so replacing it with Color
            Message = ex.Message.ToString().Replace("Name", "Color");
        }

        public string Message;
    }
}
