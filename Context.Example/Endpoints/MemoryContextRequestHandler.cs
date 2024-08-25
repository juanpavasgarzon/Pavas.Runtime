using Context.Example.Constants;
using Context.Example.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pavas.Patterns.Context.Contracts;
using Pavas.Runtime.MemoryContext;

namespace Context.Example.Endpoints;

public static class MemoryContextRequestHandler
{
    public static void MapMemoryContextEndpoint(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup(Resources.MemoryContext);

        group.MapGet(string.Empty, HandleScoped)
            .WithTags(Tags.MemoryContext)
            .Produces<string>(StatusCodes.Status200OK, "application/json")
            .Produces<ProblemDetails>(StatusCodes.Status409Conflict, "application/problem+json");
    }

    private static Results<Ok<string>, Conflict<ProblemDetails>> HandleScoped(
        IContextProvider<MemoryContext> contextProvider
    )
    {
        try
        {
            var context = contextProvider.Context ?? throw new NotFoundException("MemoryContext Not Found");
            var key = Guid.NewGuid();

            var repository = context.GetRepository("application");
            repository!.Add(key, "Pavas");
            var value = repository.Get<Guid, string>(key)!;

            return TypedResults.Ok(value);
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