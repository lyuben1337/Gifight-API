using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Shared;

public class Page<T>(List<T> items, int totalCount, int currentPage, int pageSize)
    : IPage<T> where T : BaseEntity
{
    public List<T> Items { get; } = items;
    public int TotalCount { get; } = totalCount;
    public int CurrentPage { get; } = currentPage;
    public int PageSize { get; } = pageSize;

    public static async Task<Page<T>> CreateAsync(IQueryable<T> queryable, int page = 1, int pageSize = 0,
        CancellationToken cancellationToken = default)
    {
        if (page < 1 || pageSize < 0)
            throw new ArgumentOutOfRangeException(nameof(page),
                "Page must be greater than 0 and page size must be greater or equal than 0.");

        var totalCount = await queryable.CountAsync(cancellationToken);
        var size = pageSize > 0 ? pageSize : totalCount;


        var skip = (page - 1) * size;
        var take = queryable.OrderBy(t => t.Id).Skip(skip).Take(size);

        return new Page<T>(await take.ToListAsync(cancellationToken), totalCount, page, size);
    }
}