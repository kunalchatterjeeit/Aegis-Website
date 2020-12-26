using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aegis.Admin
{
    public partial class ProductFeature : Page
    {
        public int ProductFeatureId
        {
            get { return Convert.ToInt32(ViewState["ProductFeatureId"]); }
            set { ViewState["ProductFeatureId"] = value; }
        }

        private void ProductFeature_GetById()
        {
            Aegis.Model.ProductFeature model = new DataAccess.ProductFeature().ProductFeature_GetById(ProductFeatureId);
            if (model != null)
            {
                txtFeatureName.Text = model.Name;
                txtDescription.Text = model.Description;
            }
        }

        private void LoadProductFeature()
        {
            Aegis.DataAccess.ProductFeature objProductFeature = new Aegis.DataAccess.ProductFeature();
            List<Aegis.Model.ProductFeature> productCategories = objProductFeature.ProductFeature_GetByProductId(Convert.ToInt32(Request.QueryString["id"].ToString()));
            gvFeature.DataSource = productCategories;
            gvFeature.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null)
                Response.Redirect("Default.aspx");

            if (string.IsNullOrEmpty(Request.QueryString["id"]))
                Response.Redirect("Product.aspx");
            if (!IsPostBack)
                LoadProductFeature();
        }

        protected void gvFeature_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                ProductFeatureId = Convert.ToInt32(e.CommandArgument.ToString());
                ProductFeature_GetById();
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int rowsAffected = new DataAccess.ProductFeature().ProductFeature_Delete(Convert.ToInt32(e.CommandArgument.ToString()));

                if (rowsAffected > 0)
                {
                    ClearControls();
                    LoadProductFeature();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Aegis.Model.ProductFeature model = new Model.ProductFeature()
            {
                Id = ProductFeatureId,
                Name = txtFeatureName.Text,
                Description = txtDescription.Text,
                ProductId = Convert.ToInt32(Request.QueryString["id"].ToString())
            };

            int RowsAffected = new DataAccess.ProductFeature().ProductFeature_Save(model);

            if (RowsAffected > 0)
            {
                ClearControls();
                btnSave.Text = "Save";
                LoadProductFeature();
            }
        }

        private void ClearControls()
        {
            ProductFeatureId = 0;
            txtFeatureName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}