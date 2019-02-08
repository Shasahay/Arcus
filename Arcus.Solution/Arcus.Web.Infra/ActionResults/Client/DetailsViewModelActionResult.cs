using Arcus.DataAccess;
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
    public class DetailsViewModelActionResult<TController> : ActionResultBase<TController> where TController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _itemId;
        private int _categoryId;
        private string _categoryName;
        public DetailsViewModelActionResult(Expression<Func<TController, ActionResult>> viewNameExpression, int id): this(viewNameExpression, id, DependencyResolver.Current.GetService<IUnitOfWork>())
        {

        }

        public DetailsViewModelActionResult(Expression<Func<TController, ActionResult>> viewNameExpression, int id, IUnitOfWork unitOfWork) : base(viewNameExpression)
        {
            //_unitOfWork = unitOfWork;
            _unitOfWork = new UnitOfWork(new DefaultDBContext());
            _itemId = id;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var varCategories = this._unitOfWork.Categories.GetAll();
            var cats = this._unitOfWork.Navigations.GetNavigation();
            var mainViewModel = new HomePageViewModel();
            var headerViewModel = new HeaderViewModel();
            var footerViewModel = new FooterViewModel();
            var mainPageViewModel = new MainPageViewModel();
            var varItem = _unitOfWork.Items.Get(this._itemId);
            var varItem2 = _unitOfWork.Items.find(x => x.Id == _itemId).FirstOrDefault();
            var itemContID = varItem.ItemContentId;
            this._categoryName = _unitOfWork.Categories.Get(varItem.ItemCategoryId).Name;
            if (cats != null && cats.Any())
            {
                headerViewModel.Navigations = cats;
                headerViewModel.Categories = cats.Select(x => x.Category).ToList();
                headerViewModel.CurrentCategoryName = this._categoryName;
                headerViewModel.CurrentCategoryId = varItem.ItemCategoryId;
                footerViewModel.Categories = cats.Select(x => x.Category).ToList();
            }
            mainPageViewModel.LeftColumn = this.BindingDataForCategoryLeftColumnViewModel(itemContID);
            mainPageViewModel.RightColumn = this.BindingDataForMainPageRightColumnViewModel(_unitOfWork.Categories.Get(varItem.ItemCategoryId).Name);
            if (!string.IsNullOrEmpty(this._categoryName))
            {
                headerViewModel.SiteTitle = string.Format("Arcus Associates - {0} Section", this._categoryName);

            }
            else
                headerViewModel.SiteTitle = "Acrus Assiciates !!";

            mainViewModel.Header = headerViewModel;
            mainViewModel.DashBoard = new DashboardViewModel();
            mainViewModel.Footer = footerViewModel;
            mainViewModel.MainPage = mainPageViewModel;

            this.GetViewResult(mainViewModel).ExecuteResult(context);
        }

        #region private functions

        private DetailsLeftColumnViewModel BindingDataForCategoryLeftColumnViewModel(int itemContentId)
        {
            var viewModel = new DetailsLeftColumnViewModel();
            var item = new Arcus.Domain.Common.Item();
            item.ItemContent = this._unitOfWork.ItemContents.Get(itemContentId);
            viewModel.CurrentItem = item;
            return viewModel;
        }
        

        private MainPageRightColumnViewModel BindingDataForMainPageRightColumnViewModel(string categoryName)
        {
            var mainPageRightCol = new MainPageRightColumnViewModel();
            mainPageRightCol.WidgetItems = _unitOfWork.Items.GetItems(categoryName, ApplicationVariable.ItemType.Widget.ToString());
            mainPageRightCol.AdvertisementItems = _unitOfWork.Items.GetItems(categoryName, ApplicationVariable.ItemType.Advertisement.ToString());
            mainPageRightCol.AnnouncementItems = _unitOfWork.Items.GetItems(categoryName, ApplicationVariable.ItemType.Announcement.ToString());
            return mainPageRightCol;
        }




        #endregion
    }
}
