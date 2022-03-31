<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="refund_money.aspx.cs" Inherits="online_food_ordering.admin.refund_money" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="card">
	<div class="card-body">
		<h1 class="grid_title">Refund Money</h1>
		<div class="row grid_box">
			<div class="col-12">
				<div class="table-responsive">
					<asp:Repeater ID="r1" runat="server">
						<HeaderTemplate>
							<table id="order-listing" class="table">
								<thead>
									<tr>
										<th width="10%">S.No #</th>
										<th width="25%">Name</th>
										<th width="15%">Email</th>
										<th width="15%">Mobile</th>
										<th width="15%">Wallet</th>
										<th width="20%">Actions</th>
									</tr>
								</thead>
								<tbody>
									</HeaderTemplate>
									<ItemTemplate>
										<tr>
											<td>
												<asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" />
											</td>
											<td><%# Eval("name") %></td>
											<td><%# Eval("email") %></td>
											<td><%# Eval("mobile") %></td>
											<td><%# string.Format("₹{0}",Math.Round(getWalletAmt(Eval("user_id"))))%></td>
											<td>
												<a href="add_money.aspx?uid=<%# Eval("user_id") %>"><label class="badge badge-success hand_cursor">Refund Money</label></a>
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
