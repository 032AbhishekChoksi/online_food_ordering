using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace online_food_ordering.admin
{
    public partial class manage_dish : System.Web.UI.Page
    {

        ClassAdmin admin = new ClassAdmin();
        int id = 0;
        int dish_details_id = 0;
        public int noofdishdetails = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Manage Dish | Billy Admin Panel";
           
            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login.aspx");
            }
            
            if (!IsPostBack)
            {
                ddtcategory_id.DataSource = admin.DisplayCategoryByStatus();
                ddtcategory_id.DataTextField = "category";
                ddtcategory_id.DataValueField = "id";
                ddtcategory_id.DataBind();
            }

            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
            }

            if(Request.QueryString["dish_details_id"] != null)
            {
                dish_details_id = Convert.ToInt32(Request.QueryString["dish_details_id"]);
            }
            if (IsPostBack) return;
            if (id > 0)
            {
                foreach (DataRow dr in admin.DisplayDishById(id).Rows)
                {
                    ddtcategory_id.ClearSelection();
                    ddtcategory_id.Items.FindByValue(dr["category_id"].ToString()).Selected = true;
                    txtdish.Text = dr["dish_name"].ToString();
                    txtdish_detail.Text = dr["dish_desc"].ToString();
                    ddttype.ClearSelection();
                    string value = dr["type"].ToString().Trim(' ');
                    ddttype.Items.FindByValue(value).Selected = true;
                }

                r1.DataSource = admin.DisplayDishDetailsByDishID(id);
                r1.DataBind();
                noofdishdetails = admin.DisplayDishDetailsByDishID(id).Rows.Count;
            }

            if(id > 0 && dish_details_id > 0)
            {
                admin.RemoveDishDetails(dish_details_id);
                Response.Redirect("manage_dish.aspx?id=" + id);
            }


        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            
            // Dish Added
            int lastinsertedid = 0;
            int category_id = Convert.ToInt32(ddtcategory_id.SelectedItem.Value);
            string dish_name = txtdish.Text;
            string dish_desc = txtdish_detail.Text;
            string type = ddttype.SelectedItem.Value.ToString();
            DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            string imagename = string.Empty;
            int ii = 0;

            if (id == 0)
            {
                ii = Convert.ToInt32(admin.DisplayDishByName(dish_name).Rows.Count.ToString());
            }
            else
            {
                ii = Convert.ToInt32(admin.DisplayDishByNameAndId(dish_name, id).Rows.Count.ToString());
            }

            if (ii > 0)
            {
                error.Style.Add("display", "block");
            }
            else
            {
                bool isimage_error = false;
                // Image File Type Validation
                
                if (id == 0)
                {
                    string[] validFileTypes = { "png", "jpg", "jpeg" };
                    string ext = System.IO.Path.GetExtension(f1.PostedFile.FileName);
                    bool isValidFile = false;
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isValidFile = true;
                            break;
                        }
                    }
                    if (!isValidFile)
                    {
                        Label1.Text = "Invalid File. Please upload a File with extension " + string.Join(", ", validFileTypes);
                        isimage_error = true;
                    }
                    else
                    {
                        isimage_error = false;
                    }

                    if (isimage_error == false)
                    {
                        /*Insert Record in The Dish and Dish Details Table*/
                        imagename = String.Empty;
                        imagename = ClassRandom.GetRandomPassword(9) + "_" + Path.GetFileName(f1.FileName);
                        f1.SaveAs(Request.PhysicalApplicationPath + "/media/dish/" + imagename.ToString());

                        lastinsertedid = admin.InsertionDish(category_id, dish_name, dish_desc, imagename, type, added_on);

                        // Dish Details Added 
                        string[] attributeValues = Request.Form.GetValues("attribute");
                        string[] priceValues = Request.Form.GetValues("price");
                        string[] statusValues = Request.Form.GetValues("status");

                        for (int i = 0; i < attributeValues.Length; i++)
                        {
                            string attribute = attributeValues[i];
                            int price = Convert.ToInt32(priceValues[i]);
                            byte status = Convert.ToByte(statusValues[i]);

                            admin.InsertionDishDetails(lastinsertedid, attribute, price, status, added_on);
                        }

                        Response.Redirect("dish.aspx");
                    }
                }
                else
                {
                    bool image_condition = false;

                    if (Path.GetFileName(f1.FileName) != "")
                    {
                        // Image File Type Validation
                        string[] validFileTypes = { "png", "jpg", "jpeg" };
                        string ext = System.IO.Path.GetExtension(f1.PostedFile.FileName);
                        bool isValidFile = false;
                        for (int i = 0; i < validFileTypes.Length; i++)
                        {
                            if (ext == "." + validFileTypes[i])
                            {
                                isValidFile = true;
                                break;
                            }
                        }
                        if (!isValidFile)
                        {                            
                            Label1.Text = "Invalid File. Please upload a File with extension " + string.Join(", ", validFileTypes);
                            isimage_error = true;
                        }
                        else
                        {
                            isimage_error = false;
                        }

                        if (isimage_error == false)
                        {
                            imagename = String.Empty;
                            imagename = ClassRandom.GetRandomPassword(9) + "_" + Path.GetFileName(f1.FileName);
                            f1.SaveAs(Request.PhysicalApplicationPath + "/media/dish/" + imagename.ToString());

                            image_condition = true;

                            string oldImage = admin.DisplayDishImage(id);

                            string filePath = Request.PhysicalApplicationPath + "/media/dish/" + oldImage;
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                            }
                        }
                    }

                    if (isimage_error == false)
                    {

                        /* Update Record in The Dish and Dish Details Table */
                        if (image_condition == true)

                        {
                            admin.UpdateDishImage(id, category_id, dish_name, dish_desc, imagename, type);
                        }
                        else
                        {
                            admin.UpdateDish(id, category_id, dish_name, dish_desc, type);
                        }
                      
                        // Dish Detail Update
                        string[] attributeValues = Request.Form.GetValues("attribute");
                        string[] priceValues = Request.Form.GetValues("price");
                        string[] statusValues = Request.Form.GetValues("status");

                        for (int i = 0; i < attributeValues.Length; i++)
                        {
                            string attribute = attributeValues[i];
                            int price = Convert.ToInt32(priceValues[i]);
                            byte status = Convert.ToByte(statusValues[i]);
                            string[] dishDetailsIdArr = Request.Form.GetValues("dish_details_id");
                            
                            if (Convert.ToInt32(dishDetailsIdArr[i]) != 0)
                            {
                                int did = Convert.ToInt32(dishDetailsIdArr[i]);
                                admin.UpdateDishDetails(did, attribute, price, status);
                            }
                            else
                            {
                                admin.InsertionDishDetails(id,attribute, price, status, added_on);
                            }
                            
                        }

                        Response.Redirect("dish.aspx");
                    }
                }
            }

        }

    }
}