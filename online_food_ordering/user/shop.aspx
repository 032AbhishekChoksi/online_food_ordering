<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="online_food_ordering.user.shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c2" runat="server">
    <div class="breadcrumb-area gray-bg">
        <div class="container">
            <div class="breadcrumb-content">
                <ul>
                    <li><a href="index.html">Home</a></li>
                    <li class="active">Shop Grid Style </li>
                </ul>
            </div>
        </div>
    </div>
<div class="shop-page-area pt-25 pb-25">
        <div class="container">
            <div class="row flex-row-reverse">
                <div class="col-lg-9">
                    <div class="banner-area pb-30">
                        <img alt="Billy Banner" src="assets/img/banner/banner-49.jpg">
                    </div>
                    <div class="grid-list-product-wrapper">
                        <div class="product-grid product-view pb-20">
                            <div class="row">
                                <div class="main-wrapper">
                                    <div class="container">
                                        <div class="display-style-btns">
                                            <button type="button" id="grid-active-btn">
                                                <i class="fas fa-th"></i>
                                            </button>
                                            <button type="button" id="details-active-btn">
                                                <i class="fas fa-list-ul"></i>
                                            </button>
                                        </div>
                                        <%--Dish--%>
                                         <form id="f1" runat="server">
                                             <div class="item-list">
                                                 <asp:Repeater ID="rDishCategory" runat="server" OnItemDataBound="rDishCategory_ItemDataBound">
                                                     <ItemTemplate>
                                                         <div class="item">
                                                             <div class="item-img">
                                                                 <a target="_blank" href='../media/dish/<%# Eval("image") %>'>
                                                                     <img src='../media/dish/<%# Eval("image") %>' style="margin: auto auto; display: block;">
                                                                 </a>
                                                                 <div class="icon-list">
                                                                     <button type="button">
                                                                         <i class="fas fa-sync-alt"></i>
                                                                     </button>
                                                                     <button type="button">
                                                                         <i class="fas fa-shopping-cart" aria-hidden="true" onclick="add_to_cart('<%# Eval("did") %>','add')"></i>
                                                                     </button>
                                                                     <button type="button">
                                                                         <i class="far fa-heart"></i>
                                                                     </button>
                                                                 </div>
                                                             </div>
                                                             <div class="item-detail">
                                                                 <img src='assets/img/icon-img/<%# Eval("dishtype").ToString().Trim(' ')%>.png' alt="" class="imge" style="height: 25px; width: 25px;" />
                                                                 <a href="#" class="item-name"><%# Eval("dish_name") %></a>
                                                                 <div class="item-radio" style="margin-top: 5px;">
                                                                     <asp:HiddenField ID="hdid" runat="server" Value='<%# Eval("did") %>' />
                                                                     <asp:Repeater ID="rDishDetails" runat="server">
                                                                         <ItemTemplate>
                                                                             <input type='radio' style='width: 16px; height: 12px; margin-right: 5px; margin-left: 5px;' name='radio_<%# Eval("dish_id") %>' id='radio_<%# Eval("dish_id") %>' value='<%# Eval("DDID") %>' />
                                                                             <%# Eval("attribute") %>
                                                                        &nbsp;
                                                                        <span>(₹ <%# Math.Round(Convert.ToDecimal(Eval("price"))) %>)                                            
                                                                            <span style='font-size: 12px;color:#e02c2b !important;' id='shop_added_msg_<%# Eval("DDID")%>'></span>
                                                                             <br />
                                                                            </ItemTemplate>
                                                                     </asp:Repeater>
                                                                 </div>
                                                                 <div class="item-price" style="margin-top: -5px;">
                                                                     <select id='qty<%# Eval("did") %>'>
                                                                         <option value="0">Qty</option>
                                                                         <% for (int i = 1; i <=10; i++)
                                                                             {%>
                                                                         <option value='<%= i %>'><%= i %></option>
                                                                         <%} %>
                                                                     </select>

                                                                 </div>
                                                                 <p><%# Eval("dish_desc") %></p>
                                                                 <button type="button" class="add-btn" onclick="add_to_cart('<%# Eval("did") %>','add')">add to cart</button>
                                                             </div>
                                                         </div>
                                                     </ItemTemplate>
                                                 </asp:Repeater>

                                             </div>
                                             </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="shop-sidebar-wrapper gray-bg-7 shop-sidebar-mrg">
                        <div class="shop-widget">
                            <h4 class="shop-sidebar-title">Shop By Categories</h4>
                            <div class="shop-catigory">
                                <ul id="faq">
                                    <li><a href="#">Vegetables</a> </li>
                                    <li><a href="#">Fruits</a></li>
                                    <li><a href="#">Red Meat</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
    function set_checkbox(id) {
        // alert(id);
        var cat_dish = jQuery('#cat_dish').val();
        var check = cat_dish.search(":" + id);
        if (check != '-1') {
            cat_dish = cat_dish.replace(":" + id, '');
        } else {
            cat_dish = cat_dish + ":" + id;
        }
        jQuery('#cat_dish').val(cat_dish);
        jQuery('#frmCatDish')[0].submit();
    }

    function setFoodType(dish_type) {
        jQuery('#dish_type').val(dish_type);
        jQuery('#frmCatDish')[0].submit();

    }

    function setSearch() {
        jQuery('#search_str').val(jQuery('#search').val());
        jQuery('#frmCatDish')[0].submit();
    }
    </script>
</asp:Content>
