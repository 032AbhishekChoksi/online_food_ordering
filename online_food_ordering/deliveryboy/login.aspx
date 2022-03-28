<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="online_food_ordering.deliveryboy.login" %>
<!DOCTYPE html>
<html lang="en">

<head runat="server">
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name = "keywords" content="Billy,Online food,food,food around me,Admin,DeliveryBoy,restaurants near me now,nearby restaurants,places to eat near me,Billy,ordering " />
  <meta name = "description" content="Billy,Online Food Ordering,Admin" />
  <meta name = "author" content="Billy" />
  <title>Food Ordering Delivery Boy Login</title>
  <!-- plugins:css -->
  <link rel="shortcut icon" href="../billy.ico">
  <link rel="stylesheet" href="../admin/assets/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="../admin/assets/css/vendor.bundle.base.css">
  <!-- endinject -->
  <!-- Plugin css for this page -->
  <link rel="stylesheet" href="../admin/assets/css/bootstrap-datepicker.min.css">
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link id="lnkstyle" runat="server" rel="stylesheet" href="../admin/assets/css/style.css">
</head>

<body class="sidebar-light">
  <div class="container-scroller">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper d-flex align-items-center auth">
        <div class="row w-100">
          <div class="col-lg-4 mx-auto">
            <div class="auth-form-light text-left p-5">
              <div class="brand-logo text-center">
                <img src="../admin/assets/images/logo.png" alt="logo">
              </div>
              <h4 class="font-weight-light" style="text-align: center;">Delivery Boy</h4>
              <h6 class="font-weight-light" style="margin-top: 10px;">Sign in to continue.</h6>
              <form class="pt-3" id="f1" runat="server" method="post">
                <div class="form-group">
                    <asp:TextBox ID="txtmobile" runat="server" class="form-control form-control-lg" placeholder="Mobile Number" name="mobile" TextMode="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtmobile" Display="Dynamic" >Mobile Number is mandatory </asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtpassword" runat="server" class="form-control form-control-lg" placeholder="Password" name="password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtpassword" Display="Dynamic" >Password is mandatory </asp:RequiredFieldValidator>
                </div>
                <div class="mt-3">
                    <asp:Button ID="bttnsubmit" runat="server" class="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn" Text="SIGN IN" OnClick="bttnsubmit_Click" />
                </div>

              </form>
              <div class="login_msg" id="error" runat="server"  style="margin-top:10px; display:none">
                  <strong>Please enter valid login details</strong>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>

  <!-- plugins:js -->
  <script src="../admin/assets/js/vendor.bundle.base.js"></script>
  <!-- endinject -->
  <!-- Plugin js for this page -->
  <script src="../admin/assets/js/Chart.min.js"></script>
  <script src="../admin/assets/js/bootstrap-datepicker.min.js"></script>
  <!-- End plugin js for this page -->
  <!-- inject:js -->
  <script src="../admin/assets/js/off-canvas.js"></script>
  <script src="../admin/assets/js/hoverable-collapse.js"></script>
  <script src="../admin/assets/js/template.js"></script>
  <script src="../admin/assets/js/settings.js"></script>
  <script src="../admin/assets/js/todolist.js"></script>
  <!-- endinject -->
  <!-- Custom js for this page-->
  <script src="../admin/assets/js/dashboard.js"></script>
  <!-- End custom js for this page-->
</body>

</html>