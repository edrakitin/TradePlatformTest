using BusinessLayer.Repositories.Interfaces;
using BusinessLayer.Services;
using DataAccessLayer.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using TradePlatformTestApp.Models;

namespace TradePlatformTestApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public IActionResult AddEdit(int? productId)
        {
            if(!productId.HasValue)
            {
                AddEditProductModel addProductModel = new AddEditProductModel();                
                return View(addProductModel.Init(_unitOfWork));
            }

            RepositoryService repositoryService = new RepositoryService(_unitOfWork);
            
            var product = repositoryService.ProductService.GetRangeByParams(
                 r => r,
                 r => r.Id == productId.Value)
                .FirstOrDefault();

            if(product == null)
            {
                return NotFound();
            }
            
            AddEditProductModel editProductModel = new AddEditProductModel(product);
                       
            return View(editProductModel.Init(_unitOfWork));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddEdit(AddEditProductModel model)
        {
            if (ModelState.IsValid)
            {                
                var user = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                var userId = user.Value;

                RepositoryService repositoryService = new RepositoryService(_unitOfWork);

                try
                {
                    var product = new Product()
                    { 
                        Id = model.Id,
                        Name = model.Name,
                        Description = model.Description, 
                        Cost = model.Cost, 
                        Phone = model.Phone, 
                        ProductCategoryId = model.ProductCategoryId, 
                        ProductStatusId = model.ProductStatusId, 
                        CreatorId = userId                          
                    };

                    if (model.FirstPhoto != null)
                    {
                        byte[] imageData = null;

                        using (var binaryReader = new BinaryReader(model.FirstPhoto.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)model.FirstPhoto.Length);
                        }

                        product.ProductFiles.Add(new ProductFile() { Content = Convert.ToBase64String(imageData), Type = "image/jpg" });
                    }
                    
                    if (model.SecondPhoto != null)
                    {
                        byte[] imageData = null;

                        using (var binaryReader = new BinaryReader(model.SecondPhoto.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)model.SecondPhoto.Length);
                        }

                        product.ProductFiles.Add(new ProductFile() { Content = Convert.ToBase64String(imageData), Type = "image/jpg" });
                    }

                    if(product.Id == 0)
                    {
                        repositoryService.ProductService.Add(product);
                    }
                    else
                    { 
                        repositoryService.ProductService.Update(product);
                    }
                    _unitOfWork.Commit();

                    return RedirectToAction("Index", "Home", null);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                } 
            }

            return View(model.Init(_unitOfWork));
        }
    }
}