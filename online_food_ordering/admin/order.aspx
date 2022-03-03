<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="online_food_ordering.admin.order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	
<div class="card">
	<div class="card-body">
		<h1 class="grid_title">Order Master</h1>
		<div class="row grid_box">

			<div class="col-12">
				<div class="table-responsive">
					 <asp:Repeater ID="r1" runat="server">
					<HeaderTemplate>
					<table id="order-listing" class="table">
						<thead>
							<tr>
								<th width="5%">Order Id</th>
								<th width="20%">Name/Email/Mobile</th>
								<th width="20%">Address/Zipcode</th>
								<th width="5%">Price</th>
								<th width="10%">Payment Status</th>
								<th width="10%">Order Status</th>
								<th width="20%">Added On</th>
							</tr>
						</thead>
						<tbody>
							 </HeaderTemplate>
					<ItemTemplate>
									<tr>
										<td>
											<div class="div_order_id">
												<a href="order_detail.aspx?id=<%# Eval("id") %>"><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></a>
											</div>
										</td>
										<td>
											<p><%# Eval("name") %></p>
											<p><%# Eval("email") %></p>
											<p><%# Eval("mobile") %></p>
										<td>
											<p><%# Eval("address") %></p>
											<p><%# Eval("zipcode") %></p>
										</td>
										<td style="font-size:14px;"><%# Eval("total_price") %> Rs.<br />
											<%# ApplyCoupon(Eval("coupon_code"), Eval("final_price"))[0] %>
											<%# ApplyCoupon(Eval("coupon_code"), Eval("final_price"))[1] %>
										</td>
										<td>
											<div class="payment_status payment_status_<%# Eval("payment_status") %>"><%# Eval("payment_status") %></div>
										</td>
										<td><%# Eval("order_status_str") %></td>
										<td>
											<%# Eval("added_on","{0:dd/M/yyyy}") %>
										</td>
									</tr>								
					</ItemTemplate>
					<FooterTemplate>
						</tbody>
					</table>
						  </FooterTemplate>
				</asp:Repeater>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
