using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Comp229_Assign03
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SqlConnection connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Comp229Assign03;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReadStudent();
            }
        }
        private void ReadStudent()
        {
            SqlCommand comm = new SqlCommand("Select * from Students;", connect);
            connect.Open();
            SqlDataReader reader = comm.ExecuteReader();
            StudName.DataSource = reader;
            StudName.DataBind();
            connect.Close();
        }
        protected void Studentlst(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "details")
            {
                Session["selectdSI"] = e.CommandArgument.ToString();
                Response.Redirect("Student.aspx");
            }
        }
        protected void StudAdd_click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand comm = new SqlCommand("INSERT INTO Students (LastName, FirstMidName, EnrollmentDate) " +
                    "VALUES(@fmname, @lname, @newEnrollment); ", connect);
                comm.Parameters.AddWithValue("@fmname", studfname.Text);
                comm.Parameters.AddWithValue("@lname", studlname.Text);
                comm.Parameters.AddWithValue("@newEnrollment", Convert.ToDateTime(studedate.Text));
                try
                {
                    connect.Open();
                    comm.ExecuteNonQuery();
                    disperror.Text = "New student Added !";
                    studfname.Text = "";
                    studlname.Text = "";
                    studedate.Text = "";
                }
                catch (SqlException expsql)
                {
                    disperror.Text = expsql.Message;
                }
                finally
                {
                    connect.Close();
                    ReadStudent();
                }
            }
            catch (Exception exp)
            {
                disperror.Text = exp.Message;
            }
        }
    }
}
    