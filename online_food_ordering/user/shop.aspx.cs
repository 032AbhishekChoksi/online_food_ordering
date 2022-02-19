using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class shop : System.Web.UI.Page
    {
        private DishBL dishBL;
        private Dish_DetailsBL dish_DetailsBL;
        private int did;
        protected void Page_Init(object sender, EventArgs e)
        {
            dishBL = new DishBL();
            dish_DetailsBL = new Dish_DetailsBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Shop | Billy";
            FillDishCategory();
        }
        private void FillDishCategory()
        {
            rDishCategory.DataSource = dishBL.DisplayDishCategory();
            rDishCategory.DataBind();
        }

        protected void rDishCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            did = Convert.ToInt32((e.Item.FindControl("hdid") as HiddenField).Value);
            Repeater rDishDetails = e.Item.FindControl("rDishDetails") as Repeater;
            Dish dish = new Dish();
            dish.SetId(did);
            rDishDetails.DataSource = dish_DetailsBL.DisplayDishDetailsByDid(dish);
            rDishDetails.DataBind();
        }
    }
}