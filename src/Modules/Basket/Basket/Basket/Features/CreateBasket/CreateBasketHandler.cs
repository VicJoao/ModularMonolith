using Basket.Basket.Dtos;


namespace Basket.Basket.Features.CreateBasket;

public record CreateBasketCommand(ShoppingCartDto ShoppingCart)
    : ICommand<CreateBasketResult>;

public record CreateBasketResult(Guid Id);

internal class CreateBasketHandler
{
}
