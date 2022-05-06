<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="order_detail.aspx.cs" Inherits="online_food_ordering.admin.order_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<div class="page-header">
	<h3 class="page-title">Order Invoice </h3>
</div>
<form id="f1" runat="server">
	<asp:ScriptManager runat="server"></asp:ScriptManager>
		<asp:UpdatePanel ID="UP" runat="server">
		<ContentTemplate>
<div class="row">
	<div class="col-lg-12">
		<div class="card px-2">
			<div class="card-body">
				<div class="container-fluid">
					<h3 class="text-right my-5">Order ID&nbsp;&nbsp;<%=oid %></h3>
					<hr>
				</div>
				<div class="container-fluid d-flex justify-content-between">
					<div class="col-lg-3 pl-0"><br />
						<p class="mt-5 mb-2"><br />
							<b>Customer Name</b>
						</p>
						<p>Customer Address</p>
					</div>
					<div class="col-lg-3 pr-0">
						<p class="mt-5 mb-2 text-right"><b>Invoice to</b></p>
						<p class="text-right">
							<%= orderRow["id"] %><br />
							<%= orderRow["user_name"] %><br />
							<%= orderRow["address"] %><br />
							<%= orderRow["zipcode"] %><br />
						</p>
					</div>
				</div>
				<div class="container-fluid d-flex justify-content-between">
					<div class="col-lg-3 pl-0">
						<p class="mb-0 mt-5">Order Date : <%= string.Format("{0:dd-MM-yyyy}",orderRow["added_on"]) %></p>
					</div>
				</div>
				<div class="container-fluid mt-5 d-flex justify-content-center w-100">
					<div class="table-responsive w-100">
						<table class="table">
							<thead>
								<tr class="bg-dark">
									<th>#</th>
									<th>Description</th>									
									<th class="text-right">Unit cost</th>
									<th class="text-right">Quantity</th>
									<th class="text-right">Total</th>
								</tr>
							</thead>
							<tbody>
								<% 
                                    int total_price = 0;
                                    int i = 1;
                                    foreach (int key in getOrderDetails.Keys)
                                    {
                                        int item_price = Convert.ToInt32(getOrderDetails[key]["qty"]) * Convert.ToInt32(getOrderDetails[key]["price"]);
                                        total_price = total_price + item_price;
								%>
									<tr class="text-right">
										<td class="text-left"><%= i %></td>
										<td class="text-left"><%=getOrderDetails[key]["dish_name"] %>(<%=getOrderDetails[key]["attribute"] %>)</td>
										<td>₹ <%=getOrderDetails[key]["price"] %></td>
										<td><%=getOrderDetails[key]["qty"] %></td>										
										<td>₹ <%=item_price %></td>
									</tr>
								<% 
                                        i = i + 1;
                                    }
								%>
								
								
							</tbody>
						</table>
					</div>
				</div>
				<div class="container-fluid mt-5 w-100">
					<% 
                        string coupon_code = orderRow["coupon_code"];
                        if (!string.IsNullOrEmpty(coupon_code))
                        {
                    %>	
							<h6 class="text-right mb-5">Total : ₹ <%=total_price %></h6>
							<h5 class="text-right mb-5">Coupon Code : <%=orderRow["coupon_code"] %></h5>
							<h4 class="text-right mb-5">Final Total : ₹ <%= Math.Round(Convert.ToDecimal(orderRow["final_price"])) %></h4>
					<%
                        }
                        else
						{
					%>
						<h4 class="text-right mb-5">Total : ₹ <%=total_price %></h4>
					<%
						}
					%>
					<hr>
				</div>
				<div class="container-fluid w-100">
					<a href="../user/download_invoice.aspx?id=<%=oid %>" class="btn btn-primary float-right mt-4 ml-2"><i class="mdi mdi-printer mr-1"></i>PDF</a>
				</div>
				<br /><br /><br />
				<div>					
					<h4>Order Status:- <%=orderRow["order_status_str"] %></h4>					
					<asp:DropDownList ID="ddlorderstatus" runat="server" class="form-control wSelect200" name="order_status" AutoPostBack="True" OnSelectedIndexChanged="ddlorderstatus_SelectedIndexChanged">
					</asp:DropDownList>
					<div class="login_msg" id="error" runat="server"  style="margin-top:10px; display:none" >
				  </div>
					<br />						
					<h4>Delivery Boy:- <%=deliveryBoy %></h4>
					<asp:DropDownList ID="ddldeliveryboy" runat="server" class="form-control wSelect200" name="delivery_boy" AutoPostBack="True" OnSelectedIndexChanged="ddldeliveryboy_SelectedIndexChanged"></asp:DropDownList>
				</div>
			</div>
		</div>
	</div>
</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</form>
</asp:Content>
