﻿using System;

using TravelGuideTunisia.Mobile.Models;

namespace TravelGuideTunisia.Mobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
