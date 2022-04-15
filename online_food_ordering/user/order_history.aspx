<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="order_history.aspx.cs" Inherits="online_food_ordering.user.order_history" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c2" runat="server">
<div class="breadcrumb-area gray-bg">
<div class="container">
    <div class="breadcrumb-content">
        <ul>
            <li><a href="shop">Home</a></li>
            <li class="active">Order History</li>
        </ul>
    </div>
</div>
</div>
    <div class="cart-main-area pt-30 pb-30">
	<div class="container">
		<h3 class="page-title">Order History</h3>
		<div class="row">
			<div class="col-lg-12 col-md-12 col-sm-12 col-12">
				<form method="post">
					<div class="table-responsive">
						<asp:Repeater ID="r1" runat="server">
								<HeaderTemplate>
						<table id="order-listing" class="table" style="text-align:center;vertical-align: middle;">
							<thead>
								<tr>
									<th width="10%">Order No</th>
									<th width="10%">Price</th>
									<th width="15%">Coupon</th>
									<th width="20%">Address</th>
									<th width="10%">Zipcode</th>
									<th width="10%">Order Status</th>
									<th width="15%">Delivery Boy</th>
									<th width="10%">Payment Status</th>
								</tr>
							</thead>
							<tbody>
								</HeaderTemplate>
								<ItemTemplate>
										<tr>
											<td>
												<div class="div_order_id">
													<a href="order_detail.aspx?id=<%# Eval("id") %>"><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></a>
												</div><br />
												<a href="download_invoice?id=<%# Eval("id") %>"><img src='./assets/img/icon-img/pdf.png' width="20px" title="Download Invoice" /></a>
											</td style="font-size:14px;">
											<td><%# string.Format("{0} Rs.",Math.Round((decimal)Eval("total_price"))) %>
											</td>
											<%--<td>
												<%# ApplyCoupon(Eval("coupon_code"),Eval("total_price"), Eval("final_price"))[0] %>
												<%# ApplyCoupon(Eval("coupon_code"),Eval("total_price"), Eval("final_price"))[1] %>
											</td>--%>
											<td>
												<%# ApplyCoupon(Eval("coupon_code"), Eval("final_price"))[0] %>
												<%# ApplyCoupon(Eval("coupon_code"), Eval("final_price"))[1] %>
											</td>
											<td><%# Eval("address") %></td>
											<td><%# Eval("zipcode") %></td>
											<td>
												<%# Eval("order_status_str") %>
												<%# CheckOrderStatus(Eval("id"),Eval("order_status"),Eval("payment_status")) %>
											</td>
											<td><%# DisplayDeliveryBoyDetails(Eval("delivery_boy_id")) %></td>
											<td>
												<div class="payment_status payment_status_<%# Eval("payment_status") %>"><%# Eval("payment_status", "{0:C}") %></div>
											</td>
										</tr>
									</ItemTemplate>
							<FooterTemplate>
							</tbody>
						</table>
								</FooterTemplate>
						</asp:Repeater>
					</div>
				</form>
			</div>
		</div>
	</div>
</div>
</asp:Content>
