using System.Collections.Generic;

namespace Quadrinhos.Domain.Result
{
    public class ListResultBase<TModel> where TModel : class
    {
        public bool Success { get; set; } = true;

        public int Count { get; set; }

        public object Data { get; set; }

        public List<string> Errors { get; set; }

        public string Message { get; set; }
    }
}
