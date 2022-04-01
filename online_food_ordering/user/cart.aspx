<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="online_food_ordering.user.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c2" runat="server">
    <div class="cart-main-area pt-60 pb-85">
    <div class="container">
        <h3 class="page-title">Your cart items</h3>
         <%if (websiteclose.Equals("no"))
           { %>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-12">
                        <form method="post" id="f1" runat="server">
                           <% if(cartArr.Count > 0) { %>
                                <div class="table-content table-responsive">
                                    <table>
                                        <thead>
                                            <tr>
                                                <th>Image</th>
                                                <th>Product Name</th>
                                                <th>Until Price</th>
                                                <th>Qty</th>
                                                <th>Subtotal</th>
                                                <th>action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <%  foreach (int key in cartArr.Keys) {  %>
                                                    <input type="hidden" id="hid" name="hid" value='<%= key %>'>
                                                    <tr>
                                                        <td class="product-thumbnail">
                                                            <a href='../media/dish/<%= cartArr[key]["image"] %>' target="_blank"><img src='../media/dish/<%= cartArr[key]["image"] %>' alt='image_<%= cartArr[key]["dish"] %>' width="75px"></a>
                                                        </td>
                                                        <td class="product-name"><%= cartArr[key]["dish"] %></td>
                                                        <td class="product-price-cart"><span class="amount"><%= cartArr[key]["price"] %> Rs.</span></td>
                                                        <td class="product-quantity">
                                                            <div class="cart-plus-minus">
                                                                <input class="cart-plus-minus-box" type="text" name="qty" value='<%= cartArr[key]["qty"] %>'>
                                                            </div>
                                                        </td>
                                                        <td class="product-subtotal"><%= Convert.ToInt32(cartArr[key]["qty"]) * Convert.ToInt32(cartArr[key]["price"]) %> Rs.</td>
                                                        <td class="product-remove">
                                                            <a href="javascript:void(0)" onclick="delete_cart('<%= key %>','load')"><i class="fa fa-times"></i></a>
                                                        </td>
                                                    </tr>
                                             <% } %>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="cart-shiping-update-wrapper">
                                            <div class="cart-shiping-update">
                                                <a href="shop">Continue Shopping</a>
                                            </div>
                                            <div class="cart-clear">
                                                <button name="update_cart" id="update_cart" type="submit">Update Shopping Cart</button>
                                               <%--<asp:Button id="btnupdate_cart" runat="server" Text="Update Shopping Cart" name="update_cart" OnClick="btnupdate_cart_Click" />--%>
                                                <a href="checkout">Checkout</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                          <%  } else { %>
                                <label name="lblEmpty Cart">Empty Cart</label>
                           <% } %>
                        </form>
                    </div>
                </div>
         <%}
           else
           {						
         %>
                <center><strong><%=websiteclosemsg %></strong></center>
         <%}%>
    </div>
</div>
</asp:Content>
