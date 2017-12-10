using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Comp229_Assign03
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        /*
         Adding student doesnt work and gives error about primary key
             */


        private SqlConnection connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Comp229Assign03;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Courseinfo();
            }
        }

        private void Courseinfo()
        {          
                SqlCommand comm = new SqlCommand("SELECT * FROM Students WHERE StudentID IN (SELECT StudentID FROM Enrollments WHERE CourseID=@CourseID)", connect);
                comm.Parameters.AddWithValue("@courseID", Int32.Parse(Session["courseID"].ToString()));
             
                try
                {
                    connect.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    studlst.DataSource = reader;
                    studlst.DataBind();
                    reader.Close();             
                }
                catch (Exception exp)
                {
                    dispError.Text = exp.Message;
                }
                finally
                {
                    connect.Close();
                }
            }
        
           
        protected void Studdel(object sender, GridViewDeleteEventArgs e)
        {
                SqlCommand commnd = new SqlCommand("DELETE FROM Enrollments WHERE StudentID = @studentID and CourseID = @courseID;", connect);
                commnd.Parameters.AddWithValue("@courseID", Int32.Parse(Session["courseID"].ToString()));
                commnd.Parameters.AddWithValue("@studentID", Int32.Parse(studlst.DataKeys[e.RowIndex].Values[0].ToString()));
                try
                {
                    connect.Open();
                    commnd.ExecuteNonQuery();
                }
                catch (SqlException error)
                {
                    dispError.Text = error.Message;
                }
                finally
                {
                    connect.Close();
                    Courseinfo();
                }          
        }

        protected void Addbtn_Click(object sender, EventArgs e)
        {
            SqlCommand commnd = new SqlCommand(" INSERT INTO [dbo].Enrollments(CourseID, StudentID, Grade)  " + "VALUES (@courseID,@studentID, @grade );", connect);
            commnd.Parameters.AddWithValue("@grade", Int32.Parse(grd.Text));
            commnd.Parameters.AddWithValue("@studentID", Int32.Parse(studID.Text));
            commnd.Parameters.AddWithValue("@courseID", Int32.Parse(Session["courseID"].ToString()));
            commnd.Parameters.AddWithValue("@Firstname", Convert.ToString(frstname.Text));
            commnd.Parameters.AddWithValue("@Lastname", Convert.ToString(lstname.Text));
            commnd.Parameters.AddWithValue("@EDate", Convert.ToDateTime(edate.Text));
            try
            {
                connect.Open();
                commnd.ExecuteNonQuery();
                dispError.Text = "ADDED !!";
            }
            catch (SqlException error)
            {
                dispError.Text = error.Message;
            }
            finally
            {
                connect.Close();
                Courseinfo();
            }
        }
    }
}
