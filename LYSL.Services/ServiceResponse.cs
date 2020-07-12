using System;
using System.Collections.Generic;
using System.Text;

namespace LYSL.Services
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Messsage { get; set; }
        public DateTime Time { get; set; }
        public T Data { get; set; }
    }
}
