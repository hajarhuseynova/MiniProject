namespace Parfume.App.ViewModels
{
	public class BasketItemViewModel
	{
        public int ProductId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Volume { get; set; }
        public int DiscountPer { get; set; }
        public int Count { get; set; }
    }
}
