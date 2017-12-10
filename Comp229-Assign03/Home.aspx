<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Comp229_Assign03.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="body">
  <div class="jumbotron">
          
        <h1>
          AH College</h1>         
        <p class="lead">We are leading IT college in GTA with over 4 campuses.</p>
          <br />
</div>
    <br />
   
    <div class="row">
        <div class="col-sm-6 col-md-6">
            <h2>Add Student</h2>            
                  <table>

                 <tr><td style="width:160px">
            <asp:Label for="studfname" runat="server" Text="First Name: " /></td>
             <th>  <asp:TextBox ID="studfname" runat="server"></asp:TextBox></th> </tr> 
          <tr><td style="width:160px"> <asp:Label for="studlname" runat="server" Text="Last Name: "/></td><th> <asp:TextBox ID="studlname" runat="server"></asp:TextBox></th></tr>
               <tr><td style="width:160px">  <asp:Label for="studedate" runat="server" Text="Enrollment Date: " /></td><th><asp:TextBox ID="studedate" runat="server" 
                    placeholder="YYYY-MM-DD"></asp:TextBox></th></tr>
               <tr><td style="width:160px"><asp:Button ID="StudAdd" runat="server" Text="Add Student" class="btn btn-default" CommandName="StudAdd" OnClick="StudAdd_click" /></td><th><asp:Label ID="disperror" runat="server" /></th></tr>
  </table>   
        </div>
        
        <div class="col-sm-6 col-md-6">
            <h2>Student list</h2>
            <asp:Datalist ID="StudName" runat="server" OnItemCommand="Studentlst">    
           <ItemTemplate>
             <table>
                <tr> <li>  <asp:LinkButton ID="studName" runat="server"
                      Text=' <%#Eval("FirstMidName") + " " + Eval("LastName")%>'
                      CommandName="details"
                      CommandArgument='<%#Eval("StudentID")%>' /></li></tr> 
          </table>
        </ItemTemplate>       
    </asp:Datalist>
        </div>  
    </div>
    </div>
</asp:Content>

