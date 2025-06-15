using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy_dotnet.Models
{
    public class ServiceResponse <T> // we use <T> to make it generic, so we can use it for any type
    {
        public T? Data { get; set; } // this is the data we want to return
        public bool Success { get; set; } = true; // this is the success status of the response
        public string Message { get; set; } = string.Empty; // this is the message we want to return
    }
    
}