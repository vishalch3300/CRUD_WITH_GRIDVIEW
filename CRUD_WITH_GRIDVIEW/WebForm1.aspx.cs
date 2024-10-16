using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_WITH_GRIDVIEW
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["Name"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TextBox2")).Text;
            SqlDataSource1.InsertParameters["Gender"].DefaultValue = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).SelectedValue;
            SqlDataSource1.InsertParameters["Age"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TextBox4")).Text;
            SqlDataSource1.InsertParameters["Class"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("TextBox6")).Text;

            int a = SqlDataSource1.Insert();
            if (a > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Insertion Successfull !!')</script>");
            }
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Insertion Failed !!')</script>");
            }
        }
    }
}