using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace VideogamesApi.Models
{
    public interface IOperationResult
    {
        object Content { get; }
        byte[] FileContent { get; }
        string FileContentType { get; }
        HttpStatusCode Status { get; }
        bool Success { get; }

    }
}
