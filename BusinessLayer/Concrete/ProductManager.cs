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
	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public Product GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetProductByID(int id)
		{
			return _productDal.GetListAll(x => x.ProductID == id);
		}

		public List<Product> GetList()
		{
			return _productDal.GetListAll();
		}

		public List<Product> GetLast3Product()
		{
			return _productDal.GetListAll().Take(3).ToList();
		}

		public List<Product> GetProductListWithCategory()
		{
			return _productDal.GetListWithCategory();
		}

		public void ProductAdd(Product product)
		{
			throw new NotImplementedException();
		}

		public void ProductDelete(Product product)
		{
			throw new NotImplementedException();
		}

		public void ProductUpdate(Product product)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetProductListByBrand(int id)
		{
			return _productDal.GetListAll(x => x.BrandID == id);
        }
	}
}
