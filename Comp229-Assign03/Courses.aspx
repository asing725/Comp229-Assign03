<%@ Page Title="Courses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="Comp229_Assign03.WebForm4" %>
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
        <h2>List of Student</h2>
        <asp:GridView ID="studlst" runat="server" DataKeyNames="StudentID"  AutoGenerateColumns="False" OnRowDeleting="Studdel">
            <Columns>
                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:Label runat="server"
                            Text='<%# Eval("FirstMidName")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Eval("FirstMidName")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:Label runat="server"
                            Text='<%# Eval("LastName")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# Eval("LastName")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Enrollment Date">
                    <ItemTemplate>
                        <asp:Label runat="server"
                            Text='<%# Eval("EnrollmentDate")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server"
                            Text='<%# Eval("EnrollmentDate")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" Class="btn btn-primary" OnClientClick="return confirm('Are you sure ?')" Text="Delete"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                  </asp:GridView>

        <div class="col-sm-6 col-md-6">
        <h2>Add New Student</h2>
      <table> 
                   <tr><td style="width:160px"><asp:Label  Text="Student ID: " runat="server" /></td><th><asp:TextBox ID="studID" runat="server" ></asp:TextBox></th></tr>
           <tr><td style="width:160px"><asp:Label ID="lblfirstname" Text="Full name: " runat="server" /></td><th> <asp:TextBox ID="frstname" runat="server" ></asp:TextBox></th></tr>
                   <tr><td style="width:160px"> <asp:Label  Text="Last name: " runat="server" /></td><th><asp:TextBox ID="lstname" runat="server" ></asp:TextBox></th></tr>
                   <tr><td style="width:160px"><asp:Label Text="Enrollment Date: " runat="server" /></td><th><asp:TextBox ID="edate" runat="server"  placeholder="YYYY-MM-DD" ></asp:TextBox></th></tr>
                   <tr><td style="width:160px"><asp:Label Text="Grade: " runat="server" /></td><th>  <asp:TextBox ID="grd" runat="server" Text="0" ></asp:TextBox></th></tr>
                <tr><td style="width:160px"> <asp:Button runat="server" Text="Add" class="btn btn-default"
             OnClick="Addbtn_Click" /></td><th><asp:Label ID="dispError" runat="server" /></th></tr>
   </table>
    
     </div>
     </div>
      </div>
      </div>
</asp:Content>
