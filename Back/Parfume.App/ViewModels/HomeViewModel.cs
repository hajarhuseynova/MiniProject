﻿using Parfume.Core.Entities;

namespace Parfume.App.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<FakeSlider> FakeSlides { get; set; }
        public IEnumerable<Slider> Slides { get; set; }

    }
}