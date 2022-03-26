using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace online_food_ordering.user
{
    public partial class download_invoice : System.Web.UI.Page
    {
        private int id = 0;
        private int uid = 0;
        private Order_MasterBL order_MasterBL;
        private Order_Master order_Master;
        private DataTable dt;
        protected void Page_Init(object sender, EventArgs e)
        {
            order_MasterBL = new Order_MasterBL();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ADMIN_USER"] != null)
            {

            }
            else
            {
                if(Session["FOOD_USER_ID"] == null)
                {
                    Response.Redirect("shop.aspx");
                }
            }

            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                order_Master = new Order_Master();
                order_Master.SetId(id);

                dt = order_MasterBL.DisplayOrderMasterByOId(order_Master);

                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        uid = Convert.ToInt32(dr["user_id"]);
                    }
                }

                string orderEmail = HttpContent("https://localhost:44350/email_body/orderemail.aspx?id=" + uid + "&oid=" +  id);

                string FileName = "ORD_" + id + "_" + uid + "_" + DateTime.Now.Ticks + ".pdf";
                
                GeneratePDF("",FileName,true,orderEmail);

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename=" + FileName);
                Response.Flush();
                Response.End();

            }
        }
        private string HttpContent(string url)
        {
            WebRequest objRequest = System.Net.HttpWebRequest.Create(url);
            StreamReader sr = new StreamReader(objRequest.GetResponse().GetResponseStream());
            string result = sr.ReadToEnd();
            sr.Close();
            return result;
        }

        private void GeneratePDF(string path,string fileName,bool download, string text)
        {
            StringReader sr = new StringReader(text.ToString());
            Document pdfDoc = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}