﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="setting.aspx.cs" Inherits="online_food_ordering.admin.setting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<div class="row">
  <h1 class="grid_title ml10 ml15">Setting</h1>
  <div class="col-12 grid-margin stretch-card">
    <div class="card">
      <div class="card-body">
        <form ID="fo1" class="forms-sample" method="post" runat="server">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
          <div class="form-group">
              <asp:Label ID="lblcart_min_price" runat="server" Text="Cart min price"></asp:Label>
              <asp:TextBox ID="txtcart_min_price" runat="server" class="form-control" placeholder="Cart min price" name="cart_min_price" TextMode="Number"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidatorcart_min_price" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtcart_min_price" Display="Dynamic" >Cart minimum price is mandatory </asp:RequiredFieldValidator>

          </div>
          <div class="form-group">
              <asp:Label ID="lblcart_min_price_msg" runat="server" Text="Order Number"></asp:Label>
              <asp:TextBox ID="txtcart_min_price_msg" runat="server" class="form-control" placeholder="Cart min price msg" name="cart_min_price_msg"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidatorcart_min_price_msg" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtcart_min_price_msg" Display="Dynamic" >Cart minimum price message is mandatory </asp:RequiredFieldValidator>
          </div>
          <div class="form-group">
              <asp:Label ID="lblwebsite_close" runat="server" Text="Website Close"></asp:Label>
              <asp:DropDownList ID="ddtwebsite_close" runat="server" class="form-control">
                  <asp:ListItem Value="yes" Text="Yes"></asp:ListItem>
                  <asp:ListItem Value="no" Text="No"></asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidatorwebsite_close" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddtwebsite_close" Display="Dynamic" >Website close is mandatory </asp:RequiredFieldValidator>
          </div>
          <div class="form-group">
              <asp:Label ID="lblwebsite_close_msg" runat="server" Text="Website Close Msg"></asp:Label>
              <asp:TextBox ID="txtwebsite_close_msg" runat="server" class="form-control" placeholder="Website close msg" name="website_close_msg"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidatorwebsite_close_msg" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtwebsite_close_msg" Display="Dynamic" >Website close message is mandatory </asp:RequiredFieldValidator>
          </div>
          <div class="form-group">
              <asp:Label ID="lblwallet_amt" runat="server" Text="Wallet Amount"></asp:Label>
              <asp:TextBox ID="txtwallet_amt" runat="server" class="form-control" placeholder="Wallet Amount" name="wallet_amt" TextMode="Number"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidatorwallet_amt" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtwallet_amt" Display="Dynamic" >Wallet amount is mandatory </asp:RequiredFieldValidator>
          </div>
          <div class="form-group">
              <asp:Label ID="lblreferral_amt" runat="server" Text="Referral Amt"></asp:Label>
              <asp:TextBox ID="txtreferral_amt" runat="server" class="form-control" placeholder="Website close msg" name="referral_amt" TextMode="Number"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidatorreferral_amt" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtreferral_amt" Display="Dynamic" >Referral amount is mandatory </asp:RequiredFieldValidator>
          </div>
         <div class="form-group">
              <asp:Label ID="lblthemecolor" runat="server" Text="Website Close"></asp:Label>
             <asp:UpdatePanel ID="UP" runat="server">
                 <ContentTemplate>
                    <asp:DropDownList ID="ddtthemecolor" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddtthemecolor_SelectedIndexChanged">
                        <asp:ListItem Value="darkbluestyle.css" Text="Dark Blue" style="background-color:#037FB0;"></asp:ListItem>
                        <asp:ListItem Value="lightbluestyle.css" Text="Light Blue" style="background-color:#6fa8dc;"></asp:ListItem>
                        <asp:ListItem Value="darkgreenstyle.css" Text="Dark Green" style="background-color:#6aa84f;"></asp:ListItem>
                        <asp:ListItem Value="lightgreenstyle.css" Text="Light Green" style="background-color:#93c47d;"></asp:ListItem>
                        <asp:ListItem Value="darkpurplestyle.css" Text="Dark Purple" style="background-color:#5e2572;"></asp:ListItem>
                        <asp:ListItem Value="lightpurplestyle.css" Text="Light Purple" style="background-color:#674ea7;"></asp:ListItem>
                    </asp:DropDownList>
                     </ContentTemplate>
                 </asp:UpdatePanel>
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorthemecolor" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddtthemecolor" Display="Dynamic" >Themecolor is mandatory </asp:RequiredFieldValidator>
          </div>
            <asp:Button ID="bttnsubmit" runat="server" Text="Submit" class="btn btn-primary mr-2" name="submit" OnClick="bttnsubmit_Click"/>
        </form>
      </div>
    </div>
  </div>
</div>
</asp:Content>

