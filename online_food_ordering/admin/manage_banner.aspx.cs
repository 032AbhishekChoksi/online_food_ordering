using online_food_ordering.bussinesslogic;
using online_food_ordering.model;
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
    public partial class manage_banner : System.Web.UI.Page
    {
        private BannerBL bannerBL;
        ClassAdmin admin = new ClassAdmin();
        private int id = 0;
        protected void Page_Init(object sender, EventArgs e)
        {
            bannerBL = new BannerBL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Manage Banner | Billy Admin Panel";

            if (Session["ADMIN_USER"] == null)
            {
                Response.Redirect("login");
            }

            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                if (IsPostBack) return;
                if (id > 0)
                {
                    FillData(id);
                }
            }            
        }

        protected void bttnsubmit_Click(object sender, EventArgs e)
        {
            string heading = txtheading.Text;
            string sub_heading = txtsub_heading.Text;
            string link = txtlink.Text;
            string link_text = txtlink_txt.Text;
            int banner_order = Convert.ToInt32(txtbannerorder.Text);
            DateTime added_on = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            bool isimage_error = false;

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
                    lblerror.Text = "Invalid File. Please upload a File with extension " + string.Join(", ", validFileTypes);
                    isimage_error = true;
                }
                else
                {
                    isimage_error = false;
                }
                // Banner Added in The Table
                if (isimage_error == false)
                {
                    string imagename = string.Empty;
                    imagename = ClassRandom.GetRandomPassword(9) + "_" + Path.GetFileName(f1.FileName);
                    f1.SaveAs(Request.PhysicalApplicationPath + "/media/banner/" + imagename.ToString());

                    admin.InsertBanner(imagename,heading,sub_heading,link,link_text,banner_order,added_on);
                    Response.Redirect("banner");
                }
            }
            else
            {
                bool image_condition = false;
                string imagename = string.Empty;
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
                        lblerror.Text = "Invalid File. Please upload a File with extension " + string.Join(", ", validFileTypes);
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
                        f1.SaveAs(Request.PhysicalApplicationPath + "/media/banner/" + imagename.ToString());

                        image_condition = true;

                        string oldImage = admin.DisplayBannerImage(id);

                        string filePath = Request.PhysicalApplicationPath + "/media/banner/" + oldImage;
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }
                }

                /* Update Record in The Banner Table */
                if (image_condition == true)

                {
                    admin.UpdateBannerImage(id, imagename, heading, sub_heading, link, link_text, banner_order);
                    Response.Redirect("banner");
                }
                else
                {
                    admin.UpdateBanner(id, heading, sub_heading, link, link_text, banner_order);
                    Response.Redirect("banner");
                }
                
                
            }
        }
        private void FillData(int p_id)
        {
            Banner banner = new Banner();
            banner.SetId(p_id);

            foreach (DataRow dr in bannerBL.DisplayBannerById(banner).Rows)
            {
                txtheading.Text = dr["heading"].ToString();
                txtsub_heading.Text = dr["sub_heading"].ToString();
                txtlink.Text = dr["link"].ToString();
                txtlink_txt.Text = dr["link_text"].ToString();
                txtbannerorder.Text = dr["banner_order"].ToString();
            }
        }
    }
}