<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="order_detail.aspx.cs" Inherits="online_food_ordering.user.order_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c2" runat="server">
<div class="breadcrumb-area gray-bg">
<div class="container">
    <div class="breadcrumb-content">
        <ul>
            <li><a href="shop">Home</a></li>
			<li><a href="order_history.aspx">Order History</a></li>
            <li class="active">Order Detail</li>
        </ul>
    </div>
</div>
</div>
<div class="cart-main-area pt-30 pb-30">
	<div class="container">
		<h3 class="page-title">Order Detail</h3>
		<div class="row">
			<div class="col-lg-12 col-md-12 col-sm-12 col-12">
				<form method="post">
					<div class="table-content table-responsive">
						<table style="border:1px solid #e9e8ef;">
							<tr>
								<th width="30%">Dish</th>
								<th width="20%">Attribute</th>
								<th width="15%">Unit Price</th>
								<th width="5%">Qty</th>
								<th width="15%">Total Price</th>
								<th width="15%"></th>
							</tr>
							<% 
                                int total_price = 0;
                                foreach (int key in getOrderDetails.Keys)
                                {
                                    int item_price = Convert.ToInt32(getOrderDetails[key]["qty"]) * Convert.ToInt32(getOrderDetails[key]["price"]);
                                    total_price = total_price + item_price;
                            %>
								<tr>
									<td><%=getOrderDetails[key]["dish_name"] %></td>
									<td><%=getOrderDetails[key]["attribute"] %></td>
									<td>₹ <%=getOrderDetails[key]["price"] %></td>
									<td><%=getOrderDetails[key]["qty"] %></td>
									<td>₹  <%= item_price %></td>
									<td id="rating<%=getOrderDetails[key]["dish_detail_id"] %>">
									<%
                                        if (Convert.ToInt32(getOrderById["order_status"]) == 4)
                                        {

                                        }
									%>
									<%--<?php
									if ($getOrderById[0]['order_status'] == 4) {
										echo getRating($list['dish_details_id'], $id);
									}
									?>--%>
									</td>
								</tr>
							<% } %>
							<tr>
								<td colspan="3"></td>
								<td><strong>Total</strong></td>
								<td><strong>₹ <%= total_price %></strong></td>
								<td></td>
							</tr>
							<% 
                                string coupon_code = getOrderById["coupon_code"];
                                if (!string.IsNullOrEmpty(coupon_code))
								{
							%>
								<tr>
									<td colspan="3"></td>
									<td><strong>Coupon Code</strong></td>
									<td><strong><%=getOrderById["coupon_code"] %></strong></td>
									<td></td>
								</tr>
								<tr>
									<td colspan="3"></td>
									<td><strong>Final Total</strong></td>
									<td><strong>₹ <%= Math.Round(Convert.ToDecimal(getOrderById["final_price"])) %></strong></td>
									<td></td>
								</tr>
							<% } %>
						</table>
					</div>
				</form>
			</div>
		</div>
	</div>
</div>
</asp:Content>
