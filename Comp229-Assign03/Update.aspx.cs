using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Comp229_Assign03
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Comp229Assign03;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                displayinfo();
            }
        }
    private void displayinfo() {
            studID.Text = Session["sidd"].ToString();
            studName.Text = Session["sname"].ToString();
            studDate.Text = Session["sdate"].ToString();
        }

        protected void Cancelbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void Updatebtn_Click(object sender, EventArgs e)
        {
            int StudentID = Convert.ToInt32(Session["selectdSI"].ToString());            
            SqlCommand comm = new SqlCommand("UPDATE [Students] SET LastName=@LastName,FirstMidName=@FirstName,EnrollmentDate=@EnrollmentDate WHERE StudentID=@StudentID", connect);
            SqlDataReader reader;
            comm.Parameters.AddWithValue("@LastName", lastN.Text);
            comm.Parameters.AddWithValue("@FirstName", firstN.Text);
            comm.Parameters.AddWithValue("@EnrollmentDate", eDate.Text);
            comm.Parameters.AddWithValue("@StudentID", StudentID);
            try
            {
                connect.Open();
                reader = comm.ExecuteReader();
                reader.Close();
            }
            finally
            {
                connect.Close();
                Response.Redirect("Home.aspx");
            }
        }
    }
}