using Microsoft.AspNetCore.Mvc;
using VideogamesApi.Models;

namespace VideogamesApi.Extensions
{
    public static class OperationResultExtensions
    {
        public static IActionResult ContentOrError(this IOperationResult operationResult)
        {
            return new ObjectResult(operationResult.Content) { StatusCode = (int)operationResult.Status };
        }

        public static IActionResult FileOrError(this IOperationResult operationResult)
        {
            if (!operationResult.Success) return new ObjectResult(operationResult.Content) { StatusCode = (int)operationResult.Status };
            return new FileContentResult(operationResult.FileContent, operationResult.FileContentType);
        }
    }
}
