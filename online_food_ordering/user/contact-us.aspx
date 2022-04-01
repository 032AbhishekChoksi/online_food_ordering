<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="contact-us.aspx.cs" Inherits="online_food_ordering.user.contact_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c2" runat="server">
    <div class="breadcrumb-area gray-bg">
        <div class="container">
            <div class="breadcrumb-content">
                <ul>
                    <li><a href="shop.aspx">Home</a></li>
                    <li class="active">Contact Us </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="contact-area pt-25 pb-25">
        <div class="container">
            <div class="row">
                <div class="col-lg-4 col-md-6 col-12">
                    <div class="contact-info-wrapper text-center mb-30">
                        <div class="contact-info-icon">
                            <i class="ion-ios-location-outline"></i>
                        </div>
                        <div class="contact-info-content">
                            <h4>Our Location</h4>
                            <p>012 345 678 / 123 456 789</p>
                            <p><a href="#">info@example.com</a></p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 col-12">
                    <div class="contact-info-wrapper text-center mb-30">
                        <div class="contact-info-icon">
                            <i class="ion-ios-telephone-outline"></i>
                        </div>
                        <div class="contact-info-content">
                            <h4>Contact us Anytime</h4>
                            <p>Mobile: 012 345 678</p>
                            <p>Fax: 123 456 789</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 col-12">
                    <div class="contact-info-wrapper text-center mb-30">
                        <div class="contact-info-icon">
                            <i class="ion-ios-email-outline"></i>
                        </div>
                        <div class="contact-info-content">
                            <h4>Write Some Words</h4>
                            <p><a href="#">Support24/7@example.com </a></p>
                            <p><a href="#">info@example.com</a></p>
                        </div>
                    </div>
                </div>
            </div>
             <%if (websiteclose.Equals("no"))
               { %>
                    <div class="row">
                        <div class="col-12">
                            <div class="contact-message-wrapper">
                                <h4 class="contact-title">GET IN TOUCH</h4>
                                <div class="contact-message">
                                    <form id="frmContact" method="post">
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="contact-form-style mb-20">
                                                    <input name="cname" id="cname" placeholder="Full Name" type="text" required>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="contact-form-style mb-20">
                                                    <input name="cemail" id="cemail" placeholder="Email Address" type="email" required>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="contact-form-style mb-20">
                                                    <input name="cmobile" id="cmobile" placeholder="Mobile" type="tel" required>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="contact-form-style mb-20">
                                                    <input name="csubject" id="csubject" placeholder="Subject" type="text" required>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="contact-form-style">
                                                    <textarea name="cmessage" id="cmessage" placeholder="Message" required></textarea>
                                                    <button type="submit" id="contact_submit" class="submit btn-style" >SEND MESSAGE</button>
                                                    <input type="hidden" name="type" value="contactus" />
                                                </div>
                                            </div>
                                        </div>
                                    </form>
                                    <div id="form_msg" style="margin-top: 18px; margin-bottom: 3px;font: bolder;font-size: larger;"></div>
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
