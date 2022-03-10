using System.Collections.Generic;

namespace Quadrinhos.Domain.Result
{
    public class ResultLogin
    {
        public bool Success { get; set; } = true;

        public object Data { get; set; }

        public List<string> Errors { get; set; }

        public string Message { get; set; }
    }
}
