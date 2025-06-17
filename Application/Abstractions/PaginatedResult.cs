namespace Application.Abstractions;

public class PaginatedResult<T>(List<T> items, int totalRecords, int pageNumber, int pageSize)
{
    public List<T> Items { get; } = items;
    public int TotalRecords { get; } = totalRecords;
    private int PageNumber { get; } = pageNumber;
    private int PageSize { get; } = pageSize;

    public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
}
