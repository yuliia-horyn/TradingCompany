using System;

namespace DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Keyword { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BankCard { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public override string ToString()
        {
            return $"{UserID,-3}*\t{FirstName,-8}*\t{LastName,-8}* {Gender,-6}*\t{Address,-52}*\t{Email,-25}* {PhoneNumber,-10} * {BankCard,-20}* {RowInsertTime} * {RowUpdateTime}";
        }
    }
}
