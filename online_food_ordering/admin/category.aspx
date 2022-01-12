<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="online_food_ordering.admin.category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	<div class="card">
		<div class="card-body">
			<h1 class="grid_title">Category Master</h1>
			<a href="manage_category.aspx" class="add_link">Add Category</a>
			<div class="row grid_box">
				<div class="col-12">
						<div class="table-responsive">
							<asp:Repeater ID="r1" runat="server">
								<HeaderTemplate>
									<table id="order-listing" class="table">
										<thead>
											<tr>
												<th width="15%">S.No #</th>
												<th width="55%">Category</th>
												<th width="30%">Actions</th>
											</tr>
										</thead>
										<tbody>
								</HeaderTemplate>
								<ItemTemplate>

									<tr>
										<td><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
										<td><%# Eval("category") %></td>
										<td>
											<a href="manage_category.aspx?id=<%# Eval("id") %>">
												<label class="badge badge-success hand_cursor">Edit</label></a>&nbsp;								
								<asp:HyperLink ID="HyperLinkActive" runat="server" NavigateUrl='<%# string.Format("category.aspx?id={0}&type=deactive",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "False" ? true : false %>'>
									<asp:Label ID="lblactive" runat="server" class="badge badge-danger hand_cursor" Text="Active"></asp:Label>
								</asp:HyperLink>
											<asp:HyperLink ID="HyperLinkDeactive" runat="server" NavigateUrl='<%# string.Format("category.aspx?id={0}&type=active",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "True" ? true : false %>'>
												<asp:Label ID="lbldeactive" runat="server" class="badge badge-info hand_cursor" Text="Deactive"></asp:Label>
											</asp:HyperLink>
											&nbsp;
								<a href="category.aspx?id=<%# Eval("id") %>&type=delete">
									<label class="badge badge-danger delete_red hand_cursor">Delete</label>

								</a>
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
