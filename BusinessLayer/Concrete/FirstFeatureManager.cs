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
    public class FirstFeatureManager : IFirstFeatureService
    {
        private readonly IFirstFeatureDal _firstFeatureDal;
        public FirstFeatureManager(IFirstFeatureDal firstFeatureDal)
        {
            _firstFeatureDal = firstFeatureDal;
        }
        public void TAdd(FirstFeature entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(FirstFeature entity)
        {
            throw new NotImplementedException();
        }

        public FirstFeature TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<FirstFeature> TGetList()
        {
            return _firstFeatureDal.GetList();
        }

        public void TUpdate(FirstFeature entity)
        {
            throw new NotImplementedException();
        }
    }
}
