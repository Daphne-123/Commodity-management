using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModel;
using StoreDAL;

namespace StoreBLL
{
    public class ProductBLL
    {
        private ProductDAL clsDal = new ProductDAL();

        public List<ProductInfo> GetProductList()
        {
            return clsDal.GetProductList();
        }
        public ProductInfo GetProductById(int id)
        {
            return clsDal.GetProductById(id); 
        }
        public bool Update(ProductInfo cls)
        {
            return clsDal.Update(cls) > 0;
        }
        public bool Delete(int stuId)
        {
            return clsDal.Delete(stuId) > 0;
        }
    }
}
