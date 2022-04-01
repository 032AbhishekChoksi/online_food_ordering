<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="online_food_ordering.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
<h3>Dashboard</h3>
    <div class="row">
        <div class="col-md-6 col-lg-3 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h1 class="font-weight-light mb-4"><%= ToDaySales() %>
                    </h1>
                    <div class="d-flex flex-wrap align-items-center">
                        <div>
                            <h4 class="font-weight-normal">Today Sale</h4>
                        </div>
                        <i class="mdi mdi-shopping icon-lg text-primary ml-auto"></i>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-3 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h1 class="font-weight-light mb-4"><%= SevenDaySales() %>
                    </h1>
                    <div class="d-flex flex-wrap align-items-center">
                        <div>
                            <h4 class="font-weight-normal">7 Days Sale</h4>
                            <p class="text-muted mb-0 font-weight-light">Last 7 Days Sale</p>
                        </div>
                        <i class="mdi mdi-shopping icon-lg text-danger ml-auto"></i>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-3 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h1 class="font-weight-light mb-4"><%= ThirtyDaySales() %>
                    </h1>
                    <div class="d-flex flex-wrap align-items-center">
                        <div>
                            <h4 class="font-weight-normal">30 Days Sale</h4>
                            <p class="text-muted mb-0 font-weight-light">Last 30 Days Sale</p>
                        </div>
                        <i class="mdi mdi-shopping icon-lg text-info ml-auto"></i>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-3 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h1 class="font-weight-light mb-4"><%= OneYearSales() %>
                    </h1>
                    <div class="d-flex flex-wrap align-items-center">
                        <div>
                            <h4 class="font-weight-normal">365 Days Sale</h4>
                            <p class="text-muted mb-0 font-weight-light">Last 365 Days Sale</p>
                        </div>
                        <i class="mdi mdi-shopping icon-lg text-success ml-auto"></i>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-3 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h1 class="font-weight-light mb-4"><%= dishname %><br />
                        <span style="font-size: 20px;"><%= totaldish %></span>
                    </h1>
                    <div class="d-flex flex-wrap align-items-center">
                        <div>
                            <h4 class="font-weight-normal">Most Sale Dish</h4>
                        </div>
                        <i class="mdi mdi-food icon-lg text-primary ml-auto"></i>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-3 grid-margin stretch-card">
            <div class="card">
                <div class="card-body">
                    <h1 class="font-weight-light mb-4"><%= username %>
                        <br />
                        <span style="font-size: 20px;"><%= totalUser %></span>
                    </h1>
                    <div class="d-flex flex-wrap align-items-center">
                        <div>
                            <h4 class="font-weight-normal">Most Active User</h4>
                        </div>
                        <i class="mdi mdi-account icon-lg text-primary ml-auto"></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
	<div class="col-12">
		<div class="card">
			<div class="card-body">
				<h4 class="card-title">Latest 5 Order</h4>
				<div class="table-responsive">
                    <asp:Repeater ID="r1" runat="server">
                        <HeaderTemplate>
					    <table id="order-listing" class="table table-hover">
						    <thead>
							    <tr>
								    <th width="5%">Order Id</th>
								    <th width="20%">Name/Email/Mobile</th>
								    <th width="20%">Address/Zipcode</th>
								    <th width="5%">Price</th>
								    <th width="10%">Payment Type</th>
								    <th width="10%">Payment Status</th>
								    <th width="10%">Order Status</th>
								    <th width="15%">Added On</th>
							    </tr>
						    </thead>
						    <tbody>
						</HeaderTemplate>
							<ItemTemplate>
                                <tr>
                                    <td>
                                        <div class="div_order_id">
                                            <a href="order_detail.aspx?id=<%# Eval("id") %>">
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></a>
                                        </div>
                                    </td>
                                    <td>
                                        <p><%# Eval("name") %></p>
                                        <p><%# Eval("email") %></p>
                                        <p><%# Eval("mobile") %></p>
                                    </td>
                                    <td>
                                        <p><%# Eval("address") %></p>
                                        <p><%# Eval("zipcode") %></p>
                                    </td>
									<td style="font-size: 14px;">
                                        <%# Eval("total_price") %> Rs.<br />
                                        <%# ApplyCoupon(Eval("coupon_code"), Eval("final_price"))[0] %>
                                        <%# ApplyCoupon(Eval("coupon_code"), Eval("final_price"))[1] %>
                                    </td>
                                    <td>
                                        <%# Eval("payment_type") %>
                                    </td>
                                    <td>
                                        <div class="payment_status payment_status_<%# Eval("payment_status") %>"><%# Eval("payment_status") %></div>
                                    </td>
                                    <td><%# Eval("order_status_str") %></td>
                                    <td>
                                        <%# Eval("added_on","{0:dd/MM/yyyy}") %>
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
