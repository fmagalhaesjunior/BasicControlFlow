namespace BasicControlFlow.Application.Common
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages =>
            PageSize == 0 ? 0 : (int)Math.Ceiling((double)TotalItems / PageSize);
    }
}
