﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_coupon_code.aspx.cs" Inherits="online_food_ordering.admin.manage_coupon_code" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	<div class="row">
			<h1 class="grid_title ml10 ml15">Manage Coupon Code</h1>
			<div class="col-12 grid-margin stretch-card">
			  <div class="card">
				<div class="card-body">
				  <form ID="fo1" runat="server" class="forms-sample" method="post">
					<div class="form-group">
						<asp:Label ID="lblcoupon_code" runat="server" Text="Coupon Code"></asp:Label>
						<asp:TextBox ID="txtcoupon_code" runat="server" class="form-control" placeholder="Coupon Code" name="coupon_code" ToolTip="Coupon Code"></asp:TextBox>
					  <div class="error mt8" id="error" runat="server" style="display:none">Coupon Code already added</div>
					</div>
					<div class="form-group">
						<asp:Label ID="lblcoupon_type" runat="server" Text="Coupon Type"></asp:Label>
						<asp:DropDownList ID="ddtcoupon_type" runat="server" class="form-control" name="type" ToolTip="Select Type">
							<asp:ListItem Value="" Selected="True">Select Type</asp:ListItem>
							<asp:ListItem Value="P">Percentage</asp:ListItem>
							<asp:ListItem Value="F">Fixed</asp:ListItem>
						</asp:DropDownList>
					</div>
					<div class="form-group">
						<asp:Label ID="lblcoupon_value" runat="server" Text="Coupon Value"></asp:Label>
						<asp:TextBox ID="txtcoupon_value" runat="server" class="form-control" placeholder="Coupon Value" name="coupon_value" ToolTip="Coupon Value"></asp:TextBox>
					</div>  
					<div class="form-group">
						<asp:Label ID="lblcart_min_value" runat="server" Text="Cart Minimum Value"></asp:Label>
						<asp:TextBox ID="txtcart_min_value" runat="server" class="form-control" placeholder="Cart Minimum Value" name="cart_min_value" ToolTip="Cart Minimum Value"></asp:TextBox>
					</div>
					<div class="form-group">
						<asp:Label ID="lblexpired_on" runat="server" Text="Expired On"></asp:Label>
						<asp:TextBox ID="txtexpired_on" runat="server" class="form-control" placeholder="Expired On" name="expired_on" TextMode="Date"></asp:TextBox>
					</div>
					  <asp:Button ID="bttnsubmit" runat="server" Text="Submit" class="btn btn-primary mr-2" name="submit" OnClick="bttnsubmit_Click"/>
				  </form>
				</div>
			  </div>
			</div>            
		 </div>        

</asp:Content>