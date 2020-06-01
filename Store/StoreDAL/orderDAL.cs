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
    public class orderDAL
    {
        /// <summary>
        /// 获取全部订单列表
        /// </summary>
        /// <returns></returns>
        public List<orderInfo> GetOrderList()
        {
            string sql = "select orderId,cName,cNumber,orderDate,orderAddress from OrderList";
            return orderInfo.TableToList(DBHelper.GetDataSet(sql).Tables[0]);
        }
        /// <summary>
        /// 根据id查找订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public orderInfo GetOrderById(int id)
        {
            string sql = $"select orderId,cName,cNumber,orderDate,orderAddress from OrderList where orderId={id}";

            DataSet ds = SqlServer.Query(sql);
            orderInfo order = new orderInfo();
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    order = orderInfo.TableToList(dt)[0];
                }
            }
            return order;
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <returns></returns>
        public int AddOrder(orderInfo order)
        {
            string sqlStr = $"insert into OrderList ( cName,cNumber,orderDate,orderAddress) values ('{order.cName}', '{order.cNumber}', '{order.orderDate}', '{order.orderAddress}')";

            return SqlServer.NotQuery(sqlStr);
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        public int DeleteOrder(int orderId)
        {
            string sql = "delete from OrderList where orderId = @orderId";
            SqlParameter sp = new SqlParameter("@orderId", SqlDbType.Int) { Value = orderId };
            return DBHelper.ExcuteNonQuery(sql, sp);
        }

    }
}
