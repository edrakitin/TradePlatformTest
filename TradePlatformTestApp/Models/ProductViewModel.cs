using DataAccessLayer.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradePlatformTestApp.Models
{
    public class ProductViewModel
    {
        public List<Product> ProductList { get; set; } = new List<Product>();
        
        public string Search { get; set; }

        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 9;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public bool EnablePrevious => CurrentPage > 1;
        public bool EnableNext => CurrentPage < TotalPages;
    }
}
