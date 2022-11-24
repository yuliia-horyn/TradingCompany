using System;

namespace DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public byte[] Passsword { get; set; }
        public Guid Salt{ get; set; }
        public string Keyword { get; set; }
        public bool IsFemale { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BankCard { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public override string ToString()
        {
            return $"{UserID,-5}*\t{FirstName,-8}*\t{LastName,-8}* {IsFemale,-6}*\t{Address,-52}*\t{Email,-25}* {PhoneNumber,-10} * {BankCard,-20}* {RowInsertTime} * {RowUpdateTime}";
        }
    }
}
