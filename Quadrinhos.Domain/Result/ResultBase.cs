using System.Collections.Generic;

namespace Quadrinhos.Domain.Result
{
    public class ResultBase<TModel> where TModel : class
    {
        public bool Success { get; set; } = true;

        public TModel Data { get; set; }

        public List<string> Errors { get; set; }

        public string Message { get; set; }
    }
}
