using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.user
{
    public partial class manage_cart : System.Web.UI.Page
    {
        private Dish_DetailsBL dish_DetailsBL;
        private Dish_Details dish_Details;
        private ClassFunction classFunction;
      
        protected void Page_Init(object sender, EventArgs e)
        {
            dish_DetailsBL = new Dish_DetailsBL();
            classFunction = new ClassFunction();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var js = new JavaScriptSerializer();
            string json = null;
            string type = string.Empty;
            int attr = 0;
            int qty = 0;
           
            if (Request.Form["attr"] != null)
            {
                attr = Convert.ToInt32(Request.Form["attr"]);
            }
            
            if (Request.Form["type"] != null)
            {
                type = Request.Form["type"].ToString();
            }
           
            if (Request.Form["qty"] != null)
            {
                qty = Convert.ToInt32(Request.Form["qty"]);
            }
           
            if (type.Equals("add"))
            {
                if (Session["FOOD_USER_ID"] != null)
                {
                    int uid = Convert.ToInt32(Session["FOOD_USER_ID"]);
                    classFunction.manageUserCart(uid, qty, attr);
                }
                else
                { 
                    //Session["cart"][attr]["qty"] = qty;
                    var arr1 = new Dictionary<string, string>();
                    arr1.Add("qty", qty.ToString());
                    var arr2 = new Dictionary<int, Dictionary<string, string>>();
                    arr2.Add(attr, arr1);

                    if (Session["cart"] == null)
                    {
                        Session["cart"] = arr2;
                    }
                    else
                    {
                        var arr3 = (Dictionary<int, Dictionary<string, string>>)Session["cart"];
                        bool keyExists = arr3.ContainsKey(attr);
                        if (keyExists)
                        { 
                            arr3.Remove(attr);
                        }
                        arr3.Add(attr, arr1);
                        Session["cart"] = arr3;
                    }
                    // End line of Session["cart"][attr]["qty"] = qty;
                }
                // Total Price Calculate
                var getUserFullCart = classFunction.getUserFullCart();
                int totalPrice = 0;
                foreach(int key in getUserFullCart.Keys) {
                    totalPrice = totalPrice + (Convert.ToInt32(getUserFullCart[key]["qty"]) * Convert.ToInt32(getUserFullCart[key]["price"]));
                }

                dish_Details = new Dish_Details();
                dish_Details.SetId(attr);
                int dishPrice = 0;
                string dishName = string.Empty;
                string dishImage = string.Empty;
                foreach (DataRow dr in dish_DetailsBL.DisplayDishAndDishDetailsByDDId(dish_Details).Rows)
                {
                    dishPrice = Convert.ToInt32(dr["dishPrice"]);
                    dishName = dr["dishName"].ToString();
                    dishImage = dr["dishImage"].ToString();
                }

                int totaDish = (classFunction.getUserFullCart()).Count;
                json = js.Serialize(new { totalCartDish = totaDish, totalPrice = totalPrice, price = dishPrice, dish = dishName, image = dishImage });
                Context.Response.Write(js.Serialize(json));
            }

            if (type.Equals("delete"))
            {
                classFunction.removeDishFromCartByid(attr);
                var getUserFullCart = classFunction.getUserFullCart();
                int totaDish = (classFunction.getUserFullCart()).Count;
                int totalPrice = 0;
                foreach (int key in getUserFullCart.Keys)
                {
                    totalPrice = totalPrice + (Convert.ToInt32(getUserFullCart[key]["qty"]) * Convert.ToInt32(getUserFullCart[key]["price"]));
                }
                json = js.Serialize(new { totalCartDish = totaDish, totalPrice = totalPrice });
                Context.Response.Write(js.Serialize(json));
            }
        }
    }
}