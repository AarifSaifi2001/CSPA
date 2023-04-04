namespace WebApi.Data
{
    public class User : BaseEntity
    {
        public int  id { get; set; }
        
        public string username { get; set; }
        
        public byte[] password { get; set; }
        
        public byte[] passwordKey { get; set; }
        
        public string email{ get; set;}

        public long mobileno{ get; set;}
    }
}