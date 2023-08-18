using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class ContactViewModel
    {
        public IEnumerable<Place> Places { get; set; }
        public SendMessage Messages { get; set; }


    }
}
