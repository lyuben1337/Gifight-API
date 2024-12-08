namespace Domain.Shared;

public interface IPage<T>
{
    public List<T> Items { get; }
    public int TotalCount { get; }
    public int CurrentPage { get; }
    public int PageSize { get; }
}