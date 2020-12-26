using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aegis.Admin
{
    public partial class ProductPhoto : System.Web.UI.Page
    {
        public int ProductDisplayId
        {
            get { return Convert.ToInt32(ViewState["ProductDisplayId"]); }
            set { ViewState["ProductDisplayId"] = value; }
        }

        private void ProductDisplay_GetById()
        {
            Aegis.Model.ProductDisplay model = new DataAccess.ProductDisplay().ProductDisplay_GetById(ProductDisplayId);
            if (model != null)
            {
                txtImageName.Text = model.Name;
            }
        }

        private void LoadProductDisplay()
        {
            Aegis.DataAccess.ProductDisplay objProductDisplay = new Aegis.DataAccess.ProductDisplay();
            List<Aegis.Model.ProductDisplay> productCategories = objProductDisplay.ProductDisplay_GetByProductId(Convert.ToInt32(Request.QueryString["id"].ToString()));
            gvImage.DataSource = productCategories;
            gvImage.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null)
                Response.Redirect("Default.aspx");

            if (string.IsNullOrEmpty(Request.QueryString["id"]))
                Response.Redirect("Product.aspx");
            if (!IsPostBack)
                LoadProductDisplay();
        }

        private Model.Product Product_GetById(int productId)
        {
            Aegis.Model.Product model = new DataAccess.Product().Product_GetById(productId);
            return model;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Model.Product productModel = Product_GetById(Convert.ToInt32(Request.QueryString["id"].ToString()));
            string filename = DateTime.Now.Ticks + "-" + productModel.SeoUrl + System.IO.Path.GetExtension(FileUploadImage.FileName);
            if (FileUploadImage.HasFile)
                FileUploadImage.PostedFile.SaveAs(Server.MapPath(" ") + @"\ProductImage\" + filename);

            Aegis.Model.ProductDisplay model = new Model.ProductDisplay()
            {
                Id = ProductDisplayId,
                Name = txtImageName.Text,
                ContentTypeId = 1,
                ContentPath = filename,
                ProductId = Convert.ToInt32(Request.QueryString["id"].ToString())
            };

            int RowsAffected = new DataAccess.ProductDisplay().ProductDisplay_Save(model);

            if (RowsAffected > 0)
            {
                ClearControls();
                btnSave.Text = "Save";
                LoadProductDisplay();
            }
        }

        private void ClearControls()
        {
            ProductDisplayId = 0;
            txtImageName.Text = string.Empty;
        }

        protected void gvImage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                ProductDisplayId = Convert.ToInt32(e.CommandArgument.ToString());
                ProductDisplay_GetById();
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int rowsAffected = new DataAccess.ProductDisplay().ProductDisplay_Delete(Convert.ToInt32(e.CommandArgument.ToString()));

                if (rowsAffected > 0)
                {
                    ClearControls();
                    LoadProductDisplay();
                }
            }
        }
    }
}