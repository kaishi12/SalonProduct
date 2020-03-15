namespace Salon.Account.Domain.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool Active { get; set; }
    }
}
