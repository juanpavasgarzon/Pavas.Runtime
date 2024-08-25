using Context.Example.Constants;
using Context.Example.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pavas.Patterns.Context.Contracts;
using Pavas.Runtime.ApplicationContext;

namespace Context.Example.Endpoints;

public static class ApplicationContextRequestHandler
{
    public static void MapApplicationContextEndpoint(this IEndpointRouteBuilder endpoint)
    {
        var contextProvider = endpoint.ServiceProvider.GetRequiredService<IContextProvider<ApplicationContext>>();
        var applicationContext = contextProvider.Context;

        var group = endpoint.MapGroup($"{applicationContext!.BaseUrl}/{Resources.ApplicationContext}");

        group.MapGet(string.Empty, HandleScoped)
            .WithTags(Tags.ApplicationContext)
            .Produces<ApplicationContext>(StatusCodes.Status200OK, "application/json")
            .Produces<ProblemDetails>(StatusCodes.Status409Conflict, "application/problem+json");
    }

    private static Results<Ok<ApplicationContext>, Conflict<ProblemDetails>> HandleScoped(
        IContextProvider<ApplicationContext> contextProvider
    )
    {
        try
        {
            var context = contextProvider.Context ?? throw new NotFoundException("ApplicationContext Not Found");
            context.IncreaseRequestCount();
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