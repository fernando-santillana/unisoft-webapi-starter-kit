﻿using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.WebApi.Todo.Features.Creation.v1;
public static class TodoCreationEndpoint
{
    internal static RouteHandlerBuilder MapTodoItemCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", (TodoCreationCommand request, ISender mediator) => mediator.Send(request))
                        .WithName(nameof(TodoCreationEndpoint))
                        .WithOpenApi(operation => new(operation)
                        {
                            Summary = "creates a todo item",
                            Description = "creates a todo item"
                        })
                        .Produces<TodoCreationRepsonse>()
                        .MapToApiVersion(1.0);
    }
}
