using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data
{
    public class Car : BaseEntity
    {
        public int  id { get; set; }
        
        public string Name { get; set; }
        
        public int Price { get; set; }
        
        public ICollection<Photos> Photos { get; set; }
        
        public int  SellRent { get; set; }
        
        public int km { get; set; }
        
        public int CitiesId { get; set; }
        
        public Cities City { get; set; }
        
        
        public int modelyear { get; set; }
        
        public int  FuelTypeId { get; set; }
        
        public FuelType FuelType { get; set; }
        
        public string carbrand { get; set; }
        
        public int  BodyTypeId { get; set; }

        public BodyType BodyType { get; set; }
        
        
        
        public int owner { get; set; }
        
        public string state { get; set; }
        
        public string address { get; set; }
        
        public string cardesc { get; set; }
        
        public DateTime PostedOn { get; set; } = DateTime.Now;

        [ForeignKey("User")]     
        public int PostedBy { get; set; }

        public User User { get; set; }
        
    }
}