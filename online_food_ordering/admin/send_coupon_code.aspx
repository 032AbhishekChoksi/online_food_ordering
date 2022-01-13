<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="send_coupon_code.aspx.cs" Inherits="online_food_ordering.send_coupon_code" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="card">
        <div class="card-body">
            <h1 class="grid_title">Send Coupon Code</h1>

            <div class="row grid_box">

                <div class="col-12">
                    <form id="form1" runat="server">
                        <div class="table-responsive">
                            <asp:Repeater ID="r1" runat="server">
                                <HeaderTemplate>
                                    <table id="order-listing" class="table">
                                        <thead>
                                            <tr>
                                                <th width="15%">S.No #</th>
                                                <th width="45%">Name</th>
                                                <th width="40%">Email ID</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                        <td><%# Eval("name") %></td>
                                        <td>
                                            <asp:CheckBox ID="rbt_details" runat="server" Text='<%# Eval("email") %>' ClientIDMode="Static" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
					</table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="mt-3">
                            <asp:Button ID="bttnsubmit" runat="server" class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" Text="Send" OnClick="bttnsubmit_Click" />
                        </div>
                    </form>
                </div>
                <div style="margin-top: 4px;">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
