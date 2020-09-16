using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DbModels
{
    public class ProductStatus
    {
        public int Id { get; set; }        
        public string Name { get; set; }   
        public PriorityLevel PriorityLevel { get;set;}
    }

    public enum PriorityLevel
    {
        Low = 1,
        Middle = 2,         
        Max = 3
    }
}
