using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FirstAboutManager : IFirstAboutService
    {
        private readonly IFirstAboutDal _firstAboutDal;
        public FirstAboutManager(IFirstAboutDal firstAboutDal)
        {
            _firstAboutDal = firstAboutDal;
        }
        public void TAdd(FirstAbout entity)
        {
            _firstAboutDal.Insert(entity);
        }

        public void TDelete(FirstAbout entity)
        {
            _firstAboutDal.Delete(entity);
        }

        public FirstAbout TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<FirstAbout> TGetList()
        {
            return _firstAboutDal.GetList();
        }

        public void TUpdate(FirstAbout entity)
        {
            _firstAboutDal.Update(entity);
        }
    }
}
