using System.Collections.Generic;

namespace Quadrinhos.Domain.Result
{
    public class ResultLogin
    {
        public bool Success { get; set; } = true;

        public string Data { get; set; }

        public List<string> Errors { get; set; }

        public string Message { get; set; }
        public string Token { get; set; }
    }
}
