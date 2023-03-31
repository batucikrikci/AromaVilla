namespace Web.Models
{
    public class PaginationInfoViewModel
    {
        public int PageId { get; set; }
        public int TotalItems { get; set; }
        public int ItemsOnpage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)Constans.ITEMS_PER_AGA);
        public bool HasPrevious => PageId > 1;
        public bool HasNext => PageId < TotalItems;
        public int RangeStart => (PageId - 1) * Constans.ITEMS_PER_AGA + 1;
        public int RangeEnd => RangeStart + ItemsOnpage -1;
    }
}
