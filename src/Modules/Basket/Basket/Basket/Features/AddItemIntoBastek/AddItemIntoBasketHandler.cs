namespace Basket.Basket.Features.AddItemIntoBastek;

public record AddItemIntoBasketCommand(string UserName, ShoppingCartItemDto shoppingCartItem)
    : ICommand<AddItemIntoBasketResult>;

public record AddItemIntoBasketResult(Guid Id);

public class AddItemIntoBasketCommandValidator : AbstractValidator<AddItemIntoBasketCommand>
{
    public AddItemIntoBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
        RuleFor(x => x.shoppingCartItem.ProductId).NotEmpty().WithMessage("ProductId is required");
        RuleFor(X => X.shoppingCartItem.Quantity).GreaterThan(0).WithMessage("Quantity is required");
    }
}
internal class AddItemIntoBasketHandler(BasketDbContext dbContext)
    : ICommandHandler<AddItemIntoBasketCommand, AddItemIntoBasketResult>
{
    public async Task<AddItemIntoBasketResult> Handle(AddItemIntoBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = await dbContext.shoppingCarts
            .Include(x => x.Items)
            .SingleOrDefaultAsync(x => x.UserName == command.UserName, cancellationToken);
    
        if (shoppingCart is null)
        {
            throw  new BasketNotFoundException(command.UserName);
        }

        shoppingCart.AddItem(
            command.shoppingCartItem.Id,
            command.shoppingCartItem.Quantity,
            command.shoppingCartItem.Color,
            command.shoppingCartItem.Price,
            command.shoppingCartItem.ProductName);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new AddItemIntoBasketResult(shoppingCart.Id);
    }
}
