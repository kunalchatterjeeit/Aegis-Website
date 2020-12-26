using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aegis.Admin
{
    public partial class Product : System.Web.UI.Page
    {
        public int ProductId
        {
            get { return Convert.ToInt32(ViewState["ProductId"]); }
            set { ViewState["ProductId"] = value; }
        }

        private void Product_GetById()
        {
            Aegis.Model.Product model = new DataAccess.Product().Product_GetById(ProductId);
            if (model != null)
            {
                ddlProductCategory.SelectedValue = model.ProductCategoryId.ToString();
                txtName.Text = model.Name;
                txtSeoUrl.Text = model.SeoUrl;
            }
        }

        private void LoadCategoryList()
        {
            List<Model.ProductCategory> categories = new DataAccess.ProductCategory().ProductCategory_GetAll();
            if (categories != null)
            {
                ddlProductCategory.DataSource = categories;
                ddlProductCategory.DataTextField = "Name";
                ddlProductCategory.DataValueField = "Id";
                ddlProductCategory.DataBind();
            }
            ddlProductCategory.Items.Insert(0, "--Select--");
        }

        private void LoadProduct()
        {
            Aegis.DataAccess.Product objProduct = new Aegis.DataAccess.Product();
            List<Aegis.Model.Product> productCategories = objProduct.Product_GetAll();
            gvCategory.DataSource = productCategories;
            gvCategory.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null)
                Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                LoadCategoryList();
                LoadProduct();
            }
        }

        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                ProductId = Convert.ToInt32(e.CommandArgument.ToString());
                Product_GetById();
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int rowsAffected = new DataAccess.Product().Product_Delete(Convert.ToInt32(e.CommandArgument.ToString()));

                if (rowsAffected > 0)
                {
                    ClearControls();
                    LoadProduct();
                }
            }
            else if (e.CommandName == "Feature")
            {
                ProductId = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("ProductFeature.aspx?id=" + ProductId);
            }
            else if (e.CommandName == "Display")
            {
                ProductId = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("ProductPhoto.aspx?id=" + ProductId);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Aegis.Model.Product model = new Model.Product()
            {
                Id = ProductId,
                Name = txtName.Text,
                SeoUrl = txtSeoUrl.Text,
                ProductCategoryId = Convert.ToInt32(ddlProductCategory.SelectedValue)
            };

            int RowsAffected = new DataAccess.Product().Product_Save(model);

            if (RowsAffected > 0)
            {
                ClearControls();
                btnSave.Text = "Save";
                LoadProduct();
            }
        }

        private void ClearControls()
        {
            ProductId = 0;
            txtName.Text = string.Empty;
            ddlProductCategory.SelectedIndex = 0;
            txtSeoUrl.Text = string.Empty;
        }
    }
}