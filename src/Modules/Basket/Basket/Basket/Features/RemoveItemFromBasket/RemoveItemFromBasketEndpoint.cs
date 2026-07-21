
using Basket.Basket.Features.CreateBasket;

namespace Basket.Basket.Features.RemoveItemFromBasket;

public record RemoveItemFromBasketResponse(Guid Id);

public class RemoveItemFromBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{UsernAME}/item/{Id}",
            async ([FromRoute] string UserName, [FromRoute] Guid Id,ISender sender) =>
        {
            var result = await sender.Send(new RemoveItemFromBasketCommand(UserName, Id));

            var response = result.Adapt<RemoveItemFromBasketResponse>();

            return Results.Ok(response);
        })
            .Produces<CreateBasketResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Remove Item From Basket")
            .WithDescription("Remove Item From Basket");
    }
}
