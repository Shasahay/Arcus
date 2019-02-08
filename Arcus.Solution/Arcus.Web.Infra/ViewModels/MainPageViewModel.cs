using Arcus.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.Web.Infra.ViewModels
{
    public class MainPageViewModel
    {
        public LeftColumnViewModelBase LeftColumn { get; set; }
        public MainPageRightColumnViewModel RightColumn { get; set; }
    }

    public class LeftColumnViewModelBase
    {

    }

    public class MainPageLeftColumnViewModel : LeftColumnViewModelBase
    {
        public List<Item> Items { get; set; }
        public MainPageLeftColumnViewModel()
        {
            Items = new List<Item>();
        }
    }
    

    public class DetailsLeftColumnViewModel : LeftColumnViewModelBase
    {
        public Item CurrentItem { get; set; }
    }

    public class CategoryLeftColumnViewModel : LeftColumnViewModelBase
    {
        public List<Item> Items { get; set; }
        public CategoryLeftColumnViewModel()
        {
            Items = new List<Item>();
        }
    }

    public class MainPageRightColumnViewModel
    {
        public List<Item> WidgetItems { get; set; }
        public List<Item> AdvertisementItems { get; set; }
        public List<Item> AnnouncementItems { get; set; }
        public MainPageRightColumnViewModel()
        {
            WidgetItems = new List<Item>();
            AdvertisementItems = new List<Item>();
            AnnouncementItems = new List<Item>();
        }
    }
}
