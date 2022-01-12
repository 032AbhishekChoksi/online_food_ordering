<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="delivery_boy.aspx.cs" Inherits="online_food_ordering.admin.delivery_boy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	<div class="card">
		<div class="card-body">
			<h1 class="grid_title">Delivery Boy Master</h1>
			<a href="manage_delivery_boy.aspx" class="add_link">Add Delivery Boy</a>
			<div class="row grid_box">
				<div class="col-12">
					<div class="table-responsive">
						<asp:Repeater ID="r1" runat="server">
							<HeaderTemplate>
								<table id="order-listing" class="table">
									<thead>
										<tr>
											<th width="10%">S.No #</th>
											<th width="30%">Name</th>
											<th width="25%">Mobile</th>
											<th width="15%">Added On</th>
											<th width="25%">Actions</th>
										</tr>
									</thead>
									<tbody>
							</HeaderTemplate>
							<ItemTemplate>
								<tr>
									<td>
										<asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
									<td><%# Eval("name") %></td>
									<td><%# Eval("mobile") %></td>
									<td><%# Eval("added_on","{0:dd-MM-yyyy}") %></td>
									<td>
										<a href="manage_delivery_boy.aspx?id=<%# Eval("id") %>">
											<label class="badge badge-success hand_cursor">Edit</label></a>&nbsp;
								<asp:HyperLink ID="HyperLinkActive" runat="server" NavigateUrl='<%# string.Format("delivery_boy.aspx?id={0}&type=deactive",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "False" ? true : false %>'>
									<asp:Label ID="lblactive" runat="server" class="badge badge-danger hand_cursor" Text="Active"></asp:Label>
								</asp:HyperLink>
										<asp:HyperLink ID="HyperLinkDeactive" runat="server" NavigateUrl='<%# string.Format("delivery_boy.aspx?id={0}&type=active",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "True" ? true : false %>'>
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
