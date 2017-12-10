using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           SetActivePage();
        }
        private void SetActivePage()
        {
            
            Debug.WriteLine(Page.Title);
            switch (Page.Title)
            {
                case "Home":
                    Page.Title = string.Format("AH College: {0}", Page.Title);
                    break;      
                case "Student":
                    Page.Title = string.Format("AH College: ");
                    break;
                case "Courses":
                    Page.Title = string.Format("AH College: ");
                    break;
                case "Update":
                    Page.Title = string.Format("AH College: ");
                    break;

            }
        } 
    }
}
