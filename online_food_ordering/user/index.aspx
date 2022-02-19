<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="online_food_ordering.user.index" %>
<!doctype html>
<html class="no-js" lang="zxx">

<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name = "keywords" content="Billy,Online food,food,food around me,restaurants near me now,nearby restaurants,places to eat near me,Billy,ordering " />
	<meta name = "description" content="Billy,Online Food Ordering" />
	<meta name = "author" content="Billy" />
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" href="../billy.ico">
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/animate.css">
    <link rel="stylesheet" href="assets/css/owl.carousel.min.css">
    <link rel="stylesheet" href="assets/css/font-awesome.min.css">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="stylesheet" href="assets/css/responsive.css">
    <script src="assets/js/vendor/modernizr-2.8.3.min.js"></script>
</head>

<body>
    <div class="slider-area">
        <div class="slider-active owl-dot-style owl-carousel">
            <asp:Repeater ID="r1" runat="server">
            <ItemTemplate>
            <div class="single-slider pt-210 pb-220 bg-img" style="background-image:url('<%# Eval("image","/media/banner/{0}") %>');">
                <div class="container">
                    <div class="slider-content slider-animated-1">
                        <h1 class="animated"><%# Eval("heading") %></h1>
                        <h3 class="animated"><%# Eval("sub_heading") %></h3>
                        <div class="slider-btn mt-90">
                            <a class="animated" href='<%# Eval("link") %>'><%# Eval("link_text") %></a>
                        </div>
                    </div>
                </div>
            </div>
             </ItemTemplate>            
        </asp:Repeater>
        </div>
    </div>
    <script src="assets/js/vendor/jquery-1.12.0.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/imagesloaded.pkgd.min.js"></script>
    <script src="assets/js/isotope.pkgd.min.js"></script>
    <script src="assets/js/owl.carousel.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/main.js"></script>
</body>

</html>