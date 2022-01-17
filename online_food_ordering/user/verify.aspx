<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="verify.aspx.cs" Inherits="online_food_ordering.user.verify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c2" runat="server">
<div class="breadcrumb-area gray-bg">
<div class="container">
    <div class="breadcrumb-content">
        <ul>
            <li><a href="shop.aspx">Home</a></li>
            <li class="active">Email Verify</li>
        </ul>
    </div>
</div>
</div>
<div class="contact-area pb-100">
<div class="container">
    <div class="row">
        <div class="col-12">
            <div class="contact-message-wrapper">
                <h4 class="contact-title">
                    <asp:Label ID="lblmessage" runat="server" Text="" Visible="false" />
                </h4>
            </div>
        </div>
    </div>
</div>
</div>
</asp:Content>
