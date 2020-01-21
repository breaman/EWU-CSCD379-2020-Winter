using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Business.Services
{
    public class GiftService : IGiftService
    {
        private ApplicationDbContext DbContext { get; }
        private IMapper Mapper { get; }
        public GiftService(ApplicationDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public async Task<Dtos.Gift> AddGift(Dtos.GiftInput giftInput)
        {
            var gift = Mapper.Map<Data.Gift>(giftInput);
            DbContext.Gifts.Add(gift);
            await DbContext.SaveChangesAsync();

            return Mapper.Map<Dtos.Gift>(gift);
        }

        public async Task<IList<Dtos.Gift>> FetchAllGifts()
        {
            var gifts = await DbContext.Gifts.ToListAsync();
            return gifts.Select(g => Mapper.Map<Dtos.Gift>(g)).ToList();
        }

        public async Task<Dtos.Gift> FetchGiftById(int id)
        {
            var gift = await DbContext.Gifts.SingleOrDefaultAsync(g => g.Id == id);
            return Mapper.Map<Dtos.Gift>(gift);
        }
    }
}
