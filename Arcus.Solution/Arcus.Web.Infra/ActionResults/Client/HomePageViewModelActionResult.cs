using Arcus.DataAccess;
using Arcus.DataAccess.Repository;
using Arcus.DataAccess.UnitOfWork;
using Arcus.DataAccess.Varibles;
using Arcus.Web.Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Arcus.Web.Infra.ActionResults.Client
{
    public class HomePageViewModelActionResult<TController> : ActionResultBase<TController> where TController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public HomePageViewModelActionResult(Expression<Func<TController, ActionResult>> viewNameExpression) : this(viewNameExpression, DependencyResolver.Current.GetService<IItemRepository>(), DependencyResolver.Current.GetService<ICategoryRepository>())
        {

        }

        public HomePageViewModelActionResult(Expression<Func<TController, ActionResult>> viewNameExpression, IItemRepository itemRepository, ICategoryRepository categoryRepository) : base(viewNameExpression)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = new UnitOfWork(new DefaultDBContext());
        }

        public override void ExecuteResult(ControllerContext context)
        {
            try
            {
                //var cats = this._unitOfWork.Categories.GetAll().ToList();
                var cats = this._unitOfWork.Navigations.GetNavigation();
                var mainViewModel = new HomePageViewModel();
                var headerViewModel = new HeaderViewModel();
                var footerViewModel = new FooterViewModel();
                var mainPageViewModel = new MainPageViewModel();

                headerViewModel.SiteTitle = "Arcus Associates";
                if (cats != null)
                {
                    headerViewModel.Navigations = cats;
                    headerViewModel.Categories = cats.Select(x => x.Category).ToList();
                    headerViewModel.CurrentCategoryId = cats.Where(x => x.Category.Name.Equals("Home", StringComparison.CurrentCultureIgnoreCase)).Select(i => i.Category.Id).First();
                    headerViewModel.CurrentCategoryName = cats.Select(x => x.Category.Name).FirstOrDefault();
                    footerViewModel.Categories = cats.Select(x => x.Category).ToList(); 
                }

                mainPageViewModel.LeftColumn = this.BindingDataForMainPageLeftColumnViewModel();
                mainPageViewModel.RightColumn = this.BindingDataForMainPageRightColumnViewModel();
                mainViewModel.Header = headerViewModel;

                mainViewModel.Footer = footerViewModel;
                mainViewModel.DashBoard = new DashboardViewModel();
                mainViewModel.MainPage = mainPageViewModel;
                this.GetViewResult(mainViewModel).ExecuteResult(context);
            }
            catch(Exception exception)
            {

            }
        }

        private MainPageRightColumnViewModel BindingDataForMainPageRightColumnViewModel()
        {
            var mainPageRightCol = new MainPageRightColumnViewModel();
            mainPageRightCol.WidgetItems = _unitOfWork.Items.GetItems(ApplicationVariable.ItemType.Widget.ToString());
            mainPageRightCol.AdvertisementItems = _unitOfWork.Items.GetItems(ApplicationVariable.ItemType.Advertisement.ToString());
            mainPageRightCol.AnnouncementItems = _unitOfWork.Items.GetItems(ApplicationVariable.ItemType.Announcement.ToString());
            return mainPageRightCol;
        }

        private MainPageLeftColumnViewModel BindingDataForMainPageLeftColumnViewModel()
        {
            var mainPageLeftCol = new MainPageLeftColumnViewModel();
            mainPageLeftCol.Items = _unitOfWork.Items.GetItems(ApplicationVariable.ItemType.MainContent.ToString());
            return mainPageLeftCol;
        }
    }
}
    