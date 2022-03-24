<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="banner.aspx.cs" Inherits="online_food_ordering.admin.banner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	<div class="card">
	<div class="card-body">
		<h1 class="grid_title">Banner Master</h1>
		<a href="manage_banner.aspx" class="add_link">Add Banner</a>
		<div class="row grid_box">
			<div class="col-12">
				<div class="table-responsive">
					<asp:Repeater ID="r1" runat="server">
								<HeaderTemplate>
					<table id="order-listing" class="table">
						<thead>
							<tr>
								<th width="10%">S.No #</th>
								<th width="15%">Image</th>
								<th width="25%">Heading</th>
								<th width="30%">Sub Heading</th>
								<th width="20%">Actions</th>
							</tr>
						</thead>
						<tbody>
							</HeaderTemplate>
								<ItemTemplate>
									<tr>
										<td><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>										
										<td><a target="_blank" href="<%# Eval("image","../media/banner/{0}") %>"><img src="<%# Eval("image","../media/banner/{0}") %>" ></a></td>
										<td><%# Eval("heading") %></td>
										<td><%# Eval("sub_heading") %></td>
										<td>
											<a href="manage_banner.aspx?id=<%# Eval("id") %>"><label class="badge badge-success hand_cursor">Edit</label></a>&emsp;
											<asp:HyperLink ID="HyperLinkActive" runat="server" NavigateUrl='<%# string.Format("banner.aspx?id={0}&type=deactive",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "False" ? true : false %>'>
												<asp:Label ID="lblactive" runat="server" class="badge badge-danger hand_cursor" Text="Active"></asp:Label>
											</asp:HyperLink>
											<asp:HyperLink ID="HyperLinkDeActive" runat="server" NavigateUrl='<%# string.Format("banner.aspx?id={0}&type=active",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "True" ? true : false %>'>
												<asp:Label ID="lbldeactive" runat="server" class="badge badge-info hand_cursor" Text="Deactive"></asp:Label>
											</asp:HyperLink>
											<%--&nbsp;
											<a href="banner.aspx?id=<%# Eval("id") %>&type=delete">
									<label class="badge badge-danger delete_red hand_cursor">Delete</label>

								</a>--%>
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
