﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class banner : System.Web.UI.Page
    {
        ClassAdmin admin = new ClassAdmin();
        int id = 0;
        byte status = 1;
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Banner | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }

            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                type = Request.QueryString["type"].ToString();
            }

            if (IsPostBack) return;

            if (id > 0 && type == "delete")
            {
                admin.RemoveBanner(id);
                Response.Redirect("banner");
            }

            if (id > 0 && type == "deactive")
            {
                status = 0;
                admin.UpdateBannerStatus(id, status);
                Response.Redirect("banner");
            }
            else if (id > 0 && type == "active")
            {
                status = 1;
                admin.UpdateBannerStatus(id, status);
                Response.Redirect("banner");
            }
            r1.DataSource = admin.DisplayBanner();
            r1.DataBind();
        }
    }
}