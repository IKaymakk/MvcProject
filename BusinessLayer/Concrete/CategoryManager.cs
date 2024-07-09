using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categorydal;
        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }
        public void CategoryAdd(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetCategory(int id)
        {
            return _categorydal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }
        public int GetCategoryCount()
        {
            return _categorydal.Count();
        }

        public void ChangeStatus(int id)
        {
            Category c = _categorydal.Get(x => x.CategoryID == id);
            if (c.CategoryStatus == true)
            {
                c.CategoryStatus = false;
                _categorydal.Update(c);
            }
            else
            {
                c.CategoryStatus = true;
                _categorydal.Update(c);
            }

        }
    }
}
