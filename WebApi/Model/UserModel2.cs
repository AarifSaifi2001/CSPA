namespace WebApi.Model
{
    public class UserModel2
    {
        public int id{ get; set; }

        public string username { get; set; }
        
        public byte[] password { get; set; }
        
        public string email { get; set;}
        
        public long mobileno { get; set;}
    }
}