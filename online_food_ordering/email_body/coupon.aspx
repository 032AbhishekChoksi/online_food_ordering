﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="coupon.aspx.cs" Inherits="online_food_ordering.email_body.coupon" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>Coupon Code</title>
  <!-- inject:css -->
  <%--<link rel="stylesheet" href="../admin/assets/css/style.css">--%>
    <style>
        .card {
  position: relative;
  display: flex;
  flex-direction: column;
  min-width: 0;
  word-wrap: break-word;
  background-color: #fff;
  background-clip: border-box;
  border: 1px solid #e9e8ef;
  border-radius: 0;
}

* {
  box-sizing: border-box;
}

body {
  font-size: 1rem;
  font-family: "Roboto", sans-serif;
  font-weight: initial;
  line-height: normal;
  -webkit-font-smoothing: antialiased;
}

body {
  margin: 0;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
  font-size: 1rem;
  font-weight: 400;
  line-height: 1.5;
  color: #000000;
  text-align: left;
  background-color: #fff;
}

/*.card .card-body {
  padding: 1.88rem 1.81rem;
}

.card-body {
  flex: 1 1 auto;
  padding: 1.25rem;
}*/

.btn, .fc button, .ajax-upload-dragdrop .ajax-file-upload, .swal2-modal .swal2-buttonswrapper .swal2-styled, .swal2-modal .swal2-buttonswrapper .swal2-styled.swal2-confirm, .swal2-modal .swal2-buttonswrapper .swal2-styled.swal2-cancel, .wizard > .actions a,
.btn-group.open .dropdown-toggle,
.fc .open.fc-button-group .dropdown-toggle,
.btn:active,
.fc button:active,
.ajax-upload-dragdrop .ajax-file-upload:active,
.swal2-modal .swal2-buttonswrapper .swal2-styled:active,
.wizard > .actions a:active, .btn:focus, .fc button:focus, .ajax-upload-dragdrop .ajax-file-upload:focus, .swal2-modal .swal2-buttonswrapper .swal2-styled:focus, .wizard > .actions a:focus, .btn:hover, .fc button:hover, .ajax-upload-dragdrop .ajax-file-upload:hover, .swal2-modal .swal2-buttonswrapper .swal2-styled:hover, .wizard > .actions a:hover,
.btn:visited,
.fc button:visited,
.ajax-upload-dragdrop .ajax-file-upload:visited,
.swal2-modal .swal2-buttonswrapper .swal2-styled:visited,
.wizard > .actions a:visited,
a,
a:active,
a:checked,
a:focus,
a:hover,
a:visited,
body,
button,
button:active,
button:hover,
button:visited,
div,
input,
input:active,
input:focus,
input:hover,
input:visited,
select,
select:active,
select:focus,
select:visited,
textarea,
textarea:active,
textarea:focus,
textarea:hover,
textarea:visited {
  -webkit-box-shadow: none;
  -moz-box-shadow: none;
  box-shadow: none;
}

h1, h2, h3, h4, h5, h6 {
  margin-top: 0;
  margin-bottom: 20px;
}
h1, .h1 {
  font-size: 1.875rem;
}

h1, h2, h3, h4, h5, h6,
.h1, .h2, .h3, .h4, .h5, .h6 {
  font-weight: 500;
}

h1, h2, h3, h4, h5, h6,
.h1, .h2, .h3, .h4, .h5, .h6 {
  margin-bottom: 0.5rem;
  font-weight: 500;
  line-height: 1.2;
}

h1, h2, h3, h4, h5, h6 {
  margin-top: 0;
  margin-bottom: 0.5rem;
}

.row {
  display: flex;
  flex-wrap: wrap;
  margin-right: -15px;
  margin-left: -15px;
}
.col-12 {
  flex: 0 0 100%;
  max-width: 100%;
}

.col-1, .col-2, .col-3, .col-4, .col-5, .col-6, .lightGallery .image-tile, .col-7, .col-8, .col-9, .col-10, .col-11, .col-12, .col,
.col-auto, .col-sm-1, .col-sm-2, .col-sm-3, .col-sm-4, .col-sm-5, .col-sm-6, .col-sm-7, .col-sm-8, .col-sm-9, .col-sm-10, .col-sm-11, .col-sm-12, .col-sm,
.col-sm-auto, .col-md-1, .col-md-2, .col-md-3, .col-md-4, .col-md-5, .col-md-6, .col-md-7, .col-md-8, .col-md-9, .col-md-10, .col-md-11, .col-md-12, .col-md,
.col-md-auto, .col-lg-1, .col-lg-2, .col-lg-3, .col-lg-4, .col-lg-5, .col-lg-6, .col-lg-7, .col-lg-8, .col-lg-9, .col-lg-10, .col-lg-11, .col-lg-12, .col-lg,
.col-lg-auto, .col-xl-1, .col-xl-2, .col-xl-3, .col-xl-4, .col-xl-5, .col-xl-6, .col-xl-7, .col-xl-8, .col-xl-9, .col-xl-10, .col-xl-11, .col-xl-12, .col-xl,
.col-xl-auto {
  position: relative;
  width: 100%;
  padding-right: 15px;
  padding-left: 15px;
}
.table-responsive {
  display: block;
  width: 100%;
  overflow-x: auto;
  -webkit-overflow-scrolling: touch;
}

.table, .jsgrid .jsgrid-table {
  margin-bottom: 0;
}

.table, .jsgrid .jsgrid-table {
  width: 100%;
  margin-bottom: 1rem;
  color: #212529;
}

table {
  border-collapse: collapse;
}
.grid_title {
	margin-bottom: 20px;
}

.footer {
  background: #f1f2f7;
  padding: 30px 1rem;
  transition: all 0.25s ease;
  -moz-transition: all 0.25s ease;
  -webkit-transition: all 0.25s ease;
  /*-ms-transition: all 0.25s ease;*/
  font-size: calc(0.875rem - 0.05rem);
  font-family: "Roboto", sans-serif;
  font-weight: 400;
  border-top: 1px solid rgba(0, 0, 0, 0.06);
}

article, aside, figcaption, figure, footer, header, hgroup, main, nav, section {
  display: block;
}

*,
*::before,
*::after {
  box-sizing: border-box;
}
@media (max-width: 991px) {
  .footer {
    margin-left: 0;
    width: 100%;
  }
}
@media (min-width: 576px) {
  .flex-sm-row {
    flex-direction: row !important;
  }
  .flex-sm-column {
    flex-direction: column !important;
  }
  .flex-sm-row-reverse {
    flex-direction: row-reverse !important;
  }
  .flex-sm-column-reverse {
    flex-direction: column-reverse !important;
  }
  .flex-sm-wrap {
    flex-wrap: wrap !important;
  }
  .flex-sm-nowrap {
    flex-wrap: nowrap !important;
  }
  .flex-sm-wrap-reverse {
    flex-wrap: wrap-reverse !important;
  }
  .flex-sm-fill {
    flex: 1 1 auto !important;
  }
  .flex-sm-grow-0 {
    flex-grow: 0 !important;
  }
  .flex-sm-grow-1 {
    flex-grow: 1 !important;
  }
  .flex-sm-shrink-0 {
    flex-shrink: 0 !important;
  }
  .flex-sm-shrink-1 {
    flex-shrink: 1 !important;
  }
  .justify-content-sm-start {
    justify-content: flex-start !important;
  }
  .justify-content-sm-end {
    justify-content: flex-end !important;
  }
  .justify-content-sm-center {
    justify-content: center !important;
  }
  .justify-content-sm-between {
    justify-content: space-between !important;
  }
  .justify-content-sm-around {
    justify-content: space-around !important;
  }
  .align-items-sm-start {
    align-items: flex-start !important;
  }
  .align-items-sm-end {
    align-items: flex-end !important;
  }
  .align-items-sm-center {
    align-items: center !important;
  }
  .align-items-sm-baseline {
    align-items: baseline !important;
  }
  .align-items-sm-stretch {
    align-items: stretch !important;
  }
  .align-content-sm-start {
    align-content: flex-start !important;
  }
  .align-content-sm-end {
    align-content: flex-end !important;
  }
  .align-content-sm-center {
    align-content: center !important;
  }
  .align-content-sm-between {
    align-content: space-between !important;
  }
  .align-content-sm-around {
    align-content: space-around !important;
  }
  .align-content-sm-stretch {
    align-content: stretch !important;
  }
  .align-self-sm-auto {
    align-self: auto !important;
  }
  .align-self-sm-start {
    align-self: flex-start !important;
  }
  .align-self-sm-end {
    align-self: flex-end !important;
  }
  .align-self-sm-center {
    align-self: center !important;
  }
  .align-self-sm-baseline {
    align-self: baseline !important;
  }
  .align-self-sm-stretch {
    align-self: stretch !important;
  }
}
  
  .justify-content-center, .email-wrapper .message-body .attachments-sections ul li .thumb {
  justify-content: left !important;
}

@media (min-width: 576px) {
  .d-sm-none {
    display: none !important;
  }
  .d-sm-inline {
    display: inline !important;
  }
  .d-sm-inline-block {
    display: inline-block !important;
  }
  .d-sm-block {
    display: block !important;
  }
  .d-sm-table {
    display: table !important;
  }
  .d-sm-table-row {
    display: table-row !important;
  }
  .d-sm-table-cell {
    display: table-cell !important;
  }
  .d-sm-flex {
    display: flex !important;
  }
  .d-sm-inline-flex {
    display: inline-flex !important;
  }
}

.text-muted, .preview-list .preview-item .preview-item-content p .content-category, .email-wrapper .mail-sidebar .menu-bar .profile-list-item a .user .u-designation, .email-wrapper .mail-list-container .mail-list .content .message_text, .email-wrapper .mail-list-container .mail-list .details .date {
  color: #9b9b9b !important;
}

@media (min-width: 576px) {
  .text-sm-left {
    text-align: left !important;
  }
  .text-sm-right {
    text-align: right !important;
  }
  .text-sm-center {
    text-align: center !important;
  }
}

.text-center {
  text-align: center !important;
}

* Tables *
.table, .jsgrid .jsgrid-table {
  margin-bottom: 0;
}

.table thead th, .jsgrid .jsgrid-table thead th {
  background: #F7F4F8;
  border-top: 0;
  border-bottom-width: 1px;
  font-weight: 500;
  font-size: .875rem;
}

.table thead th i, .jsgrid .jsgrid-table thead th i {
  margin-left: 0.325rem;
}

.table th, .jsgrid .jsgrid-table th,
.table td,
.jsgrid .jsgrid-table td {
  vertical-align: middle;
  line-height: 1;
}

.table tbody td, .jsgrid .jsgrid-table tbody td {
  font-size: 0.875rem;
}

.table tbody td img, .jsgrid .jsgrid-table tbody td img {
  width: 36px;
  height: 36px;
  border-radius: 100%;
}

.table tbody td .badge, .jsgrid .jsgrid-table tbody td .badge {
  margin-bottom: 0;
}

.table tbody tr:first-child, .jsgrid .jsgrid-table tbody tr:first-child {
  border-top: 0;
}

.table.table-borderless, .jsgrid .table-borderless.jsgrid-table {
  border: none;
}

.table.table-borderless tr, .jsgrid .table-borderless.jsgrid-table tr,
.table.table-borderless td,
.jsgrid .table-borderless.jsgrid-table td,
.table.table-borderless th,
.jsgrid .table-borderless.jsgrid-table th {
  border: none;
}


.table, .jsgrid .jsgrid-table {
  width: 100%;
  margin-bottom: 1rem;
  color: #212529;
}

.table th, .jsgrid .jsgrid-table th,
.table td,
.jsgrid .jsgrid-table td {
  padding: 1.25rem 0.9375rem;
  vertical-align: top;
  border-top: 1px solid #e9e8ef;
}

.table thead th, .jsgrid .jsgrid-table thead th {
  vertical-align: bottom;
  border-bottom: 2px solid #e9e8ef;
}

.table tbody + tbody, .jsgrid .jsgrid-table tbody + tbody {
  border-top: 2px solid #e9e8ef;
}

.table-sm th,
.table-sm td {
  padding: 0.3rem;
}

.table-bordered {
  border: 1px solid #e9e8ef;
}

.table-bordered th,
.table-bordered td {
  border: 1px solid #e9e8ef;
}

.table-bordered thead th,
.table-bordered thead td {
  border-bottom-width: 2px;
}

.table-borderless th,
.table-borderless td,
.table-borderless thead th,
.table-borderless tbody + tbody {
  border: 0;
}

.table-striped tbody tr:nth-of-type(odd) {
  background-color: #eaeaf1;
}

.table-hover tbody tr:hover {
  color: #212529;
  background-color: #eaeaf1;
}

.table-primary,
.table-primary > th,
.table-primary > td {
  background-color: #d2c2d8;
}

.table-primary th,
.table-primary td,
.table-primary thead th,
.table-primary tbody + tbody {
  border-color: #ab8eb6;
}

.table-hover .table-primary:hover {
  background-color: #c7b2ce;
}

.table-hover .table-primary:hover > td,
.table-hover .table-primary:hover > th {
  background-color: #c7b2ce;
}

.table-secondary,
.table-secondary > th,
.table-secondary > td {
  background-color: #f4f5f5;
}

.table-secondary th,
.table-secondary td,
.table-secondary thead th,
.table-secondary tbody + tbody {
  border-color: #ebeced;
}

.table-hover .table-secondary:hover {
  background-color: #e7e9e9;
}

.table-hover .table-secondary:hover > td,
.table-hover .table-secondary:hover > th {
  background-color: #e7e9e9;
}

.table-success,
.table-success > th,
.table-success > td {
  background-color: #b8efde;
}

.table-success th,
.table-success td,
.table-success thead th,
.table-success tbody + tbody {
  border-color: #7ae1c2;
}

.table-hover .table-success:hover {
  background-color: #a3ead4;
}

.table-hover .table-success:hover > td,
.table-hover .table-success:hover > th {
  background-color: #a3ead4;
}

.table-info,
.table-info > th,
.table-info > td {
  background-color: #cdbdf2;
}

.table-info th,
.table-info td,
.table-info thead th,
.table-info tbody + tbody {
  border-color: #a284e7;
}

.table-hover .table-info:hover {
  background-color: #bda8ee;
}

.table-hover .table-info:hover > td,
.table-hover .table-info:hover > th {
  background-color: #bda8ee;
}

.table-warning,
.table-warning > th,
.table-warning > td {
  background-color: #ffeeb8;
}

.table-warning th,
.table-warning td,
.table-warning thead th,
.table-warning tbody + tbody {
  border-color: #ffdf7a;
}

.table-hover .table-warning:hover {
  background-color: #ffe89f;
}

.table-hover .table-warning:hover > td,
.table-hover .table-warning:hover > th {
  background-color: #ffe89f;
}

.table-danger,
.table-danger > th,
.table-danger > td {
  background-color: #fed8ca;
}

.table-danger th,
.table-danger td,
.table-danger thead th,
.table-danger tbody + tbody {
  border-color: #fdb69d;
}

.table-hover .table-danger:hover {
  background-color: #fec6b1;
}

.table-hover .table-danger:hover > td,
.table-hover .table-danger:hover > th {
  background-color: #fec6b1;
}

.table-light,
.table-light > th,
.table-light > td {
  background-color: #fdfdfe;
}

.table-light th,
.table-light td,
.table-light thead th,
.table-light tbody + tbody {
  border-color: #fbfcfc;
}

.table-hover .table-light:hover {
  background-color: #ececf6;
}

.table-hover .table-light:hover > td,
.table-hover .table-light:hover > th {
  background-color: #ececf6;
}

.table-dark,
.table-dark > th,
.table-dark > td {
  background-color: #ceccd2;
}

.table-dark th,
.table-dark td,
.table-dark thead th,
.table-dark tbody + tbody {
  border-color: #a3a1ac;
}

.table-hover .table-dark:hover {
  background-color: #c1bec6;
}

.table-hover .table-dark:hover > td,
.table-hover .table-dark:hover > th {
  background-color: #c1bec6;
}

.table-active,
.table-active > th,
.table-active > td {
  background-color: rgba(0, 0, 0, 0.075);
}

.table-hover .table-active:hover {
  background-color: rgba(0, 0, 0, 0.075);
}

.table-hover .table-active:hover > td,
.table-hover .table-active:hover > th {
  background-color: rgba(0, 0, 0, 0.075);
}

.table .thead-dark th, .jsgrid .jsgrid-table .thead-dark th {
  color: #fff;
  background-color: #343a40;
  border-color: #454d55;
}

.table .thead-light th, .jsgrid .jsgrid-table .thead-light th {
  color: #495057;
  background-color: #e9ecef;
  border-color: #e9e8ef;
}

.table-dark {
  color: #fff;
  background-color: #343a40;
}

.table-dark th,
.table-dark td,
.table-dark thead th {
  border-color: #454d55;
}

.table-dark.table-bordered {
  border: 0;
}

.table-dark.table-striped tbody tr:nth-of-type(odd) {
  background-color: rgba(255, 255, 255, 0.05);
}

.table-dark.table-hover tbody tr:hover {
  color: #fff;
  background-color: rgba(255, 255, 255, 0.075);
}

@media (max-width: 575.98px) {
  .table-responsive-sm {
    display: block;
    width: 100%;
    overflow-x: auto;
    -webkit-overflow-scrolling: touch;
  }
  .table-responsive-sm > .table-bordered {
    border: 0;
  }
}

@media (max-width: 767.98px) {
  .table-responsive-md {
    display: block;
    width: 100%;
    overflow-x: auto;
    -webkit-overflow-scrolling: touch;
  }
  .table-responsive-md > .table-bordered {
    border: 0;
  }
}

@media (max-width: 991.98px) {
  .table-responsive-lg {
    display: block;
    width: 100%;
    overflow-x: auto;
    -webkit-overflow-scrolling: touch;
  }
  .table-responsive-lg > .table-bordered {
    border: 0;
  }
}

@media (max-width: 1199.98px) {
  .table-responsive-xl {
    display: block;
    width: 100%;
    overflow-x: auto;
    -webkit-overflow-scrolling: touch;
  }
  .table-responsive-xl > .table-bordered {
    border: 0;
  }
}

.table-responsive {
  display: block;
  width: 100%;
  overflow-x: auto;
  -webkit-overflow-scrolling: touch;
}

.table-responsive > .table-bordered {
  border: 0;
}
th {
  text-align: inherit;
}

table {
  border-collapse: collapse;
}

.footer a {
  color: #5e2572;
  font-size: inherit;
}


    </style>
    
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