<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="dish.aspx.cs" Inherits="online_food_ordering.admin.dish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	
<div class="card">
	<div class="card-body">
		<h1 class="grid_title">Dish Master</h1>
		<a href="manage_dish.aspx" class="add_link">Add Dish</a>
		<div class="row grid_box">

			<div class="col-12">
				<div class="table-responsive">
					  <asp:Repeater ID="r1" runat="server">
					<HeaderTemplate>
					<table id="order-listing" class="table">
						<thead>
							<tr>
								<th width="10%">S.No #</th>
								<th width="15%">Category</th>
								<th width="25%">Dish</th>
								<th width="15%">Image</th>
								<th width="15%">Added On</th>
								<th width="20%">Actions</th>
							</tr>
						</thead>
						<tbody>
							</HeaderTemplate>
					<ItemTemplate>
									<tr>
										<td><%# Eval("id") %></td>
										<td><%# Eval("category") %></td>
										<td><%# Eval("dish") %>&nbsp;(<%# Eval("type").ToString().ToUpper().Trim(' ') %>)</td>
										<td><a target="_blank" href="<%# Eval("image","../media/dish/{0}") %>"><img src="<%# Eval("image","../media/dish/{0}") %>" ></a></td>
										<td>
											<%# Eval("added_on","{0:dd-MM-yyyy}") %>
										</td>
										<td>
											<a href="manage_dish.aspx?id=<%# Eval("id") %>"><label class="badge badge-success hand_cursor">Edit</label></a>&nbsp;
											<asp:HyperLink ID="HyperLinkActive" runat="server" NavigateUrl='<%# string.Format("dish.aspx?id={0}&type=deactive",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "False" ? true : false %>'>
									<asp:Label ID="lblactive" runat="server" class="badge badge-danger hand_cursor" Text="Active"></asp:Label>
								</asp:HyperLink>
											<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("dish.aspx?id={0}&type=active",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "True" ? true : false %>'>
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
