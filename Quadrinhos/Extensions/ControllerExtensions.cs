using Microsoft.AspNetCore.Mvc;
using Quadrinhos.Domain.Result;
using System.Collections.Generic;
using System.Linq;

namespace Quadrinhos.Extensions
{
    public static class ControllerExtensions
    {
        public static List<string> GetModelStateErrors(this ControllerBase source)
        {
            var errors = new List<string>();
            foreach (var key in source.ModelState.Keys)
            {
                errors.AddRange(source.ModelState[key].Errors.ToList().Select(t => t.ErrorMessage).ToArray());
            }

            return errors;
        }

        public static IActionResult ValidateModelState<T>(this ControllerBase source, string message) where T : class
        {
            var result = new ResultBase<T>();

            if (!source.ModelState.IsValid)
            {
                result.Success = false;
                result.Message = message;
                result.Errors = source.GetModelStateErrors();

                return source.Ok(result);
            }

            return null;
        }
    }
}
