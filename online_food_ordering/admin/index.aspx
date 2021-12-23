<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="online_food_ordering.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    Hello
   <asp:Literal runat="server" Text="<%$ AppSettings:SITE_NAME%>" />
    <br />
 <%Response.Write(Request.ServerVariables["HTTP_HOST"]);%>
    <br />
    <%
        foreach (String x in Request.ServerVariables) {
            Response.Write(x + "<br/>");
  }
         %>
</asp:Content>
