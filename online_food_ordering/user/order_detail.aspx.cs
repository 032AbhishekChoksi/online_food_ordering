﻿using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class order_detail : System.Web.UI.Page
    {
        private int oid = 0;
        protected Dictionary<string, string> getOrderById;
        private Order_MasterBL order_MasterBL;
        protected Dictionary<int, Dictionary<string, string>> getOrderDetails;
        private Order_DetailBL order_DetailBL;
        private RatingBL ratingBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            order_MasterBL = new Order_MasterBL();
            order_DetailBL = new Order_DetailBL();
            ratingBL = new RatingBL();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Order Details | Billy";
            if (Session["FOOD_USER_ID"] == null)
            {
                Response.Redirect("shop");
            }
            if (Request.QueryString["id"] != null)
            {
                oid = Convert.ToInt32(Request.QueryString["id"]);
                
                Order_Master order_Master = new Order_Master();
                order_Master.SetId(oid);
                getOrderById = order_MasterBL.GetOrderByIdFunction(order_Master);
             
                int orderstatus  = Convert.ToInt32(getOrderById["order_status"]);
                if (orderstatus != 5)
                { 
                    if (orderstatus == 1)
                    {
                        FoodPending.Attributes.Add("class", "step active");
                    }
                    else if (orderstatus == 2)
                    {
                        FoodPending.Attributes.Add("class", "step active");
                        FoodCooking.Attributes.Add("class", "step active");
                    }
                    else if (orderstatus == 3)
                    {
                        FoodPending.Attributes.Add("class", "step active");
                        FoodCooking.Attributes.Add("class", "step active");
                        FoodOnTheWay.Attributes.Add("class", "step active");
                    }
                    else if (orderstatus == 4)
                    {
                        FoodPending.Attributes.Add("class", "step active");
                        FoodCooking.Attributes.Add("class", "step active");
                        FoodOnTheWay.Attributes.Add("class", "step active");
                        FoodDelivered.Attributes.Add("class", "step active");
                    }
                }
                if (Convert.ToInt32(getOrderById["user_id"]) != Convert.ToInt32(Session["FOOD_USER_ID"]))
                {
                    Response.Redirect("shop");
                }
            }
            else
            {
                Response.Redirect("shop");
            }
           
            Order_Master orderMaster = new Order_Master();
            orderMaster.SetId(oid);
            getOrderDetails = order_DetailBL.getOrderDetails(orderMaster);
        }
        protected string DisplayRating(object p_ostatus,object p_ddid)
        {
            string html = string.Empty;
            int order_status = Convert.ToInt32(p_ostatus);
            if(order_status == 4)
            { 
                int ddid = Convert.ToInt32(p_ddid);
                Order_Detail order_Detail = new Order_Detail();
                order_Detail.SetDishDetailId(ddid);
                order_Detail.SetOrderId(oid);

                html = ratingBL.getRating(order_Detail);
            }
            return html;
        }
    }
}