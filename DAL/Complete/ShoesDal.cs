using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Complete
{
    public class ShoesDal : IShoesDal
    {
        private readonly IMapper _mapper;
        public ShoesDal(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ShoesDTO CreateShoes(ShoesDTO shoes)
        {
            using (var entites = new shoefactoryEntities())
            {
                var shoesInDB = _mapper.Map<Shoess>(shoes);
                shoesInDB.RowInsertTime = DateTime.Now;
                shoesInDB.RowUpdateTime = DateTime.Now;
                entites.Shoesses.Add(shoesInDB);
                entites.SaveChanges();
                return _mapper.Map<ShoesDTO>(shoesInDB);
            }
        }
        public ShoesDTO GetShoesByID(int id)
        {
            using (var entities = new shoefactoryEntities())
            {
                var shoesID = entities.Shoesses.Select(x => x.ShoeID).ToList();
                var shoes = entities.Shoesses.Where(x => shoesID.Contains(id)).ToList();
                return _mapper.Map<ShoesDTO>(shoes[id-1]);
            }
        }
        public List<ShoesDTO> GetAllShoes()
        {
            using (var entities = new shoefactoryEntities())
            {
                var shoes = entities.Shoesses.ToList();
                return _mapper.Map<List<ShoesDTO>>(shoes);
            }
        }
        public ShoesDTO UpdateShoesByID(ShoesDTO shoes, int id)
        {
            using (var entites = new shoefactoryEntities())
            {
                var shoesInDB = _mapper.Map<Shoess>(shoes);
                shoesInDB = entites.Shoesses.SingleOrDefault(x => x.ShoeID == id);
                if (shoesInDB != null)
                {
                    shoesInDB.RowUpdateTime = DateTime.Now;
                    shoesInDB.ShoeName = shoes.ShoeName;
                    shoesInDB.Size = shoes.Size;
                    shoesInDB.Color = shoes.Color;
                    shoesInDB.Price= (decimal)shoes.Price;                  
                    entites.SaveChanges();
                }
                return _mapper.Map<ShoesDTO>(shoesInDB);
            }
        }

        public ShoesDTO DeleteShoesByID(int id)
        {
            using (var entites = new shoefactoryEntities())
            {
                var shoesInDB = entites.Shoesses.SingleOrDefault(x => x.ShoeID == id);
                if (shoesInDB != null)
                {
                    entites.Shoesses.Remove(shoesInDB);
                    entites.SaveChanges();
                }
                return _mapper.Map<ShoesDTO>(shoesInDB);
            }
        }
    }
}
