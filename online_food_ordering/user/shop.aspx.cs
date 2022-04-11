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
        private string FilterCategory;
        private SettingBL settingBL;
        private DataTable dt = null;
        protected string websiteclose = string.Empty;
        protected string websiteclosemsg = string.Empty;
        private string[] arrType = new string[] { "veg", "non-veg", "both" };
        protected string dish_type = string.Empty;
        private string FilterDishType;
        private string dish_type_str = string.Empty;
        private RatingBL ratingBL;
        protected void Page_Init(object sender, EventArgs e)
        {
            dishBL = new DishBL();
            dish_DetailsBL = new Dish_DetailsBL();
            classFunction = new ClassFunction();
            categoryBL = new CategoryBL();
            category = new Category();
            cat_dish = string.Empty;
            cat_dish_str = string.Empty;
            settingBL = new SettingBL();
            ratingBL = new RatingBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Setting setting = new Setting();
            setting.SetId(1);
            setting = settingBL.DisplaySettingById(setting);
            if(setting != null)
            {
                websiteclose = setting.GetWebsiteClose();
                websiteclosemsg = setting.GetWebsiteCloseMsg();
            }

            lblNoRecords.Text = string.Empty;
            FilterCategory = string.Empty;
            if (Request.QueryString["cat_dish"] != null)
            {
                FilterCategory = "cat_dish";
                cat_dish = Request.QueryString["cat_dish"].ToString();
                cat_dish_arr = cat_dish.Split(':');
                cat_dish_str = String.Join(",", cat_dish_arr);
            }
            if (Request.QueryString["dish_type"] != null)
            {
                FilterDishType = "dish_type";
                dish_type = Request.QueryString["dish_type"].ToString();
            }

            cartArr = classFunction.getUserFullCart();
           
            Page.Title = "Shop | Billy";
            FillDishCategory();
        }
        private void FillDishCategory()
        {
            if (!string.IsNullOrEmpty(cat_dish_str))
            {
                cat_dish_str = cat_dish_str.Remove(0, 1);
            }
            else
            {
                FilterCategory = string.Empty;
            }
            if (!string.IsNullOrEmpty(dish_type))
            {
                if (dish_type.Equals("both"))
                {
                    FilterDishType = string.Empty;
                    dish_type_str = string.Empty;
                }
                else
                {
                    dish_type_str = dish_type;
                }
                
            }
            else
            {
                FilterDishType = string.Empty;
            }
          
            dt = dishBL.DisplayDishCategory(FilterCategory, cat_dish_str,FilterDishType, dish_type_str);
            
            if (dt.Rows.Count > 0)
            {
                rDishCategory.DataSource = dt;
                rDishCategory.DataBind();
            }
            else
            {
                lblNoRecords.Text = "No Dish Found";
            }
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
        protected string DisplayFoodType()
        {
            string code = string.Empty;
            for (int i = 0; i < arrType.Length; i++)
            {
                string type_radio_selected = string.Empty;
                if (dish_type.Equals(arrType[i]))
                {
                    type_radio_selected = "checked='checked'";
                }
                string strtoupper = char.ToUpper(arrType[i][0]) + arrType[i].Substring(1);
                code += strtoupper + "<input type='radio' name='dish_type' " + type_radio_selected + " value='"+ arrType[i] + "' style='width: 16px;height: 12px;margin-right: 5px;margin-left: 5px;' onclick=\"setFoodType('" + arrType[i] + "')\" />&nbsp;&nbsp ";
            }

            return code;
        }
        protected string DisplayRating(object p_did)
        {
            string html = string.Empty;
            int did = Convert.ToInt32(p_did);
            Dish dish = new Dish();
            dish.SetId(did);

            html = ratingBL.getRatingByDishId(dish);
            return html;
        }
    }
}