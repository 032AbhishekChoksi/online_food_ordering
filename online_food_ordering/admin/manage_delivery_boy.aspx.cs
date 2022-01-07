using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class manage_delivery_boy : System.Web.UI.Page
    {
        ClassAdmin admin = new ClassAdmin();
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Manage Delivey Boy | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login.aspx");
            }
            
            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
            }

            if (IsPostBack) return;

            if (id > 0)
            {
                foreach (DataRow dr in admin.DisplayDeliveyBoyById(id).Rows)
                {
                    txtname.Text = dr["name"].ToString();
                    txtmobile.Text = dr["mobile"].ToString();
                    txtpassword.Text = dr["password"].ToString();
                }
            }
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            long mobile = Convert.ToInt64(txtmobile.Text);
            string password = txtpassword.Text;
            DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            int i = 0;

            if (id == 0)
            {
                i = Convert.ToInt32(admin.DisplayDeliveyBoyByMobile(mobile).Rows.Count.ToString());
            }
            else
            {
                i = Convert.ToInt32(admin.DisplayDeliveyBoyByMobileAndId(mobile, id).Rows.Count.ToString());
            }


            if (i > 0)
            {
                error.Style.Add("display", "block");
            }
            else
            {
                if (id == 0)
                {
                    admin.InsertDeliveyBoy(name, mobile, password, added_on);
                    Response.Redirect("delivery_boy.aspx");
                }
                else
                {
                    //admin.UpdateDeliveyBoy(name, mobile, password, id);
                    Response.Redirect("delivery_boy.aspx");
                }
            }
        }
    }
}