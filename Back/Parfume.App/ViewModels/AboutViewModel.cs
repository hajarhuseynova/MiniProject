using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class AboutViewModel
    {
        public IEnumerable<Slider> Slides { get; set; }
        public SettingAbout? SettingAbout { get; set; }

    }
}
