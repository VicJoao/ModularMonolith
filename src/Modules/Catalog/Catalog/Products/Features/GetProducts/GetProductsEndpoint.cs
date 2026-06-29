using Catalog.Products.Features.GetProducts;
using Catalog.Products.Features.UpdateProduct;
using Shared.Pagination;

namespace Catalog.Products.Features.GetProductss;

public record GetProductsRequest(PaginationRequest PaginationRequest);

public record GetProductsResponse(PaginationResult<ProductDto> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery(request));

            var response = result.Adapt<GetProductsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
 