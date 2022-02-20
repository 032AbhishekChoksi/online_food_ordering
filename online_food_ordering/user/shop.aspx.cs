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
        public int DDID;
        protected Dictionary<int, Dictionary<string, string>> cartArr;
        private ClassFunction classFunction;
        protected void Page_Init(object sender, EventArgs e)
        {
            dishBL = new DishBL();
            dish_DetailsBL = new Dish_DetailsBL();
            classFunction = new ClassFunction();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            user mp = (user)Page.Master;
            cartArr = classFunction.getUserFullCart();

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

        public string displayAddedMessage(object DDID)
        {
            string message = string.Empty;
            if (cartArr != null) { 
                int id = Convert.ToInt32(DDID);
                if (cartArr.ContainsKey(id))
                {
                    int added_qty = Convert.ToInt32(cartArr[id]["qty"]);
                    message = "(Added - " + added_qty + ")";
                }
            }
            return message;
        }
        public string Radiochecked(object DDID)
        {
            string message = string.Empty;
            if (cartArr != null)
            {
                int id = Convert.ToInt32(DDID);
                if (cartArr.ContainsKey(id))
                {
                    message = " checked ";
                }
            }
            return message;
        }
        public string QtySelected(object DDID)
        {
            string message = string.Empty;
            if (cartArr != null)
            {
                int id = Convert.ToInt32(DDID);
                if (cartArr.ContainsKey(id))
                {
                    message = " selected ";
                }
            }
            return message;
        }
    }
}