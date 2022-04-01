<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="online_food_ordering.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c2" runat="server">
    <div class="checkout-area pb-80 pt-100">
	<div class="container">
		<%if (websiteclose.Equals("no"))
		  { %>
			<div class="row">
				<div class="col-lg-9">
					<div class="checkout-wrapper">
						<div id="faq" class="panel-group">
							<div class="panel panel-default">
								<div class="panel-heading">
									<h5 class="panel-title"><span>1.</span> <a data-toggle="collapse" data-parent="#faq" href="#payment-1">Checkout method</a></h5>
								</div>
								<div id='<%= box_id %>' class="panel-collapse collapse <%= is_show %>">
									<div class="panel-body">
										<div class="row">
											<div class="col-lg-12">
												<div class="checkout-login">
													<div>
														<h4 class="cart-bottom-title section-bg-white">LOGIN</h4>
													</div>
													<p>&nbsp;</p>
													<form method="post" id="frmLogin">
														<div class="login-form">
															<label>Email Address * </label>
															<input type="email" name="user_email" placeholder="Email" required>
														</div>
														<div class="login-form">
															<label>Password *</label>
															<input type="password" name="user_password" placeholder="Password" required>
															<input type="hidden" name="type" value="login" />
															<input type="hidden" name="is_checkout" value="yes" id="is_checkout" />
														</div>
														<div class="button-box">
															<div class="login-toggle-btn">
																<button type="submit" id="login_submit"><span>Login</span></button>
																<a href="login_register">Register Now</a>
															</div>
														</div>
													</form>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="panel panel-default">
								<div class="panel-heading">
									<h5 class="panel-title"><span>2.</span> <a data-toggle="collapse" data-parent="#faq" href="#payment-2">Other information</a></h5>
								</div>
								<div id='<%= final_box_id %>' class="panel-collapse collapse <%= final_show %>">
									<div class="panel-body">
										<form method="post" id="f1" runat="server">
											<div class="billing-information-wrapper">
												<div class="row">
													<% if (userArr != null)
													   { %>
														<div class="col-lg-3 col-md-6">
															<div class="billing-info">
																<label>Customer Name</label>
																<input type="text" name="checkout_name" id="checkout_name" required value='<%= userArr["name"] %>' readonly>
															</div>
														</div>
														<div class="col-lg-3 col-md-6">
															<div class="billing-info">
																<label>Email Address</label>
																<input type="email" name="checkout_email" required value='<%= userArr["email"] %>' readonly>
															</div>
														</div>
														<div class="col-lg-3 col-md-6">
															<div class="billing-info">
																<label>Mobile</label>
																<input type="tel" name="checkout_mobile" required value='<%= userArr["mobile"] %>' readonly>
															</div>
														</div>
													<% } %>
													<div class="col-lg-3 col-md-6">
														<div class="billing-info">
															<label>Zip/Postal Code</label>
															<input type="number" name="checkout_zip" value='<%= userAddress["postal"] %>' required>
														</div>
													</div>
													<div class="col-lg-12 col-md-12">
														<div class="billing-info">
															<label>Address</label>
															<input type="text" name="checkout_address" required value='<%= semiAdreess%>'>
														</div>
													</div>
													<div class="col-lg-3 col-md-12">
														<div class="billing-info">
															<label>Coupon Code</label>
															<input type="text" name="coupon_code" id="coupon_code">
														</div>
														<div id="coupon_code_msg"></div>
													</div>
													<div class="col-lg-5 col-md-12">
														<div class="billing-back-btn">
															<div class="billing-btn">
																<button type="button" name="place_order" onclick="apply_coupon()">Apply Coupon</button>
															</div>
														</div>
													</div>
												</div>
												<div class="ship-wrapper">
													<div class="single-ship">
														<input type="radio" name="payment_type" value="cod" checked="checked">
														<label>Cash on Delivery(COD)</label>
													</div>
													<div class="single-ship">
														<input type="radio" name="payment_type" value="paytm">
														<label>PayTm</label>
													</div>
													<div class="single-ship">
														<input type="radio" name="payment_type" value="Razorpay" disabled='disabled'>
														<label>Razorpay</label>
													</div>
													<div class="single-ship">
														<input type="radio" name="payment_type" value="wallet" <%= is_dis %> >
														<label>Wallet</label>
														<span style="color:red;font-size:12px;">
															<%= low_msg %>
														</span>
													</div>
													<!--<div class="single-ship">
																<input type="radio" name="address" value="address">
																<label>Ship to different address</label>
															</div>-->
												</div>
												<div class="billing-back-btn">
													<div class="billing-btn">
														<button type="submit" name="place_order">Place Your Order</button>
													</div>
												</div>
												<% if(is_error.Equals("yes")) { %>
														<div style='color:red;'><%= cart_min_price_msg %></div>
												<% } %>
											</div>
										</form>
									</div>
								</div>
							</div>

						</div>
					</div>
				</div>
				<div class="col-lg-3">
					<div class="checkout-progress" style="padding: 10px;">
						<div class="shopping-cart-content-box">
							<h4 class="checkout_title">Cart Details</h4>
							<ul>
								   <%  foreach (int key in cartArr.Keys) {  %>
									<li class="single-shopping-cart">
										<div class="shopping-cart-img">
											<a href='../media/dish/<%= cartArr[key]["image"] %>' target="_blank"><img src='../media/dish/<%= cartArr[key]["image"] %>' alt='image_<%= cartArr[key]["dish"] %>' style="width:50%"></a>
										</div>
										<div class="shopping-cart-title">
											<h4><%= cartArr[key]["dish"] %></h4>
											<h6>Price: <%= cartArr[key]["price"] %> Rs.</h6>
											<h6>Qty: <%= cartArr[key]["qty"] %></h6>
											<span><%= Convert.ToInt32(cartArr[key]["qty"]) * Convert.ToInt32(cartArr[key]["price"]) %> Rs.</span>
										</div>
									</li>
								<% } %>
							</ul>
							<div class="shopping-cart-total">
								<h4>Total : <span class="shop-total"><%= totalPrice %> Rs.</span></h4>
							</div>
							<div class="shopping-cart-total coupon_price_box">
								<h4>Coupon Code : <span class="shop-total coupon_code_str"></span></h4>
							</div>
							<div class="shopping-cart-total coupon_price_box">
								<h4>Final Price : <span class="shop-total final_price"><%= final_price %> Rs.</span></h4>
								<input type="hidden" name="amt"  id="amt" value="<%= razoramt %>" />
							</div>
						</div>
					</div>
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
