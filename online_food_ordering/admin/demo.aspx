<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="online_food_ordering.admin.demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    Hello
   <asp:Literal runat="server" Text="<%$ AppSettings:FRONT_SITE_PATH%>" />
    <br />
    <%Response.Write(Request.ServerVariables["HTTP_HOST"]);%>
    <br />
    <%
        foreach (String x in Request.ServerVariables)
        {
        }
    %>
</asp:Content>
