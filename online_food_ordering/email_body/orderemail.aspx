<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderemail.aspx.cs" Inherits="online_food_ordering.email_body.orderemail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
	<meta http-equiv="x-ua-compatible" content="ie=edge">
	<meta name = "keywords" content="Billy,Online food,food,food around me,restaurants near me now,nearby restaurants,places to eat near me,Billy,ordering " />
	<meta name = "description" content="Billy,Online Food Ordering" />
	<meta name = "author" content="Billy" />
    <title>Order Invoice</title>
    <style type="text/css" rel="stylesheet" media="all">
    /* Base ------------------------------ */
    
    @import url("https://fonts.googleapis.com/css?family=Nunito+Sans:400,700&display=swap");
    body {
      width: 100% !important;
      height: 100%;
      margin: 0;
      -webkit-text-size-adjust: none;
    }
    
    a {
      color: #3869D4;
    }
    
    a img {
      border: none;
    }
    
    td {
      word-break: break-word;
    }
    
    .preheader {
      display: none !important;
      visibility: hidden;
      mso-hide: all;
      font-size: 1px;
      line-height: 1px;
      max-height: 0;
      max-width: 0;
      opacity: 0;
      overflow: hidden;
    }
    /* Type ------------------------------ */
    
    body,
    td,
    th {
      font-family: "Nunito Sans", Helvetica, Arial, sans-serif;
    }
    
    h1 {
      margin-top: 0;
      color: #333333;
      font-size: 22px;
      font-weight: bold;
      text-align: left;
    }
    
    h2 {
      margin-top: 0;
      color: #333333;
      font-size: 16px;
      font-weight: bold;
      text-align: left;
    }
    
    h3 {
      margin-top: 0;
      color: #333333;
      font-size: 14px;
      font-weight: bold;
      text-align: left;
    }
    
    td,
    th {
      font-size: 16px;
    }
    
    p,
    ul,
    ol,
    blockquote {
      margin: .4em 0 1.1875em;
      font-size: 16px;
      line-height: 1.625;
    }
    
    p.sub {
      font-size: 13px;
    }
    /* Utilities ------------------------------ */
    
    .align-right {
      text-align: right;
    }
    
    .align-left {
      text-align: left;
    }
    
    .align-center {
      text-align: center;
    }
    /* Buttons ------------------------------ */
    
    .button {
      background-color: #3869D4;
      border-top: 10px solid #3869D4;
      border-right: 18px solid #3869D4;
      border-bottom: 10px solid #3869D4;
      border-left: 18px solid #3869D4;
      display: inline-block;
      color: #FFF;
      text-decoration: none;
      border-radius: 3px;
      box-shadow: 0 2px 3px rgba(0, 0, 0, 0.16);
      -webkit-text-size-adjust: none;
      box-sizing: border-box;
    }
    
    .button--green {
      background-color: #22BC66;
      border-top: 10px solid #22BC66;
      border-right: 18px solid #22BC66;
      border-bottom: 10px solid #22BC66;
      border-left: 18px solid #22BC66;
    }
    
    .button--red {
      background-color: #FF6136;
      border-top: 10px solid #FF6136;
      border-right: 18px solid #FF6136;
      border-bottom: 10px solid #FF6136;
      border-left: 18px solid #FF6136;
    }
    
    @media only screen and (max-width: 500px) {
      .button {
        width: 100% !important;
        text-align: center !important;
      }
    }
    /* Attribute list ------------------------------ */
    
    .attributes {
      margin: 0 0 21px;
    }
    
    .attributes_content {
      background-color: #F4F4F7;
      padding: 16px;
    }
    
    .attributes_item {
      padding: 0;
    }
    /* Related Items ------------------------------ */
    
    .related {
      width: 100%;
      margin: 0;
      padding: 25px 0 0 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
    }
    
    .related_item {
      padding: 10px 0;
      color: #CBCCCF;
      font-size: 15px;
      line-height: 18px;
    }
    
    .related_item-title {
      display: block;
      margin: .5em 0 0;
    }
    
    .related_item-thumb {
      display: block;
      padding-bottom: 10px;
    }
    
    .related_heading {
      border-top: 1px solid #CBCCCF;
      text-align: center;
      padding: 25px 0 10px;
    }
    /* Discount Code ------------------------------ */
    
    .discount {
      width: 100%;
      margin: 0;
      padding: 24px;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      background-color: #F4F4F7;
      border: 2px dashed #CBCCCF;
    }
    
    .discount_heading {
      text-align: center;
    }
    
    .discount_body {
      text-align: center;
      font-size: 15px;
    }
    /* Social Icons ------------------------------ */
    
    .social {
      width: auto;
    }
    
    .social td {
      padding: 0;
      width: auto;
    }
    
    .social_icon {
      height: 20px;
      margin: 0 8px 10px 8px;
      padding: 0;
    }
    /* Data table ------------------------------ */
    
    .purchase {
      width: 100%;
      margin: 0;
      padding: 35px 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
    }
    
    .purchase_content {
      width: 100%;
      margin: 0;
      padding: 25px 0 0 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
    }
    
    .purchase_item {
      padding: 10px 0;
      color: #51545E;
      font-size: 15px;
      line-height: 18px;
    }
    
    .purchase_heading {
      padding-bottom: 8px;
      border-bottom: 1px solid #EAEAEC;
    }
    
    .purchase_heading p {
      margin: 0;
      color: #85878E;
      font-size: 12px;
    }
    
    .purchase_footer {
      padding-top: 15px;
      border-top: 1px solid #EAEAEC;
    }
    
    .purchase_total {
      margin: 0;
      text-align: right;
      font-weight: bold;
      color: #333333;
    }
    
    .purchase_total--label {
      padding: 0 15px 0 0;
    }
    
    body {
      background-color: #F4F4F7;
      color: #51545E;
    }
    
    p {
      color: #51545E;
    }
    
    p.sub {
      color: #6B6E76;
    }
    
    .email-wrapper {
      width: 100%;
      margin: 0;
      padding: 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      background-color: #F4F4F7;
    }
    
    .email-content {
      width: 100%;
      margin: 0;
      padding: 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
    }
    /* Masthead ----------------------- */
    
    .email-masthead {
      padding: 25px 0;
      text-align: center;
    }
    
    .email-masthead_logo {
      width: 94px;
    }
    
    .email-masthead_name {
      font-size: 16px;
      font-weight: bold;
      color: #A8AAAF;
      text-decoration: none;
      text-shadow: 0 1px 0 white;
    }
    /* Body ------------------------------ */
    
    .email-body {
      width: 100%;
      margin: 0;
      padding: 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      background-color: #FFFFFF;
    }
    
    .email-body_inner {
      width: 570px;
      margin: 0 auto;
      padding: 0;
      -premailer-width: 570px;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      background-color: #FFFFFF;
    }
    
    .email-footer {
      width: 570px;
      margin: 0 auto;
      padding: 0;
      -premailer-width: 570px;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      text-align: center;
    }
    
    .email-footer p {
      color: #6B6E76;
    }
    
    .body-action {
      width: 100%;
      margin: 30px auto;
      padding: 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      text-align: center;
    }
    
    .body-sub {
      margin-top: 25px;
      padding-top: 25px;
      border-top: 1px solid #EAEAEC;
    }
    
    .content-cell {
      padding: 35px;
    }
    /*Media Queries ------------------------------ */
    
    @media only screen and (max-width: 600px) {
      .email-body_inner,
      .email-footer {
        width: 100% !important;
      }
    }
    
    @media (prefers-color-scheme: dark) {
      body,
      .email-body,
      .email-body_inner,
      .email-content,
      .email-wrapper,
      .email-masthead,
      .email-footer {
        background-color: #333333 !important;
        color: #FFF !important;
      }
      p,
      ul,
      ol,
      blockquote,
      h1,
      h2,
      h3 {
        color: #FFF !important;
      }
      .attributes_content,
      .discount {
        background-color: #222 !important;
      }
      .email-masthead_name {
        text-shadow: none !important;
      }
    }
    </style>
</head>
<body>
    <span class="preheader">This is an invoice for your purchase on Billy</span>
    <table class="email-wrapper" width="100%" cellpadding="0" cellspacing="0" role="presentation">
      <tr>
        <td align="center">
          <table class="email-content" width="100%" cellpadding="0" cellspacing="0" role="presentation">
            <tr>
              <td class="email-masthead">
                <a href="" class="f-fallback email-masthead_name">
                <img src="https://i.ibb.co/6myys4W/logo-1.png"/>
              </a>
              </td>
            </tr>
            <!-- Email Body -->
            <tr>
              <td class="email-body" width="100%" cellpadding="0" cellspacing="0">
                <table class="email-body_inner" align="center" width="570" cellpadding="0" cellspacing="0" role="presentation">
                  <!-- Body content -->
                  <tr>
                    <td class="content-cell">
                      <div class="f-fallback">
                          <h1>Hi  <%= customername %> ,</h1>
                          <p>This is an invoice for your recent purchase.</p>
                        <table class="attributes" width="100%" cellpadding="0" cellspacing="0" role="presentation">
                            <tr>
                                <td class="attributes_content">
                                    <table width="100%" cellpadding="0" cellspacing="0" role="presentation">
                                        <tr>
                                            <td class="attributes_item">
                                                <span class="f-fallback">
                                                    <strong>Amount Due:</strong>  <%= total_amount %>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="attributes_item">
                                                <span class="f-fallback">
                                                    <strong>Order ID:</strong> <%= order_id %>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <!-- Action -->
                        <table class="purchase" width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2">
                                    <table class="purchase_content" width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <th class="purchase_heading" align="left">
                                                <p class="f-fallback">Description</p>
                                            </th>
                                            <th class="purchase_heading" align="left">
                                                <p class="f-fallback">Qty</p>
                                            </th>
                                            <th class="purchase_heading" align="right">
                                                <p class="f-fallback">Amount</p>
                                            </th>
                                        </tr>
                                        <% 
                                            int total_price = 0;
                                            foreach (int key in getOrderDetails.Keys)
                                            {
                                                int item_price = Convert.ToInt32(getOrderDetails[key]["qty"]) * Convert.ToInt32(getOrderDetails[key]["price"]);
                                                total_price = total_price + item_price;
                                        %>
                                        <tr>
                                            <td width="40%" class="purchase_item"><span class="f-fallback"><%=getOrderDetails[key]["dish_name"] %> (<%=getOrderDetails[key]["attribute"] %>)</span></td>
                                            <td width="40%" class="purchase_item"><span class="f-fallback"><%=getOrderDetails[key]["qty"] %></span>
                                            </td>
                                            <td class="align-right" width="20%" class="purchase_item"><span class="f-fallback">₹  <%= item_price %></span></td>
                                        </tr>
                                        <% } %>
                                        <tr>
                                            <td width="80%" class="purchase_footer" valign="middle" colspan="2">
                                                <p class="f-fallback purchase_total purchase_total--label">Total</p>
                                            </td>
                                            <td width="20%" class="purchase_footer" valign="middle">
                                                <p class="f-fallback purchase_total">₹ <%=total_price %></p>
                                            </td>
                                        </tr>
                                        <% string coupon_code = getOrderById["coupon_code"];
                                            if (!string.IsNullOrEmpty(coupon_code))
                                            {
                                        %>
                                        <tr>
                                            <td width="80%" class="purchase_footer" valign="middle" colspan="2">
                                                <p class="f-fallback purchase_total purchase_total--label">Coupon Code</p>
                                            </td>
                                            <td width="20%" class="purchase_footer" valign="middle">
                                                <p class="f-fallback purchase_total"><%=getOrderById["coupon_code"] %></p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="80%" class="purchase_footer" valign="middle" colspan="2">
                                                <p class="f-fallback purchase_total purchase_total--label">Final Total</p>
                                            </td>
                                            <td width="20%" class="purchase_footer" valign="middle">
                                                <p class="f-fallback purchase_total">₹ <%= Math.Round(Convert.ToDecimal(getOrderById["final_price"])) %></p>
                                            </td>
                                        </tr>
                                        <% } %>
                                    </table>
                                </td>
                          </tr>
                        </table>
                        <p>If you have any questions about this invoice, simply reply to this email or reach out to our <a href="https://localhost:44350/page/privacy_policy.html">support team</a> for help.</p>
                        <p>Cheers,<br/>Billy</p>
                        <!-- Sub copy -->                        
                      </div>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>            
          </table>
        </td>
      </tr>
    </table>
  </body>
</html>
