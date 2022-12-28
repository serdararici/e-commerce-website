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
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public List<Brand> GetBrandById(int id)
		{
			return _brandDal.GetListAll(x=>x.MarkaID == id);
		}

		public List<Brand> GetList()
		{
			throw new NotImplementedException();
		}

		public void TAdd(Brand t)
		{
            _brandDal.Insert(t);
        }

		public void TDelete(Brand t)
		{
			throw new NotImplementedException();
		}

		public Brand TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Brand t)
		{
			throw new NotImplementedException();
		}
	}
}
