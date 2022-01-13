<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="coupon.aspx.cs" Inherits="online_food_ordering.email_body.coupon" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>Coupon Code</title>
  <!-- inject:css -->
  <%--<link rel="stylesheet" href="../admin/assets/css/style.css">--%>
    
</head>
<body>
    <div class="card">
        <div class="card-body">
            <h1 class="grid_title">Coupon Code Master</h1>
            <div class="row grid_box">
                <div class="col-12">
                    <div class="table-responsive">
                        <asp:Repeater ID="r1" runat="server">
                            <HeaderTemplate>
                                <table id="order-listing" class="table">
                                    <thead>
                                        <tr>
                                            <th width="15%">S.No #</th>
                                            <th width="30%">Code/Value</th>
                                            <th width="30%">Type</th>
                                            <th width="25%">Expired On</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" />
                                    </td>
                                    <td>
                                        <div>
                                            <%# Eval("coupon_code") %> /
											<asp:Label ID="lblcoupon_type" runat="server" Text='<%# CheckCouponCode(Eval("coupon_type"),Eval("coupon_value")) %>'></asp:Label>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# CheckCouponType(Eval("coupon_type")) %>'></asp:Label></td>
                                    <td>
                                        <%# Eval("expired_on","{0:dd-MM-yyyy}") %>
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
    <!-- content-wrapper ends -->
    <!-- partial:partials/_footer.html -->
    <footer class="footer">
        <div class="d-sm-flex justify-content-center justify-content-sm-between">
            <span class="text-muted text-center text-sm-left d-block d-sm-inline-block">Copyright &copy; <%: DateTime.Now.Year %> <a href="index.aspx" target="_blank">Billy</a>. All rights reserved.</span>
        </div>
    </footer>
    <!-- partial -->
</body>
</html>