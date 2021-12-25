<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_category.aspx.cs" Inherits="online_food_ordering.admin.manage_category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	<div class="row">
	<h1 class="grid_title ml10 ml15">Manage Category</h1>
	<div class="col-12 grid-margin stretch-card">
		<div class="card">
			<div class="card-body">
				<form class="forms-sample" runat="server" method="post">
					<div class="form-group">
						<asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
						<asp:TextBox ID="txtcategory" runat="server" class="form-control" placeholder="Category" name="category"></asp:TextBox>
						<div class="error mt8" id="error" runat="server" style="display:none">Category already added</div>
					</div>
					<asp:Button ID="bttnsubmit" runat="server" class="btn btn-primary mr-2" name="submit" Text="Submit" OnClick="bttnsubmit_Click" />
				</form>
			</div>
		</div>
	</div>

</div>

</asp:Content>
