using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModel;
using StoreUtility;
using System.Data.SqlClient;
using System.Data;

namespace StoreDAL
{
    public class vipDAL
    {
        /// <summary>
        /// 获取会员列表
        /// </summary>
        /// <returns></returns>
        public List<vipInfo> GetVipList()
        {
            string sql = "select pId,pName,pGender,pAge,pJoinDate from Member";
            return vipInfo.TableToList(DBHelper.GetDataSet(sql).Tables[0]);
        }
        /// <summary>
        /// 根据id查找会员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public vipInfo GetVipById(int id)
        {
            string sql =  $"select pId, pName,pGender,pAge,pJoinDate from Member where pId={id}";
            
            DataSet ds = SqlServer.Query(sql);
            vipInfo vip = new vipInfo();
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    vip = vipInfo.TableToList(dt)[0];
                }
            }
            return vip;
        }
        /// <summary>
        /// 添加会员信息
        /// </summary>
        /// <param name="vip"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        public int AddVip(vipInfo vip, int pId)
        {
            string sqlStr = $"insert into Member( pName,pGender,pAge,pJoinDate, pId) values ('{vip.pName}', '{vip.pGender}', '{vip.pAge}', '{vip.pJoinDate}', {pId})";

            return SqlServer.NotQuery(sqlStr);
        }
        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="cls"></param>
        /// <returns></returns>
        public int UpdateVip(vipInfo vip)
        {
            string sqlStr = $"update Member set pName='{vip.pName}', pGender='{vip.pGender}', pAge='{vip.pAge}', pJoinDate='{vip.pJoinDate}' where cId={vip.pId}";

            return SqlServer.NotQuery(sqlStr);
        }
        /// <summary>
        /// 删除会员信息
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        public int DeleteVip(int pId)
        {
            string sql = "delete from Member where pId = @pId";
            SqlParameter sp = new SqlParameter("@pId", SqlDbType.Int) { Value = pId };
            return DBHelper.ExcuteNonQuery(sql, sp);
        }

    }
}
