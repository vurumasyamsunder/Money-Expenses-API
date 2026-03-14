using Money_Expenses.Interfaces;

namespace Money_Expenses.DTOs
{
    public class UserDTO
    {
        public int userid { get; set; }
        public string Username { get; set; }
        public string email { get; set; }
        public string Passwordhash { get; set; }  // Store as hash in DB (never return this in response)
    }
}
