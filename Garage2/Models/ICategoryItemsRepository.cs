using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public interface ICategoryItemsRepository
    {
        IEnumerable<CategoryItems> AllCategoryItems { get; }
        CategoryItems Add(CategoryItems categoryItems);
        CategoryItems Update(CategoryItems categoryItems);
        CategoryItems Delete(int id);



    }
}
