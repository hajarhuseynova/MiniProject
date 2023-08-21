using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<FakeSlider> FakeSlides { get; set; }
        public IEnumerable<Slider> Slides { get; set; }
        public IEnumerable<Functions> Functions { get; set; }
        public SettingFooter? SettingFooter { get; set; }
        public SettingNavbar? SettingNavbar { get; set; }
        public SettingHomePage? SettingHomePage { get; set; }



    }
}
