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
    public partial class cart : System.Web.UI.Page
    {
        private ClassFunction classFunction;
        private Dish_Cart dish_Cart;
        private Dish_CartBL dish_CartBL;
        protected Dictionary<int, Dictionary<string, string>> cartArr;
        protected void Page_Init(object sender, EventArgs e)
        {
            classFunction = new ClassFunction();
            dish_CartBL = new Dish_CartBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cartArr = classFunction.getUserFullCart();
            if (Request.Form["update_cart"] != null)
            {
                int count = cartArr.Count;
                int[] ddid = new int[count];
                int[] qty = new int[count];
                if (Request.Form.GetValues("hid") != null)
                {
                    ddid = Array.ConvertAll(Request.Form.GetValues("hid"), int.Parse);
                }
                if (Request.Form.GetValues("qty") != null) { 
                    qty = Array.ConvertAll(Request.Form.GetValues("qty"), int.Parse);
                }
                for(int i = 0; i < count; i++)
                {                    
                    if (Session["FOOD_USER_ID"] != null)
                    {
                        int uid = Convert.ToInt32(Session["FOOD_USER_ID"]);
                        dish_Cart = new Dish_Cart();                        
                        dish_Cart.SetQty(qty[i]);
                        dish_Cart.SetDishDetailId(ddid[i]);
                        dish_Cart.SetUserId(uid);
                        dish_CartBL.UpdateDishCartQtyByUid(dish_Cart);
                    }
                    else
                    {
                        //Session["cart"][attr]["qty"] = qty;
                        var arr1 = new Dictionary<string, string>();
                        arr1.Add("qty", qty[i].ToString());
                        var arr2 = new Dictionary<int, Dictionary<string, string>>();
                        arr2.Add(ddid[i], arr1);

                        if (Session["cart"] == null)
                        {
                            Session["cart"] = arr2;
                        }
                        else
                        {
                            var arr3 = (Dictionary<int, Dictionary<string, string>>)Session["cart"];
                            bool keyExists = arr3.ContainsKey(ddid[i]);
                            if (keyExists)
                            {
                                arr3.Remove(ddid[i]);
                            }
                            arr3.Add(ddid[i], arr1);
                            Session["cart"] = arr3;
                        }
                        // End line of Session["cart"][attr]["qty"] = qty;
                    }                    
                }
                Response.Redirect("cart");
            }
            
        }
    }
}