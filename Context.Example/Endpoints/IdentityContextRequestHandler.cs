using Context.Example.Constants;
using Context.Example.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pavas.Patterns.Context.Contracts;
using Pavas.Runtime.IdentityContext;

namespace Context.Example.Endpoints;

public static class IdentityContextRequestHandler
{
    public static void MapIdentityContextEndpoint(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup(Resources.IdentityContext);

        group.MapGet(string.Empty, HandleScoped)
            .RequireAuthorization()
            .WithTags(Tags.IdentityContext)
            .Produces<IdentityContext>(StatusCodes.Status200OK, "application/json")
            .Produces<ProblemDetails>(StatusCodes.Status409Conflict, "application/problem+json");
    }

    private static Results<Ok<IdentityContext>, Conflict<ProblemDetails>> HandleScoped(
        IContextProvider<IdentityContext> contextProvider
    )
    {
        try
        {
            var context = contextProvider.Context ?? throw new NotFoundException("IdentityContext Not Found");
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