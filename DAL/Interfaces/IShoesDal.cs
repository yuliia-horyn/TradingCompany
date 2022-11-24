using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IShoesDal
    {
        List<ShoesDTO> GetAllShoes();
        ShoesDTO CreateShoes(ShoesDTO shoes);
        ShoesDTO UpdateShoesByID(ShoesDTO shoes, int id);
        ShoesDTO DeleteShoesByID(int id);
        ShoesDTO GetShoesByID(int id);
    }
}
