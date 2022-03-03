<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="online_food_ordering.user.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c2" runat="server">
    <div class="myaccount-area pb-25 pt-50">
    <div class="container">
        <div class="row">
            <div class="ml-auto mr-auto col-lg-9">
                <div>
                    <h4>Referral Code: <%= getUserDetailsByid["referral_code"] %></h4><br />
                    <h4>Referral Link: https://localhost:44350/user/login_register?referral_code=<%= getUserDetailsByid["referral_code"] %></h4><br />

                </div>
                <div class="checkout-wrapper">
                    <div id="faq" class="panel-group">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5 class="panel-title"><span>1</span> <a data-toggle="collapse" data-parent="#faq" href="#my-account-1">Edit your account information </a></h5>
                            </div>
                            <div id="my-account-1" class="panel-collapse collapse show">
                                <div class="panel-body">
                                    <form method="post" id="frmProfile">
                                        <div class="billing-information-wrapper">
                                            <div class="account-info-wrapper">
                                                <h4>My Account Information</h4>
                                                <h5>Your Personal Details</h5>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg- col-md-6">
                                                    <div class="billing-info">
                                                        <label>Name</label>
                                                        <input type="text" name="name" required value='<%= getUserDetailsByid["name"] %>'>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-info">
                                                        <label>Mobile Number</label>
                                                        <input type="tel" name="mobile" required value='<%= getUserDetailsByid["mobile"] %>'>
                                                    </div>
                                                </div>
                                                <div class="col-lg-12 col-md-12">
                                                    <div class="billing-info">
                                                        <label>Email Address</label>
                                                        <input type="email" value='<%= getUserDetailsByid["email"] %>' readonly>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="billing-back-btn">
                                                <div class="billing-back">
                                                    <a data-toggle="collapse" data-parent="#faq" href="#my-account-1"><i class="ion-arrow-up-c"></i> back</a>
                                                </div>
                                                <div class="billing-btn">
                                                    <button type="submit" id="profile_submit">Save</button>
                                                </div>
                                            </div>
                                            <div id="form_msg" style="color: green;margin-top: 4px;"></div>
                                        </div>
                                        <input type="hidden" name="type" value="profile" />
                                    </form>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h5 class="panel-title"><span>2</span> <a data-toggle="collapse" data-parent="#faq" href="#my-account-2">Change your password </a></h5>
                            </div>
                            <div id="my-account-2" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <form method="post" id="frmPassword">
                                        <div class="billing-information-wrapper">
                                            <div class="account-info-wrapper">
                                                <h4>Change Password</h4>
                                                <h5>Your Password</h5>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12">
                                                    <div class="billing-info">
                                                        <label>Password</label>
                                                        <input type="password" name="old_password" required>
                                                    </div>
                                                </div>
                                                <div class="col-lg-12 col-md-12">
                                                    <div class="billing-info">
                                                        <label>New Password</label>
                                                        <input type="password" name="new_password" required>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="billing-back-btn">
                                                <div class="billing-back">
                                                    <a data-toggle="collapse" data-parent="#faq" href="#my-account-2"><i class="ion-arrow-up-c"></i> back</a>
                                                </div>
                                                <div class="billing-btn">
                                                    <button type="submit" id="password_submit">Save</button>
                                                </div>
                                            </div>
                                            <div id="password_form_msg" style="color: green;margin-top: 4px;"></div>
                                            <input type="hidden" name="type" value="password" />
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>
</div>
</asp:Content>
