using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    internal class CategoryManager
    {
        GenericRepository<Category> gr = new GenericRepository<Category>();

        public List<Category> GetAllBL()
        {
            return gr.List();
        }
        public void CategoryAddBL(Category c)
        {
            //Şartları Katmanlı Mimariyi İçin Tanımlamadım
            gr.Insert(c);
        }
    }
}
