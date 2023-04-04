using System;

namespace WebApi.Model
{
    public class CarModel
    {
        public int id { get; set; }
        
        public string name { get; set; }
        
        public int price { get; set; }
        
        public string Photo { get; set; }

        public int sellRent { get; set; }
        
        public int km { get; set; }
        
        public string location { get; set; }
        
        public int modelyear { get; set; }
        
        public string fueltype { get; set; }  
              
    }
}