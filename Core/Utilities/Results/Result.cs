using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message; //hem mesaj hem de success bilgisi döndürmek istendiğinde
        }

        public Result(bool success)
        {
            Success = success; //sadece success bilgisi döndürmek istendiğinde
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
