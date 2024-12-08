using Domain.Shared;

namespace Application.Shared.DTOs;

public record PageDto<T>(
    List<T> Items,
    int TotalCount,
    int CurrentPage,
    int PageSize
) : IPage<T>
{
    public static PageDto<TDestination> FromPage<TSource, TDestination>(IPage<TSource> page,
        Func<TSource, TDestination> mapFunction)
    {
        return new PageDto<TDestination>(
            page.Items.Select(mapFunction).ToList(),
            page.TotalCount,
            page.CurrentPage,
            page.PageSize
        );
    }
}