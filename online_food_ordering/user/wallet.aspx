<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="wallet.aspx.cs" Inherits="online_food_ordering.user.wallet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c2" runat="server">
<div class="breadcrumb-area gray-bg">
<div class="container">
    <div class="breadcrumb-content">
        <ul>
            <li><a href="shop.aspx">Home</a></li>
            <li class="active">Wallet</li>
        </ul>
    </div>
</div>
    <div class="cart-main-area pt-50 pb-50">
	<div class="container">
		<div class="row">
			<div class="col-lg-12 col-md-12 col-sm-12 col-12">
				<div id="add_money_box">
					<form method="post" id="frmAddMoney" runat="server">
						<asp:TextBox ID="txtamt" class="w150" runat="server" placeholder="Add Money" name="amt"></asp:TextBox>
						<asp:Button ID="btnsubmit" runat="server" Text="Button" class="btn w150" name="add_money" OnClick="btnsubmit_Click"/><br /><br />
						<div>
							<asp:Label ID="lblMessage" runat="server"></asp:Label>
						</div>
					</form>
				</div>
				<div class="table-content table-responsive">
					<asp:Repeater ID="r1" runat="server">
						<HeaderTemplate>
							<table>
								<thead>
									<tr>
										<th>S.No</th>
										<th>Amt</th>
										<th>Message</th>
										<th>Date</th>
									</tr>
								</thead>
								<tbody>
						</HeaderTemplate>
						<ItemTemplate>
									<tr class="wallet_loop">
										<td><asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
										<td><%# string.Format("₹{0}",Math.Round(FormatAmount(Eval("amt"))))%></td>
										<td>
											<span class="<%# Eval("type") %>">
												<%# Eval("msg") %>
											</span>
										</td>
										<td>
											<%# Eval("added_on","{0:dd-MM-yyyy}") %>
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
