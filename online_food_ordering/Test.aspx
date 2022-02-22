<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="online_food_ordering.Test" %>
<form id="form1" runat="server">
    <div>
         <table>
       <tbody>
           <tr>
               <td colspan="2">
                   <asp:Label ID="lblMessage" runat="server" Visible="false" style="color:red"/>
               </td>
           </tr>
           <tr>
               <td>Username&nbsp;:</td>
               <td>
                   <input id="txtfname" name="fname" type="text" /></td>
           </tr>
           <tr>
               <td>Password&nbsp;:</td>
               <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter The User Password" ToolTip="Enter The User Password" /></td>
           </tr>
           <tr>
               <td colspan="2">
                   <input id="btnSubmit" type="button" name="btnSubmit" value="Submit" />
                   <%--<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" ToolTip="Login"/>--%>
               </td>
           </tr>
       </tbody>
   </table>
    </div>
    </form>