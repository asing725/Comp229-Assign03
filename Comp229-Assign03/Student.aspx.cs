using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03
{
    public partial class WebForm2 : System.Web.UI.Page
    {
    private SqlConnection connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Comp229Assign03;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Readdetail();
            }
        }
        private void Readdetail()
        {
            string studentID = Session["selectdSI"] as string;         
            SqlCommand comnd = new SqlCommand("Select * from Students " +
                "where Students.StudentID = @StudentID;", connect);
            comnd.Parameters.AddWithValue("@StudentID", studentID);
            try
            {
                connect.Open();
                SqlDataReader reader = comnd.ExecuteReader();
                reader.Read();
                    studName.Text = reader["FirstMidName"] + " " + reader["LastName"];
                    studID.Text = reader["StudentID"] + "";
                    studDate.Text = reader["EnrollmentDate"] + "";
                    Session["sname"] = studName.Text;
                    Session["sidd"] = studID.Text;
                    Session["sdate"] = studDate.Text;               
                    reader.Close();
                    SqlCommand comndnew = new SqlCommand("SELECT * FROM dbo.Courses " + "INNER JOIN dbo.Enrollments ON dbo.Courses.CourseID = dbo.Enrollments.CourseID " + "WHERE dbo.Enrollments.StudentID = @StudentID;", connect);
                    comndnew.Parameters.AddWithValue("@StudentID", studentID);
                    reader = comndnew.ExecuteReader();
                    course.DataSource = reader;
                    course.DataBind();
                    reader.Close();               
            }
            catch
            {
                Response.Write("Something went wrong !!");
            }
        }

        protected void CourseList(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "detail")
            {
                Session["courseID"] = e.CommandArgument.ToString();
               
                Response.Redirect("Courses.aspx");
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");
        }

        protected void del_Click(object sender, EventArgs e)
        {
            SqlCommand comnd = new SqlCommand("DELETE FROM Enrollments WHERE StudentID='" + studID.Text + "'" + "DELETE FROM Students WHERE StudentID = '" + studID.Text + "'", connect);
            try
            {
                connect.Open();
                comnd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}