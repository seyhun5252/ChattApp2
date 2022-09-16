using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Result
{
    public class BCResponse
    {
        public string? Errors { get; set; }
        public object? value { get; set; }
    }
}
