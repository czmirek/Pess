namespace Pess.Web.Code
{
    public class User
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string[] Roles { get; private set; }
    }
}