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
    public class ProductDAL
    {
        public List<ProductInfo> GetProductList()
        {
            string sql = "select cId,cImgUrl,cName,cNumber,cTime,cDeptId from Commodity";
            return ProductInfo.TableToList(DBHelper.GetDataSet(sql).Tables[0]);
        }

        public ProductInfo GetProductById(int id)
        {
            string sql = //"select cId,cImgUrl,cName,cNumber,cTime,cDeptId from Commodity cid = @id";
                $"select cId,cImgUrl,cName,cNumber,cTime,cDeptId from Commodity where cid={id}";

            //SqlParameter sp = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            //DataSet ds = DBHelper.GetDataSet(sql, sp);
            DataSet ds = SqlServer.Query(sql);
            ProductInfo product = new ProductInfo();
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    product = ProductInfo.TableToList(dt)[0];
                }
            }
            return product;
        }

        public int Update(ProductInfo cls)
        {
            string sql = "update Commodity set cImgUrl=@ImgUrl,cName=@Name,cNumber=@Number,cTime=@Time,cDeptId=@DeptId where cId=@id";
            SqlParameter cImgUrl = new SqlParameter("@ImgUrl", SqlDbType.NVarChar) { Value = cls.cImgUrl };
            SqlParameter cName = new SqlParameter("@Name", SqlDbType.NVarChar) { Value = cls.cName };
            SqlParameter cNumber = new SqlParameter("@Number", SqlDbType.Int) { Value = cls.cNumber };
            SqlParameter cTime = new SqlParameter("@Time", SqlDbType.NVarChar) { Value = cls.cTime };
            SqlParameter cDeptId = new SqlParameter("@DeptId", SqlDbType.Int) { Value = cls.cDeptId };
            SqlParameter cId = new SqlParameter("@id", SqlDbType.Int) { Value = cls.cId };
            return DBHelper.ExcuteNonQuery(sql, cImgUrl, cName, cNumber, cTime, cDeptId, cId);
        }
        public int Delete(int cId)
        {
            string sql = "delete from Commodity where cId = @id";
            SqlParameter sp = new SqlParameter("@id", SqlDbType.Int) { Value = cId };
            return DBHelper.ExcuteNonQuery(sql, sp);
        }
    }
}
