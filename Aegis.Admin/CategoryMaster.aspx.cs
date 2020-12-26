using Aegis.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aegis.Admin
{
    public partial class CategoryMaster : System.Web.UI.Page
    {
        public int ProductCategoryId
        {
            get { return Convert.ToInt32(ViewState["ProductCategoryId"]); }
            set { ViewState["ProductCategoryId"] = value; }
        }

        private void LoadTypeList()
        {
            List<Model.ProductType> productTypies = new DataAccess.ProductType().ProductType_GetAll();
            if (productTypies != null)
            {
                ddlProductType.DataSource = productTypies;
                ddlProductType.DataTextField = "Name";
                ddlProductType.DataValueField = "Id";
                ddlProductType.DataBind();
            }
            ddlProductType.Items.Insert(0, "--Select--");
        }

        private void ProductCategory_GetById()
        {
            Aegis.Model.ProductCategory model = new ProductCategory().ProductCategory_GetById(ProductCategoryId);
            if (model != null)
            {
                txtProductCategoryName.Text = model.Name;
                txtDescription.Text = model.Description;
                txtSeoUrl.Text = model.SeoUrl;
                ddlProductType.SelectedValue = model.ProductTypeId.ToString();
            }
        }

        private void LoadProductCategory()
        {
            Aegis.DataAccess.ProductCategory objProductCategory = new Aegis.DataAccess.ProductCategory();
            List<Aegis.Model.ProductCategory> productCategories = objProductCategory.ProductCategory_GetAll();
            gvCategory.DataSource = productCategories;
            gvCategory.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null)
                Response.Redirect("Default.aspx");

            if (!IsPostBack)
            {
                LoadProductCategory();
                LoadTypeList();
            }
        }

        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                ProductCategoryId = Convert.ToInt32(e.CommandArgument.ToString());
                ProductCategory_GetById();
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int rowsAffected = new ProductCategory().ProductCategory_Delete(Convert.ToInt32(e.CommandArgument.ToString()));

                if (rowsAffected > 0)
                {
                    ClearControls();
                    LoadProductCategory();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Aegis.Model.ProductCategory model = new Model.ProductCategory()
            {
                Id = ProductCategoryId,
                Name = txtProductCategoryName.Text,
                Description = txtDescription.Text,
                SeoUrl = txtSeoUrl.Text,
                ProductTypeId = Convert.ToInt32(ddlProductType.SelectedValue)
            };

            int RowsAffected = new ProductCategory().ProductCategory_Save(model);

            if (RowsAffected > 0)
            {
                ClearControls();
                btnSave.Text = "Save";
                LoadProductCategory();
            }
        }

        private void ClearControls()
        {
            ProductCategoryId = 0;
            txtProductCategoryName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtSeoUrl.Text = string.Empty;
        }
    }
}