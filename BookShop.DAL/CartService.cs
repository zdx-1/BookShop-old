using System;
using System.Data;
using BookShop.Common.DB;
using BookShop.Model;

namespace BookShop.DAL
{
    public static class CartService
    {
        
        #region 图书取值方法（购买图书流程过渡页）

        /// <summary>
        /// 图书取值方法（购买图书流程过渡页） 
        /// </summary>
        /// <param name="id"></param>
        public static BooksInfo GetPageLoad(int id)
        {
            string sql = "select Id,Title,UnitPrice,ImgUrl from Books where Id=@Id";
            BooksInfo booksInfo = new BooksInfo();
            try
            {
                //先创建参数，然后才能添加参数 

                DBHelper.CreateParameters(1);  //参数个数，1个
                DBHelper.AddParameters(0, "@Id", id);
                DataTable dt = DBHelper.ExecuteDataTable(sql);
                foreach (DataRow row in dt.Rows)
                {
                    booksInfo.Id = Convert.ToInt32(row["Id"]);
                    booksInfo.Title = row["Title"].ToString();
                    booksInfo.UnitPrice = Decimal.Parse(row["UnitPrice"].ToString());
                    booksInfo.ImgUrl = row["ImgUrl"].ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return booksInfo;
        }

        #endregion
    }
}
