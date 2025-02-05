using ECommerce.Entities.Models;

namespace ECommerce.UI.Models
{
    public class ProductListViewModel
    {
        public List<Product>? Products { get; set; }
        public int PageCount { get;  set; }
        public int PageSize { get;  set; }
        public int CurrentPage { get;  set; }
        public int CurrentCategory { get;  set; }
        public bool SortPrice { get;  set; }=false;
        public bool SortOrder { get;  set; }=false;
    }
}
