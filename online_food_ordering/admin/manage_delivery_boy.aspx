<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_delivery_boy.aspx.cs" Inherits="online_food_ordering.admin.manage_delivery_boy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	<div class="row">
			<h1 class="grid_title ml10 ml15">Manage Delivery Boy</h1>
			<div class="col-12 grid-margin stretch-card">
			  <div class="card">
				<div class="card-body">
				  <form ID="fo1" runat="server" class="forms-sample" method="post">
					<div class="form-group">
						<asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
						<asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Name" name="name"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidatorname" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtname" Display="Dynamic" >Name is mandatory </asp:RequiredFieldValidator>
					</div>
					<div class="form-group">
						<asp:Label ID="lblpassword" runat="server" Text="Password"></asp:Label>
						<asp:TextBox ID="txtpassword" runat="server" class="form-control" placeholder="Password" name="password" TextMode="Password"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidatorpassword" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtpassword" Display="Dynamic">Password is mandatory </asp:RequiredFieldValidator>
					</div>
					<div class="form-group">
						<asp:Label ID="lblmobile" runat="server" Text="Mobile Number"></asp:Label>
						<asp:TextBox ID="txtmobile" runat="server" class="form-control" placeholder="Mobile Number" name="mobile" TextMode="Phone"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidatormobile" runat="server" Style="color:#e02c2b;" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtmobile" Display="Dynamic">Mobile No is mandatory </asp:RequiredFieldValidator>
					 <div class="error mt8" id="error" runat="server" style="display:none">Delivery Boy already added</div>
					</div>
					  <asp:Button ID="bttnsubmit" runat="server" class="btn btn-primary mr-2" name="submit" Text="Submit" OnClick="bttnsubmit_Click" />
				  </form>
				</div>
			  </div>
			</div>			
		 </div>		
</asp:Content>
