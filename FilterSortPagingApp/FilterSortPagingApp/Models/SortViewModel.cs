namespace FilterSortPagingApp.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; }     // значение для сортировки по имени
        public SortState PriceSort { get; }    // значение для сортировки по цене
        public SortState TypeSort { get; }     // значение для сортировки по типу
        public SortState Current { get; }      // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            TypeSort = sortOrder == SortState.TypeAsc ? SortState.TypeDesc : SortState.TypeAsc;
            Current = sortOrder;
        }
    }
}