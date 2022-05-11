using EduCollector.Application;
using EduCollector.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EduCollectorContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Category>> GetCategoriesWithPost(SearchCategoryOptions searchCategory)
        {
            var allCategories = await _dbContext.Categories.Include(p=>p.Posts).ToListAsync();

            if(searchCategory == SearchCategoryOptions.FirstBestAllTheTime)
            {
                return GetOneMaxPost(allCategories);
            }
            else if(searchCategory == SearchCategoryOptions.FirstBestThisMonth)
            {
                DateTime d = DateTime.Now;

                allCategories = allCategories.Where(c => c.Posts.Any(p => (p.Date.Month == d.Month && d.Year == p.Date.Year))).ToList();
                
                return GetOneMaxPost(allCategories);
            }

            return allCategories;
        }

        private List<Category> GetOneMaxPost(List<Category> allCategories)
        {
            foreach (var c in allCategories)
            {
                Post max = null;
                foreach (var p in c.Posts) 
                {
                    if (max == null)
                    {
                        max = p;
                        break;
                    }
                    if(max.Rate < p.Rate)
                        max = p;
                }
                c.Posts = new List<Post>();
                if (max!=null)
                    c.Posts.Add(max);
            }
            return allCategories;
        }
    }
}
