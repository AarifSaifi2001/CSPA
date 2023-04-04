using System;
using System.Collections.Generic;
using WebApi.Data;

namespace WebApi.Model
{
    public class CarDetailModel : CarModel
    {
        public string carbrand { get; set; }
        
        public string btype { get; set; }
        
        public int owner { get; set; }
        
        public string state { get; set; }
                
        public string address { get; set; }
        
        public string landmark { get; set; }
                
        public string cardesc { get; set; }
        
        public DateTime postedon { get; set; }

        public ICollection<PhotosModel> Photos { get; set; }    

        public int PostedBy { get; set; }

        public int currentUserId { get; set;}
    }
}