namespace WebApi.Model
{
    public class UserModel
    {
        public int id{ get; set; }

        public string username { get; set; }
        
        public string password { get; set; }
        
        public string email { get; set;}
        
        public long mobileno { get; set;}
    }
}