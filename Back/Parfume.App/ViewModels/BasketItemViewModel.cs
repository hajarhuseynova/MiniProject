namespace Parfume.App.ViewModels
{
	public class BasketItemViewModel
	{
        public int ParfumId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }
        public int DiscountPer { get; set; }
        public int Count { get; set; }
    }
}
