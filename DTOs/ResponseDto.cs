using System;
namespace ApiProduct.DTOs
{
    // This will help us to format the response
    public class ResponseDto
    {
        public bool IsSucceed { get; set; }
        public object? Result { get; set; }
        public string DisplayMessage { get; set; } = "";
    }
}
