namespace Maui.Infrastructure.Query
{
    public class QueryParameters
    {
        private const decimal _maxSize = 100;
        private decimal _size = 50;

        public decimal Page { get; set; } = 1;

        public decimal Size
        {
            get => _size;
            set => _size = Math.Min(_maxSize, value);
        }

        public string SortBy { get; set; } = "Id";

        public SortOrder SortOrder { get; set; } = SortOrder.Ascending;
    }

    public enum SortOrder
    {
        Ascending,
        Descending
    }
}