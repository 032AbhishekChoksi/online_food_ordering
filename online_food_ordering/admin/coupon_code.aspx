<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="coupon_code.aspx.cs" Inherits="online_food_ordering.admin.coupon_code" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	<div class="card">
		<div class="card-body">
			<h1 class="grid_title">Coupon Code Master</h1>
			<a href="manage_coupon_code.aspx" class="add_link">Add Coupon Code</a>
			<div class="row grid_box">
				<div class="col-12">
					<div class="table-responsive">
						<asp:Repeater ID="r1" runat="server">
							<HeaderTemplate>
								<table id="order-listing" class="table">
									<thead>
										<tr>
											<th width="10%">S.No #</th>
											<th width="20%">Code/Value</th>
											<th width="10%">Type</th>
											<th width="10%">Cart Min</th>
											<th width="15%">Expired On</th>
											<th width="15%">Added On</th>
											<th width="20%">Actions</th>
										</tr>
									</thead>
									<tbody>
							</HeaderTemplate>
							<ItemTemplate>
								<tr>
									<td>
										<asp:HyperLink ID="HyperLinkidactive" runat="server" NavigateUrl='<%# string.Format("send_coupon_code.aspx?id={0}",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "False" ? true : false %>'>
											<div class="div_order_id">
												<asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></a>
											</div>
										</asp:HyperLink>
										<asp:HyperLink ID="HyperLinkiddecative" runat="server" Visible='<%# Eval("status").ToString() != "True" ? true : false %>'>
											<div class="div_order_id">
												<asp:Label ID="lblRow" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></a>
											</div>
										</asp:HyperLink>
										<%--<div class="div_order_id"><a href="send_coupon_code.aspx?id=<%# Eval("id") %>">
											<asp:Label ID="Label2" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></a>
										</div>--%>
									</td>
									<td>
										<div><%# Eval("coupon_code") %> /
											<asp:Label ID="lblcoupon_type" runat="server" Text='<%# CheckCouponType(Eval("coupon_type"),Eval("coupon_value")) %>'></asp:Label>
										</div>
									</td>
									<td><%# Eval("coupon_type") %></td>
									<td><%# string.Format("₹{0}",Math.Round((decimal)Eval("cart_min_value"))) %></td>
									<td>
										<%# Eval("expired_on","{0:dd-MM-yyyy}") %>
										<p style="font-size:15px;font-style:italic; font-weight: bold;color:red;margin-top:2px;"><%# CheckCouponExpired(Eval("expired_on"),Eval("id")) %></p>
									</td>
									<td>
										<%# Eval("added_on","{0:dd-MM-yyyy}") %>
									</td>
									<td>
										<a href="manage_coupon_code.aspx?id=<%# Eval("id") %>">
										<label class="badge badge-success hand_cursor">Edit</label></a>&nbsp;
										<asp:HyperLink ID="HyperLinkActive" runat="server" NavigateUrl='<%# string.Format("coupon_code.aspx?id={0}&type=deactive",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "False" ? true : false %>'>
											<asp:Label ID="lblactive" runat="server" class="badge badge-danger hand_cursor" Text="Active"></asp:Label>
										</asp:HyperLink>
										<asp:HyperLink ID="HyperLinkDeactive" runat="server" NavigateUrl='<%# string.Format("coupon_code.aspx?id={0}&type=active",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "True" ? true : false %>'>
											<asp:Label ID="lbldeactive" runat="server" class="badge badge-info hand_cursor" Text="Deactive"></asp:Label>
										</asp:HyperLink>
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
