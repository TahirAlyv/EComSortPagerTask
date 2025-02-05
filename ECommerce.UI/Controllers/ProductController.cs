using ECommerce.Business.Abstract;
using ECommerce.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int page=1, int category=0,bool sortorder=false, bool sortprice=false)
        {
            int pageSize = 10;
            var items=await _productService.GetAllCategoryAsync(category);



            items = sortprice ? items.OrderByDescending(p => p.UnitPrice).ToList() : items.OrderBy(p => p.UnitPrice).ToList();
            items = sortorder ? items.OrderBy(p => p.ProductName).ToList() : items;

            var products = items.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model= new ProductListViewModel
            {
                Products = products,
                PageCount =(int)Math.Ceiling(items.Count/(double)pageSize),
                PageSize=pageSize,
                CurrentPage=page,
                CurrentCategory=category,
                SortOrder= sortorder,
                SortPrice= sortprice

            };
            return View (model);
        }
    }
}
