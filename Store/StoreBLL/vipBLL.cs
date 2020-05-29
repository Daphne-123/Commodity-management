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
    public class vipBLL
    {
        private vipDAL vipDal = new vipDAL();

        public List<vipInfo> GetVipList()
        {
            return vipDal.GetVipList();
        }
        public vipInfo GetVipById(int id)
        {
            return vipDal.GetVipById(id);
        }
        public bool AddVip(vipInfo vip, int pId)
        {
            return vipDal.AddVip(vip,pId) > 0;
        }
        public bool UpdateVip(vipInfo vip)
        {
            return vipDal.UpdateVip(vip) > 0;
        }
        public bool DeleteVip(int pId)
        {
            return vipDal.DeleteVip(pId) > 0;
        }
    }
}
