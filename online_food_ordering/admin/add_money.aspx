<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="add_money.aspx.cs" Inherits="online_food_ordering.admin.add_money" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
   <div class="card">
	<div class="card-body">
		<h1 class="grid_title">Send Refund Money</h1>
		<div class="row grid_box">
			<div class="col-12">
				<div class="table-responsive">
			
					<asp:Repeater ID="r1" runat="server">
						<HeaderTemplate>
							<table id="order-listing" class="table">
								<thead>
									<tr>
										<th width="25%">Order ID</th>	
										<th width="25%">Order Date</th>
										<th width="25%">Refund Ammount(₹)</th>										
										<th width="25%">Action</th>
									</tr>
								</thead>
								<tbody>
									</HeaderTemplate>
									<ItemTemplate>
										<tr>
											<td><%# Eval("id") %></td>
											<td><%# Eval("added_on","{0:dd-MM-yyyy}") %></td>
											<td><%# string.Format("₹{0}",Math.Round(FormatAmount(Eval("final_price"))))%></td>
											<td>
												<a href="add_money.aspx?oid=<%# Eval("id") %>&amt=<%# string.Format("{0}",Math.Round(FormatAmount(Eval("final_price"))))%>"><label class="badge badge-success hand_cursor">Send Money</label></a>
												
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
