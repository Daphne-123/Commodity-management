using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModel;
using StoreDAL;
using System.Data;

namespace StoreBLL
{
    public class orderBLL
    {
        private orderDAL orderDal = new orderDAL();

        public List<orderInfo> GetOrderList()
        {
            return orderDal.GetOrderList();
        }
        public orderInfo GetOrderById(int id)
        {
            return orderDal.GetOrderById(id);
        }
        public bool AddOrder(orderInfo vip)
        {
            return orderDal.AddOrder(vip) > 0;
        }
        public bool DeleteOrder(int id)
        {
            return orderDal.DeleteOrder(id) > 0;
        }
    }
}
