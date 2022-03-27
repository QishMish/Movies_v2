using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Services.Exceptions;
using System;
using System.Net;

namespace MoviesClient
{
    public class ExceptionHandler : ProblemDetails
    {
        private HttpContext _context;
        private Exception _exception;

        public string Code { get; set; }
        public string TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId)) { }
                return (string)traceId;
                return null;
            }
            set { Extensions["TraceId"] = value; }
        }
        public ExceptionHandler(HttpContext context, Exception exception)
        {
            _context = context;
            _exception = exception;
            TraceId = context.TraceIdentifier;
            Code = "Something Went Wrong";
            Title = exception.Message;
            Instance = context.Request.Path;

            ExceptionHandlerHelper((dynamic)exception);
        }
        private void ExceptionHandlerHelper(MovieNotFoundException exception)
        {
            Status = (int)HttpStatusCode.NotFound;
            Code = exception.Message;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
        }
        private void ExceptionHandlerHelper(MovieAlreadyExistException exception)
        {
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Code = exception.Message;
            Title = exception.Message;
        }
        private void ExceptionHandlerHelper(InvalidDeleteException exception)
        {
            Status = (int)HttpStatusCode.NotFound;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Code = exception.Message;
            Title = exception.Message;
        }
    }
}
