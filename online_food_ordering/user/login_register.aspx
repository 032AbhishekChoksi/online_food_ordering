﻿<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="login_register.aspx.cs" Inherits="online_food_ordering.user.login_register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c2" runat="server">
    <div class="login-register-area pt-95 pb-100">
    <div class="container">
        <div class="row">
            <div class="col-lg-7 col-md-12 ml-auto mr-auto">
                <div class="login-register-wrapper">
                    <div class="login-register-tab-list nav">
                        <a class="active" data-toggle="tab" href="#lg1">
                            <h4> login </h4>
                        </a>
                        <a data-toggle="tab" href="#lg2">
                            <h4> register </h4>
                        </a>
                    </div>
                    <div class="tab-content">
                        <div id="lg1" class="tab-pane active">
                            <div class="login-form-container">
                                <%if (websiteclose.Equals("no"))
                                  { %>
                                    <div class="login-register-form">
                                        <form method="post" id="frmLogin">
                                            <input type="email" name="user_email" placeholder="Email" required>
                                            <input type="password" name="user_password" placeholder="Password" required>
                                                <div class="button-box">
                                                    <div class="login-toggle-btn">
                                                        <%-- <input type="checkbox">
                                                        <label>Remember me</label>--%>
                                                        <a href="forgot_password.aspx">Forgot Password?</a>
                                                    </div>
                                                    <button type="submit" id="login_submit"><span>Login</span></button>
                                                    <input type="hidden" name="type" value="login" />
                                                    <input type="hidden" name="is_checkout" id="is_checkout" value=""/>
                                                    <div id="form_login_msg" style="margin-top: 18px; margin-bottom: 3px; color: green;font: bolder;font-size: larger;"></div>
                                                </div>                                       
                                        </form>
                                    </div>                               
                                    <div id="g-signin2"></div>
                                <%}
					              else
					              {						
					            %>
                                    <center><strong><%=websiteclosemsg %></strong></center>
					            <%}%>
                            </div>
                        </div>
                        <div id="lg2" class="tab-pane">
                            <div class="login-form-container">
                                <%if (websiteclose.Equals("no"))
                                  { %>
                                    <div class="login-register-form">
                                        <form method="post" id="frmRegister">
                                            <input type="text" name="name" id="name" placeholder="Name" required>
                                            <input name="email" id="email" placeholder="Email" type="email" required>
                                            <div id="email_error" style="margin-top: -27px; margin-bottom: 3px; color: #e02c2b;font: bolder;"></div>
                                            <input type="password" name="password" id="password" placeholder="Password" required>
                                            <input name="mobile" id="mobile" placeholder="Mobile" type="tel" required>
                                            <div class="g-recaptcha" data-sitekey="6LdoQi8dAAAAAEHhF2q4BP-TTtaSh2vkAs85om4I"></div><br/>
                                            <div class="button-box">
                                                <button type="submit" id="register_submit"><span>Register</span></button>
                                            </div>
                                            <input type="hidden" name="type" value="register" />
                                            <div id="form_msg" style="margin-top: 18px; margin-bottom: 3px;font: bolder;font-size: larger;"></div>
                                        </form>
                                    </div>
                                <%}
					              else
					              {						
					            %>
                                    <center><strong><%=websiteclosemsg %></strong></center>
					            <%}%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
