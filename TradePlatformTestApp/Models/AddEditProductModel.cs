using BusinessLayer.Repositories.Interfaces;
using BusinessLayer.Services;
using DataAccessLayer.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TradePlatformTestApp.Models
{
    public class AddEditProductModel
    {
        public AddEditProductModel()
        { }

        public AddEditProductModel(Product product)
        {
            Cost = product.Cost;
            Description = product.Description;
            Id = product.Id;
            Name = product.Name;
            Phone = product.Phone;
            ProductCategoryId = product.ProductCategoryId;
            ProductStatusId = product.ProductStatusId;
        }

        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage= "Название товара должно быть заполнено")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public double Cost { get; set; }

        [Display(Name = "Категория")]
        [UIHint("DropDown")]
        public int ProductCategoryId { get; set; }
        
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage= "Номер телефона обязателен")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Номер телефона необходимо правильно заполнить")]
        public string Phone { get; set; }
        
        [Display(Name = "Статус")]
        [UIHint("DropDown")]
        public int ProductStatusId { get; set; }
        
        public ICollection<SelectListItem>? AllProductCategories { get; set; }
        public ICollection<SelectListItem>? AllProductStatuses { get; set; }

        [Display(Name = "Фото товара 1")]
        public IFormFile? FirstPhoto { get; set; }

        [Display(Name = "Фото товара 2")]
        public IFormFile? SecondPhoto { get; set; }        

        public AddEditProductModel Init(IUnitOfWork unitOfWork)
        {
            RepositoryService repositoryService = new RepositoryService(unitOfWork);

            AllProductCategories = repositoryService.ProductCategoryService
                .GetRangeByParams(r => r, null, r => r.OrderBy(r => r.Name))
                .Select(r => new SelectListItem(){ Text = r.Name, Value = r.Id.ToString(), Selected = r.Id == ProductCategoryId })
                .ToList();

            AllProductStatuses = repositoryService.ProductStatusService
                .GetRangeByParams(r => r, null, r => r.OrderBy(r => r.PriorityLevel))
                .Select(r => new SelectListItem(){ Text = r.Name, Value = r.Id.ToString(), Selected = r.Id == ProductStatusId })
                .ToList();

            return this;
        }
    }
}
