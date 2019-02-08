using Arcus.DataAccess;
using Arcus.DataAccess.UnitOfWork;
using Arcus.DataAccess.Varibles;
using Arcus.Domain.Common;
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
    public class CategoryViewModelActionResult<TController> : ActionResultBase<TController> where TController : Controller 
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly string _categoryName;
        public CategoryViewModelActionResult(Expression<Func<TController, ActionResult>> viewNameExpression, string categoryName)
            : this(viewNameExpression, categoryName, DependencyResolver.Current.GetService<IUnitOfWork>())
        {

        }
        public CategoryViewModelActionResult( Expression<Func<TController, ActionResult>> viewNameExpression,string categoryName, IUnitOfWork unitOfWork) : base(viewNameExpression)
	    {
            _categoryName = categoryName;
            _unitOfWork = new UnitOfWork(new DefaultDBContext());
	    }

        #region implementation

        public override void ExecuteResult(ControllerContext context)
        {
            var varCategories = this._unitOfWork.Categories.GetAll();
            var cats = this._unitOfWork.Navigations.GetNavigation();
            var mainViewModel = new HomePageViewModel();
            var headerViewModel = new HeaderViewModel();
            var footerViewModel = new FooterViewModel();
            var mainPageViewModel = new MainPageViewModel();
            
            if (cats != null && cats.Any())
            {
                headerViewModel.Navigations = cats;
                headerViewModel.Categories = cats.Select(x => x.Category).ToList();
                headerViewModel.CurrentCategoryName = this._categoryName;
                headerViewModel.CurrentCategoryId = varCategories.Where(x => x.Name.Equals(this._categoryName, StringComparison.CurrentCultureIgnoreCase)).Select(i => i.Id).First();
                footerViewModel.Categories = cats.Select(x => x.Category).ToList(); 
            }
            mainPageViewModel.LeftColumn = this.BindingDataForCategoryLeftColumnViewModel(this._categoryName);
            mainPageViewModel.RightColumn = this.BindingDataForMainPageRightColumnViewModel(this._categoryName);

            var items = ((CategoryLeftColumnViewModel)mainPageViewModel.LeftColumn).Items;
            if (items != null && items.Count > 0)
            {
                headerViewModel.SiteTitle = string.Format("Arcus Associates - {0} Section", items.FirstOrDefault().Category.Name);
                
            }
            else
                headerViewModel.SiteTitle = "Acrus Assiciates !!";

            mainViewModel.Header = headerViewModel;
            mainViewModel.DashBoard = new DashboardViewModel();
            mainViewModel.Footer = footerViewModel;
            mainViewModel.MainPage = mainPageViewModel;

            this.GetViewResult(mainViewModel).ExecuteResult(context);
        }

        //public override void EnsureAllInjectInstanceNotNull()
        //{
        //    Guard.ArgumentNotNull(this._categoryRepository, "CategoryRepository");
        //    Guard.ArgumentNotNull(this._itemRepository, "ItemRepository");
        //    Guard.ArgumentMustMoreThanZero(this._numOfPage, "NumOfPage");
        //    Guard.ArgumentMustMoreThanZero(this._categoryId, "CategoryId");
        //}

        #endregion

        #region private functions

        private CategoryLeftColumnViewModel BindingDataForCategoryLeftColumnViewModel(string categoryName)
        {
            var viewModel = new CategoryLeftColumnViewModel();
            viewModel.Items = this._unitOfWork.Items.GetItems(categoryName, ApplicationVariable.ItemType.MainContent.ToString());
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
