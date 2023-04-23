using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrayLayer.DTOs
{
    public class ErrorDto
    {
        public List<string> Errors { get; private set; } = new List<string>();
        public ErrorDto(string error)
        {
            Errors.Add(error);
        }
        public ErrorDto(List<string> errors)
        {
            Errors = errors;
        }
    }
}
