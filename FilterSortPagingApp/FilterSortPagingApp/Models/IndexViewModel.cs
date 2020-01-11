using System.Collections.Generic;

namespace FilterSortPagingApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Book> Books{ get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}