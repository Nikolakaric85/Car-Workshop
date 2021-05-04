using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2.Models
{
    public class CategoryItemsRepository: ICategoryItemsRepository
    {
        private readonly AppDbContext context;

        public CategoryItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        IEnumerable<CategoryItems> ICategoryItemsRepository.AllCategoryItems => context.CategoryItems;

        public CategoryItems Add(CategoryItems categoryItems)
        {
            context.CategoryItems.Add(categoryItems);
            context.SaveChanges();
            return categoryItems;
        }

        public CategoryItems Update(CategoryItems categoryItems)
        {
            var catItems = context.CategoryItems.Attach(categoryItems);
            catItems.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return categoryItems;
        }

        public CategoryItems Delete(int id)
        {
            CategoryItems categoryItems = context.CategoryItems.Find(id);
            context.CategoryItems.Remove(categoryItems);
            context.SaveChanges();
            return categoryItems;
        }

        
        
    }
}


