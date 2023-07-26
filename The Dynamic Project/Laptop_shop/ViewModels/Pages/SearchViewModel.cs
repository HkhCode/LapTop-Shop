using Laptop_shop.ViewModels.PreQuesties;
using System.ComponentModel.DataAnnotations;

namespace Laptop_shop.ViewModels.Pages
{
    public class SearchViewModel : UserSideLayoutModel
    {
        public string SearchExpression { get; set; }
        public List<SearchPageProducts> searchPageProducts { get; set; }
    }
}
