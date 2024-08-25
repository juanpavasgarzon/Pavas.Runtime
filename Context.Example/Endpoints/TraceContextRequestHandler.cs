using Context.Example.Constants;
using Context.Example.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pavas.Patterns.Context.Contracts;
using Pavas.Runtime.TraceContext;

namespace Context.Example.Endpoints;

public static class TraceContextRequestHandler
{
    public static void MapTraceContextEndpoint(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup(Resources.TraceContext);

        group.MapGet(string.Empty, HandleScoped)
            .WithTags(Tags.TraceContext)
            .Produces<TraceContext>(StatusCodes.Status200OK, "application/json")
            .Produces<ProblemDetails>(StatusCodes.Status409Conflict, "application/problem+json");
    }

    private static Results<Ok<TraceContext>, Conflict<ProblemDetails>> HandleScoped(
        IContextProvider<TraceContext> contextProvider
    )
    {
        try
        {
            var context = contextProvider.Context ?? throw new NotFoundException("TraceContext Not Found");
            return TypedResults.Ok(context);
        }
        catch (Exception e)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "Server error",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                Extensions = { ["message"] = e.Message },
                Status = StatusCodes.Status409Conflict
            };

            return TypedResults.Conflict(problemDetails);
        }
    }
}