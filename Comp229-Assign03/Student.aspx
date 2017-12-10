<%@ Page Title="Student" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Comp229_Assign03.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="body">
 <div class="jumbotron">
          
        <h1>
          AH College</h1>         
        <p class="lead">We are leading IT college in GTA with over 4 campuses.</p>
          <br />
</div>
          <table>
                <tr>
                    <td style="width:160px">Student ID:</td> <th>
                    <asp:Label ID="studID" runat="server" Text='<%#Eval("StudentID")%>' /></th></tr>
                    <tr>
                    <td style="width:160px">Full Name:</td> <th>
                    <asp:Label ID="studName" runat="server" Text='<%#Eval("FirstMidName") + " " + Eval("LastName") %>' /></th></tr>
                        <tr>
                    <td style="width:160px">Enrollment Date:</td> <th>
                    <asp:Label ID="studDate" runat="server" Text='<%#Eval("EnrollmentDate")%>' /></th></tr>
                            <tr>
                    <td style="width:160px">Course(s):</td> <th>                  
                        <asp:DataList runat="server" ID="course" OnItemCommand="CourseList">            
           <ItemTemplate>                          
                            <asp:LinkButton ID="courselnk" runat="server" Text='<%#Eval("Title")%>' CommandName="detail"  CommandArgument='<%#Eval("CourseID")%>'/>                               
              </th></tr>  
            </ItemTemplate>
                        </asp:DataList> </table>  
         <asp:Button class="btn btn-default" ID="update"   Text="Update Info" runat="server" OnClick="update_Click" />
   <asp:Button class="btn btn-default" ID="del" Text="Delete Student" runat="server"  OnClientClick="return confirm('This will delete selected student from our database.')"  OnClick="del_Click" />
   </div>
</asp:Content>
