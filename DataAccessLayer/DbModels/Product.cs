using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.DbModels
{
    public class Product
    {
        public Product()
        {
            ProductFiles = new List<ProductFile>();
        }
        
        public int Id { get; set; }        

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }        

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }        

        /// <summary>
        /// Цена
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }   

        [NotMapped]
        public bool CanEdit { get; set; }

        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// Категория товара
        /// </summary>
        public ProductCategory ProductCategory { get; set; }

        [ForeignKey("ProductStatus")]
        public int ProductStatusId { get; set; }
        /// <summary>
        /// Платный статус товара
        /// </summary>
        public ProductStatus ProductStatus { get; set; }

        public ICollection<ProductFile> ProductFiles { get; set;}

        /// <summary>
        /// Идентификатор создателя
        /// </summary>
        public string CreatorId { get; set; }         
    }
}
