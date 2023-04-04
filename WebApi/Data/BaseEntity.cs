using System;

namespace WebApi.Data
{
    public class BaseEntity
    {
        public DateTime LastUpdatedOn { get; set; }
        
        public int LastUpdatedBy { get; set; }
        
        
    }
}