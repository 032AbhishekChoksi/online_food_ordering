using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
using System;
using System.Collections.Generic;
using System.Data;
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
        private CategoryBL categoryBL;
        private Category category;
        public string[] cat_dish_arr;
        public string cat_dish;
        private string cat_dish_str;
        protected void Page_Init(object sender, EventArgs e)
        {
            dishBL = new DishBL();
            dish_DetailsBL = new Dish_DetailsBL();
            classFunction = new ClassFunction();
            categoryBL = new CategoryBL();
            category = new Category();
            cat_dish = string.Empty;
            cat_dish_str = string.Empty;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cat_dish"] != null)
            {
                cat_dish = Request.QueryString["cat_dish"].ToString();
                cat_dish_arr = cat_dish.Split(':');
                cat_dish_str = String.Join(",", cat_dish_arr);
            }
            
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
        public string[] categoryList()
        {
            //string cclass = string.Empty;
            category.SetStatus(1);
            int count = categoryBL.DisplayCategoryByStatusOrderById(category).Rows.Count;
            string[] code = new string[count];
            if (count > 0) {
                int i = 0;
                foreach(DataRow dr in categoryBL.DisplayCategoryByStatusOrderById(category).Rows)
                {
                    //if (Convert.ToInt32(dr["id"]).Equals(dr["id"]))
                    //{
                    //    cclass = "active";
                    //}
                    string is_checked = string.Empty;
                    string stringToCheck = dr["id"].ToString();
                    if(cat_dish_arr != null) { 
                        foreach (string value in cat_dish_arr)
                        {
                            if (stringToCheck.Equals(value))
                            {
                                is_checked = "checked='checked'";
                            }
                        }
                    }
                    code[i] = "<li> <input " + is_checked + " onclick=set_checkbox(" + dr["id"] + ") type='checkbox' name='cat_arr[]' value='" + dr["category"] + "' style='width:15px;height:12px;' />"+ dr["category"] + "</li>" ;
                    i++;
                }
            }
            return code;
        }
    }
}