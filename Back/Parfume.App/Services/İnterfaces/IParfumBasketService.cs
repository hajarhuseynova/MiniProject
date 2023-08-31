
using Parfume.App.ViewModels;

namespace Parfume.App.Services.İnterfaces
{
    public interface IParfumBasketService
    {
        public Task AddBasket(int id, int? count);
        public Task<List<BasketItemViewModel>> GetAllBaskets();
        public Task Remove(int id);
    }
}
