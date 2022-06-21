using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
        public Response()
        {

        }
        public Response(string message,List<string> errors=null)
        {
            Succeeded = false;
            Message = message;
            Errors = errors??new List<string>();
        }

        public Response(T data,string message=null,List<string> errors=null)
        {
            Succeeded=true;
            Data = data;
            Message= message??string.Empty;
            Errors = errors ?? new List<string>();
        }
    }
}
