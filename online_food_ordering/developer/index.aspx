<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="online_food_ordering.developer.index" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name = "keywords" content="Billy,Online food,food,food around me,Admin,DeliveryBoy,Developer,restaurants near me now,nearby restaurants,places to eat near me,Billy,ordering " />
  <meta name = "description" content="Billy,Online Food Ordering,Admin" />
  <meta name = "author" content="Billy" />
  <title></title>
  <!-- plugins:css -->
  <!-- https://pictogrammers.github.io/@mdi/font/1.0.62/ -->
  <link rel="shortcut icon" href="../billy.ico">
  <link rel="stylesheet" href="../admin/assets/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="../admin/assets/css/vendor.bundle.base.css">
  <link rel="stylesheet" href="../admin/assets/css/dataTables.bootstrap4.css">
  <!-- endinject -->
  <!-- Plugin css for this page -->
  <link rel="stylesheet" href="../admin/assets/css/bootstrap-datepicker.min.css">
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link id="lnkstyle" runat="server" rel="stylesheet" href="../admin/assets/css/style.css">
</head>
<body class="sidebar-light">
    <div class="container-scroller">
      <!-- partial:partials/_navbar.html -->
      <nav class="navbar col-lg-12 col-12 p-0 fixed-top d-flex flex-row">
         <div class="navbar-menu-wrapper d-flex align-items-stretch justify-content-between">
            <div class="text-center navbar-brand-wrapper d-flex align-items-center justify-content-center">
               <a class="navbar-brand brand-logo" href="index.aspx"><img src="../user/assets/img/logo/logo.png" alt="logo" style="height: 35px;width: 118px;margin-left:8px;" /></a>
               <a class="navbar-brand brand-logo-mini" href="index.aspx"><img src="../user/assets/img/logo/logo.png" alt="logo" style="height: 35px;width: 118px;margin-left:8px;" /></a>
            </div>
            <ul class="navbar-nav navbar-nav-right">
               <li class="nav-item nav-profile dropdown">
                  <a class="nav-link dropdown-toggle" href="#" data-toggle="dropdown" id="profileDropdown">
                     <span class="nav-profile-name">
                         <asp:Label ID="lblDEVELOPER_USER" runat="server"></asp:Label></span>
                  </a>
                  <div class="dropdown-menu dropdown-menu-right navbar-dropdown" aria-labelledby="profileDropdown">
                     <div class="dropdown-divider"></div>
                     <a class="dropdown-item" href="logout.aspx">
                        <i class="mdi mdi-logout text-primary"></i>
                        Logout
                     </a>
                  </div>
               </li>
            </ul>
         </div>
      </nav>
      <!-- partial -->
      <div class="container-fluid page-body-wrapper">
         <div class="main-panel" style="width:100%;">
            <div class="content-wrapper">
               <div class="card">
                  <div class="card-body">
                     <h1 class="grid_title">Maintenance</h1>
                     <div class="row grid_box">
                        <div class="col-12">
                           <div class="table-responsive">
                               <form id="f1" runat="server">
                                   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                       <ContentTemplate>
                                           <table id="order-listing" class="table">
                                               <tr>
                                                   <th width="35%">Admin</th>
                                                   <th width="33%">Customer</th>
                                                   <th width="33%">DeliveryBoy</th>
                                               </tr>
                                               <tr>
                                                   <td>
                                                       <div class="btn-group" role="group" aria-label="Basic example">
                                                           <asp:Button ID="btnAdminOn" runat="server" CssClass="btn btn-success" Text="ON" OnClick="btnAdminOn_Click" />
                                                           <asp:Button ID="btnAdminOFF" runat="server" CssClass="btn btn-default" Text="OFF" OnClick="btnAdminOFF_Click" />
                                                       </div>
                                                       <br />
                                                       <br />
                                                       <asp:Label ID="lbladmin" runat="server"></asp:Label>
                                                   </td>
                                                   <td>

                                                       <div class="btn-group" role="group" aria-label="Basic example">
                                                           <asp:Button ID="btnCUSTON" runat="server" CssClass="btn btn-success" Text="ON" OnClick="btnCUSTON_Click" />
                                                           <asp:Button ID="btncustOFF" runat="server" CssClass="btn btn-default" Text="OFF" OnClick="btncustOFF_Click" />
                                                       </div>
                                                       <br />
                                                       <br />
                                                       <asp:Label ID="lblcust" runat="server"></asp:Label>
                                                   </td>
                                                   <td>
                                                       <div class="btn-group" role="group" aria-label="Basic example">
                                                           <asp:Button ID="btnDeliveryOn" runat="server" CssClass="btn btn-success" Text="ON" OnClick="btnDeliveryOn_Click" />
                                                           <asp:Button ID="btnDeliveryOFF" runat="server" CssClass="btn btn-default" Text="OFF" OnClick="btnDeliveryOFF_Click" />
                                                       </div>
                                                       <br />
                                                       <br />
                                                       <asp:Label ID="lbldeli" runat="server"></asp:Label>
                                                   </td>
                                               </tr>
                                           </table>
                                       </ContentTemplate>
                                   </asp:UpdatePanel>
                               </form>                       
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
            <!-- content-wrapper ends -->
            <!-- partial:partials/_footer.html -->
            <footer class="footer">
               <div class="d-sm-flex justify-content-center justify-content-sm-between">
                  <span class="text-muted text-center text-sm-left d-block d-sm-inline-block">
                     Copyright &copy; <%: DateTime.Now.Year %> <a href="../user/index.aspx" target="_blank">Billy</a>. All rights reserved.                     
                  </span>
               </div>
            </footer>
            <!-- partial -->
         </div>
         <!-- main-panel ends -->
      </div>
      <!-- page-body-wrapper ends -->
   </div>
   <!-- container-scroller -->

   <!-- plugins:js -->
   <script src="../admin/assets/js/vendor.bundle.base.js"></script>
   <script src="../admin/assets/js/jquery.dataTables.js"></script>
   <script src="../admin/assets/js/dataTables.bootstrap4.js"></script>
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
   <script src="../admin/assets/js/data-table.js"></script>
   <!-- End custom js for this page-->
</body>
</html>