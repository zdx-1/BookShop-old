using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;


namespace Great.Core
{
    public class WindowHelper
    {
        
        /// <summary>
        ///     警告对话框
        /// </summary>
        /// <param name="AlertMessage">警告信息</param>
        /// <param name="page">警告信息所在页</param>
        public static void Alert(String AlertMessage, Page page)
        {
            String script = "<script lanaguage=javascript>window.alert('"
                            + AlertMessage + "')</script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "alert"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "alert", script);
            }
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转，不跳出框架
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            ShowAndRedirect(page, msg, url, false);
        }


        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        /// <param name="openPage">是否跳出框架</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url, bool openPage)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            if(msg != null)
                Builder.AppendFormat("alert('{0}');", msg);
            if (openPage)
                Builder.AppendFormat("top.location.href='{0}'", url);
            else
                Builder.AppendFormat("location.href='{0}'", url);
            Builder.Append("</script>");
            //page.RegisterStartupScript("message", Builder.ToString());

            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "message"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
            }

        }

        /// <summary>
        /// 页面重载
        /// </summary>
        public static void Location()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script language=\"javascript\"> \n");
            sb.Append("window.location.href=window.location.href;");
            sb.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(sb.ToString());

        }

     
    }
}
