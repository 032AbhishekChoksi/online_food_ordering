<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="online_food_ordering.admin.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<div class="card">
	<div class="card-body">
		<h1 class="grid_title">User Master</h1>
		<div class="row grid_box">
			<div class="col-12">
				<div class="table-responsive">
					<asp:Repeater ID="r1" runat="server">
							<HeaderTemplate>
					<table id="order-listing" class="table">
						<thead>
							<tr>
								<th width="10%">S.No #</th>
								<th width="17%">Name</th>
								<th width="17%">Email</th>
								<th width="13%">Mobile</th>
								<th width="11%">Wallet</th>
								<th width="14%">Added On</th>
								<th width="18%">Actions</th>
							</tr>
						</thead>
						<tbody>
							</HeaderTemplate>
							<ItemTemplate>
									<tr>
										<td><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
										<td><%# Eval("name") %></td>
										<td><%# Eval("email") %></td>
										<td><%# Eval("mobile") %></td>
										<td><?php echo getWalletAmt($row['id']) ?></td>
										<td>
											<%# Eval("added_on","{0:dd-MM-yyyy}") %>
										</td>
										<td>
											<asp:HyperLink ID="HyperLinkActive" runat="server" NavigateUrl='<%# string.Format("user.aspx?id={0}&type=deactive",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "False" ? true : false %>'>
											<asp:Label ID="lblactive" runat="server" class="badge badge-danger hand_cursor" Text="Active"></asp:Label>
										</asp:HyperLink>
										<asp:HyperLink ID="HyperLinkDeactive" runat="server" NavigateUrl='<%# string.Format("user.aspx?id={0}&type=active",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "True" ? true : false %>'>
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
