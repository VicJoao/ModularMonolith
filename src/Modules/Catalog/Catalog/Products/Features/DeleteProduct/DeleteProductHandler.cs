using Catalog.Products.Features.UpdateProduct;

namespace Catalog.Products.Features.DeleteProduct;

public record DeleteProductCommand(Guid ProductId)
    : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSucess);

internal class DeleteProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products
           .FindAsync([command.ProductId], cancellationToken: cancellationToken);

        if (product == null)
        {
            throw new Exception($"Not found: Product {command.ProductId}");
        }

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}
