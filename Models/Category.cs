﻿namespace GarageManager.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ServiceCategory>? ServiceCategories { get; set; }
    }
}
