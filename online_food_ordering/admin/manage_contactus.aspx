<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_contactus.aspx.cs" Inherits="online_food_ordering.admin.manage_contactus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="card">
    <div class="card-body">
        <h1 class="grid_title">Manage Contact Us</h1>
        <div class="row grid_box">
            <div class="col-12">
                <div class="table-responsive">
                    <asp:Repeater ID="r1" runat="server">
                        <HeaderTemplate>
                            <table id="order-listing" class="table">
                                <thead>
                                    <tr>
                                        <th width="10%">S.No #</th>
                                        <th width="10%">Name</th>
                                        <th width="10%">Email</th>
                                        <th width="10%">Mobile</th>
                                        <th width="20%">Subject</th>
                                        <th width="30%">Message</th>
                                        <th width="10%">Actions</th>
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
                                    <td><%# Eval("subject") %></td>
                                    <td><%# Eval("message") %></td>
                                    <td>
                                        &nbsp;
                                     <asp:HyperLink ID="HyperLinkDeactive" runat="server" NavigateUrl='<%# string.Format("manage_contactus.aspx?id={0}&type=active",Eval("id")) %>' Visible='<%# Eval("status").ToString() != "True" ? true : false %>'>
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
