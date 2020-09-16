using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using BusinessLayer.Repositories.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TradePlatformTestApp.Models;

namespace TradePlatformTestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;        

        public HomeController(ILogger<HomeController> logger,  IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string search, int currentPage = 1)
        {
            ViewBag.SearchQuery = search;

            search = search?.Trim().ToUpperInvariant() ?? "";
                                    
            return View(GetProducts(search, currentPage));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        private ProductViewModel GetProducts(string search, int currentPage)
        {
            var user = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = user?.Value ?? "";

            RepositoryService repositoryService = new RepositoryService(_unitOfWork);

            var productsList = repositoryService.ProductService.GetRangeByParams(
                r => r,
                r => r.Name.ToUpper().Contains(search), 
                r => r.OrderByDescending(x => x.ProductStatus.PriorityLevel).ThenBy(x => x.Name), 
                r => r.Include(x => x.ProductCategory).Include(x => x.ProductStatus).Include(x => x.ProductFiles ), 
                (currentPage - 1) * 9)
                .ToList();

            var productsCount = repositoryService.ProductService.GetCountByParams(r => r);

            productsList.ForEach( r => 
                r.CanEdit = r.CreatorId?.Equals(userId) ?? false
            );;

            ProductViewModel productViewModel = new ProductViewModel()
            { 
                ProductList = productsList, 
                Search = search,  
                Count = productsCount,
                CurrentPage = currentPage
            };

            return productViewModel;
        }
    }
}
