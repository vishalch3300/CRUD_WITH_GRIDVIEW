using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Xml.Linq;

namespace CRUD_WITH_GRIDVIEW
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        //string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9371I5C\\SQL2019EXPRESS;Initial Catalog=ado_db;Persist Security Info=True;User ID=sa;Password=SqlAdmin%123;Trusted_Connection=True");

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        void Display()
        {
            //SqlConnection webcon = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Student", con);
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        void Cleartxt()
        {
            idTextBox.Text = string.Empty;
            nameTextBox.Text = string.Empty;
            genderTextBox.Text = string.Empty;
            ageTextBox.Text = string.Empty;
            classTextBox.Text = string.Empty;
        }

        protected void loadButton_Click(object sender, EventArgs e)
        {
            Display();
            Label6.Visible = true;
            Label6.Text = "Record Load Successfully...";
            Label6.Font.Bold = true;
            Label6.ForeColor = Color.Green;
            Label6.Font.Size = FontUnit.Large;
        }

        protected void insertButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && genderTextBox.Text != "" && ageTextBox.Text != "" && classTextBox.Text != "")
            {
                con.Open();
                string str = "insert into Student values('" + nameTextBox.Text + "','" + genderTextBox.Text + "','" + ageTextBox.Text + "','" + classTextBox.Text + "')";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                Label6.Visible = true;
                Label6.Text = "Record Inserted Successfully...";
                Label6.Font.Bold = true;
                Label6.ForeColor = Color.Green;
                Label6.Font.Size = FontUnit.Large;
                con.Close();
                Display();
                Cleartxt();
            }
        }

        protected void sbyidButton_Click(object sender, EventArgs e)
        {
            if (sidTextBox.Text != string.Empty)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Student where Id = '" + int.Parse(sidTextBox.Text) + "'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
            }
        }

        protected void getButton_Click(object sender, EventArgs e)
        {
            if (sidTextBox.Text != string.Empty)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Student where Id = '" + int.Parse(sidTextBox.Text) + "'", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    idTextBox.Text = sdr["ID"].ToString();
                    nameTextBox.Text = sdr["Name"].ToString();
                    genderTextBox.Text = sdr["Gender"].ToString();
                    ageTextBox.Text = sdr["Age"].ToString();
                    classTextBox.Text = sdr["Class"].ToString();
                }
                con.Close();
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && genderTextBox.Text != "" && ageTextBox.Text != "" && classTextBox.Text != "")
            {
                con.Open();
                string str = "update Student set Name='" + nameTextBox.Text + "',Gender='" + genderTextBox.Text + "',Age='" + ageTextBox.Text + "',Class='" + classTextBox.Text + "' where Id='" + idTextBox.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                Label6.Visible = true;
                Label6.Text = "Record Updated Successfully";
                Label6.Font.Bold = true;
                Label6.ForeColor = Color.Green;
                Label6.Font.Size = FontUnit.Large;
                con.Close();
                Display();
                Cleartxt();
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            if (sidTextBox.Text != string.Empty)
            {
                con.Open();
                string str = "delete from Student where Id='" + idTextBox.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                Label6.Visible = true;
                Label6.Text = "Record Deleted Successfully...";
                Label6.Font.Bold = true;
                Label6.ForeColor = Color.Green;
                Label6.Font.Size = FontUnit.Large;
                con.Close();
                Display();
                Cleartxt();
            }
        }
    }
}