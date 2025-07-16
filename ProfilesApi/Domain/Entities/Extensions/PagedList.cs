namespace Domain.Entities.Extensions;

public sealed class PagedList<T> : List<T>
{
    public IEnumerable<T> Items { get; private set; }
    public int TotalCount { get; private set; }
    public int PageIndex { get; private set; }
    public int PageSize { get; private set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

    public PagedList(IEnumerable<T> items, int count, int pageIndex, int pageSize) : base(items)
    {
        Items = items;
        TotalCount = count;
        PageIndex = pageIndex;
        PageSize = pageSize;
    }

    public static PagedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
    {
        var count = source.Count();
        var items = source.Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

        return new PagedList<T>(items, count, pageIndex, pageSize);
    }
}
