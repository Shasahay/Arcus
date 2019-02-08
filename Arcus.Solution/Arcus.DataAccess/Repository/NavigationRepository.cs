using Arcus.DataAccess.UnitOfWork;
using Arcus.Domain.Common;
using Arcus.Domain.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.Repository
{
    public class NavigationRepository : Repository<Navigation>, INavigationRepository
    {
        public NavigationRepository( DefaultDBContext context) : base(context)
        {

        }

        public DefaultDBContext DefaultDBContext { get { return Context as DefaultDBContext; } }

        public List<Navigation> GetNavigation()
        {
            var cats = DefaultDBContext.Categories.Join
            (DefaultDBContext.CategoryHierarchies.Distinct(), cat => cat.Id, catHier => catHier.categoryID, (cat, catHier) => new { cat, catHier }).ToList().OrderBy(x => x.cat.Id);
            var test = cats.GroupBy(x => x.cat.Name);
            List<Navigation> navigations = new List<Navigation>();
            foreach(var cat in cats)
            {
                var categories = new List<Category>();
                var nav = new Navigation();
                nav.Category = cat.cat;
                var cldCatId = DefaultDBContext.CategoryHierarchies.Where(x => x.categoryID == cat.cat.Id).Select( x => x.ChildCategoryID);
                
                if (cldCatId != null)
                {
                    foreach (var id in cldCatId)
                    {
                        var child = DefaultDBContext.Categories.Find(id);
                        categories.Add(child);
                    }
                }
                nav.SubCategories = categories;
                navigations.Add(nav);
            }
            navigations = navigations.GroupBy(x => x.Category.Id).Select(y => y.First()).ToList();
            return navigations;
        }
    }
}
