using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DbModels
{
    public class ProductFile
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get;set;}        
    }
}
