using MediatR;
using NeatApiArchitecture.Presentation.Endpoints.Requests;

namespace NeatApiArchitecture.Presentation.Extensions;

public static class MediatREndpointExtensions
{
    public static WebApplication MediateGet<TRequest>(
        this WebApplication app,
        string path) 
        where TRequest : IHttpRequest
    {
        app.MapGet(path, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return app;
    }

    public static WebApplication MediatePost<TRequest>(
        this WebApplication app,
        string path)
        where TRequest : IHttpRequest
    {
        app.MapPost(path, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return app;
    }

    public static WebApplication MediateDelete<TRequest>(
        this WebApplication app,
        string path)
        where TRequest : IHttpRequest
    {
        app.MapDelete(path, async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return app;
    }
}