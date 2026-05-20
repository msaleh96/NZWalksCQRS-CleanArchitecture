using Application.Common.Interfaces;
using Domain.Common.Results;
using MediatR;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviors;

public class CachingBehavior<TRequest, TResponse>(
    HybridCache cache,
    ILogger<CachingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly HybridCache _cache = cache;
    private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is not ICachedQuery cashedQuery)
        {
            return await next(cancellationToken);
        }

        _logger.LogInformation("Checking cache for {RequestName}", typeof(TRequest).Name);

        var result = await _cache.GetOrCreateAsync(
            key: cashedQuery.CacheKey,
            factory: async entry =>
            {
                _logger.LogInformation("Cache miss for {Key}", cashedQuery.CacheKey);

                var innerResult = await next(cancellationToken);

                _logger.LogInformation("Saving to cache");


                if (innerResult is IResult result && result.IsSuccess)
                {
                    return innerResult;
                }

                return default!;
            },
            options: new HybridCacheEntryOptions
            {
                Expiration = cashedQuery.Expiration
            },
            tags: cashedQuery.Tags,
            cancellationToken: cancellationToken
        );
        
        return result;
    }
}