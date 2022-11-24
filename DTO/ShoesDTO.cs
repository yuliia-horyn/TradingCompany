using System;

namespace DTO
{
    public class ShoesDTO
    {
        public int ShoeID { get; set; }
        public string ShoeName { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public override string ToString()
        {

            return $"{ShoeID,-3}*\t{ShoeName,-50}*\t{Size,-3}*\t{Color,-15}* \t{Price,-7}*\t{RowInsertTime} *\t{RowUpdateTime} *";
        }
    }
}
