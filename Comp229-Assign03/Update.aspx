<%@ Page Title="Update" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Comp229_Assign03.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="body">
 <div class="jumbotron">       
        <h1>
          AH College</h1>         
        <p class="lead">We are leading IT college in GTA with over 4 campuses.</p>
          <br />
</div>
    <div class="row">
        <div class="col-sm-6 col-md-6">
        <table>
                <tr>
                    <td style="width:160px">Student ID     </td><th>
                    <asp:Label ID="studID" runat="server" Text='<%#Eval("StudentID")%>' /></th>
                     <tr>
                    <td style="width:160px">Full Name      </td><th>
                    <asp:Label ID="studName" runat="server" Text='<%#Eval("FirstMidName") + " " + Eval("LastName") %>' /></th>
                          <tr>
                    <td style="width:160px">Enrollment Date</td>  <th>
                    <asp:Label ID="studDate" runat="server" Text='<%#Eval("EnrollmentDate")%>' /></th>                 
                </tr>           
            </table>
            </div>
        <div class="col-sm-6 col-md-6">    
         <table id="UpdateStudentTable">
              <tr>
                 <td style="width:160px" >First Name:</td>
                 <td>
                 <asp:TextBox ID="firstN" runat="server"></asp:TextBox><br />
                 </td>
             </tr>
             <tr>
                 <td style="width:160px">Last Name:</td>
                 <td>
                 <asp:TextBox ID="lastN" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td style="width:160px">Enrollment Date:</td>
                 <td>
                 <asp:TextBox ID="eDate" runat="server" ></asp:TextBox>
                 </td>
             </tr>
             </table>
   <asp:Button ID="Cancelbtn" Text="Cancel" runat="server" class="btn btn-default" OnClick="Cancelbtn_Click" />
         <asp:Button ID="Updatebtn" Text="Update" runat="server" class="btn btn-default" OnClick="Updatebtn_Click" />
     </div>   
     </div>
    </div>
</asp:Content>
