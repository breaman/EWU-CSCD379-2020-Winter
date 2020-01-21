using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Business.Services
{
    public interface IGiftService
    {
        Task<IList<Dtos.Gift>> FetchAllGifts();
        Task<Dtos.Gift> FetchGiftById(int id);
        Task<Dtos.Gift> AddGift(Dtos.GiftInput giftInput);

    }
}
