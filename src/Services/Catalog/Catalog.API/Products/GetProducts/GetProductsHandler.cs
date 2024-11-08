﻿using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    internal class GetProductQueryHandler(IDocumentSession session, ILogger<GetProductQueryHandler> logger)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation(nameof(GetProductQueryHandler), " called with query: " + query);
            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}