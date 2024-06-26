﻿using System.Diagnostics;
using System.Net;
using System.Text.Json;
using MeteorFlow.Fx.Exceptions;
using MeteorFlow.Infrastructure.Web.ExceptionHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MeteorFlow.Infrastructure.Web.Middleware;

public class GlobalExceptionHandlerMiddleware(
    RequestDelegate next,
    ILogger<GlobalExceptionHandlerMiddleware> logger,
    GlobalExceptionHandlerMiddlewareOptions options)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var request = context.Request;
            var response = context.Response;
            response.ContentType = "application/problem+json";

            var problemDetails = new ProblemDetails
            {
                Detail = GetErrorMessage(ex)
            };

            problemDetails.Extensions.Add("message", GetErrorMessage(ex));
            problemDetails.Extensions.Add("traceId", Activity.Current.GetTraceId());

            switch (ex)
            {
                case NotFoundException:
                    problemDetails.Status = (int)HttpStatusCode.NotFound;
                    problemDetails.Title = "Not Found";
                    problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
                    break;
                case ValidationException:
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Title = "Bad Request";
                    problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
                    break;
                case UnauthorizedAccessException:
                    response.Redirect($"/api/auth?returnUrl={request.Path}");
                    break;
                default:
                    logger.LogError(ex, "[{Ticks}-{ThreadId}]", DateTime.UtcNow.Ticks, Environment.CurrentManagedThreadId);
                    problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                    problemDetails.Title = "Internal Server Error";
                    problemDetails.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
                    break;
            }

            response.StatusCode = problemDetails.Status.Value;

            var result = JsonSerializer.Serialize(problemDetails);
            await response.WriteAsync(result);
        }
    }

    private string GetErrorMessage(Exception ex)
    {
        if (ex is ValidationException)
        {
            return ex.Message;
        }

        return options.DetailLevel switch
        {
            GlobalExceptionDetailLevel.None => "An internal exception has occurred.",
            GlobalExceptionDetailLevel.Message => ex.Message,
            GlobalExceptionDetailLevel.StackTrace => ex.StackTrace,
            GlobalExceptionDetailLevel.ToString => ex.ToString(),
            _ => "An internal exception has occurred.",
        };
    }
}

public class GlobalExceptionHandlerMiddlewareOptions
{
    public GlobalExceptionDetailLevel DetailLevel { get; set; }
}

public enum GlobalExceptionDetailLevel
{
    None,
    Message,
    StackTrace,
    ToString,
    Throw,
}
