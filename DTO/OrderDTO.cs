using System;

namespace DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int ShoeID { get; set; }
        public int UserID { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public override string ToString()
        {

            return $"{OrderID,-3} *\t{ShoeID,-3} *\t{UserID,-3} *\t{Quantity,-3} *\t{OrderDate.ToString("d"),-10} *\t{Price,-7} *\t{RowInsertTime} *\t{RowUpdateTime} *";
        }
    }
}
