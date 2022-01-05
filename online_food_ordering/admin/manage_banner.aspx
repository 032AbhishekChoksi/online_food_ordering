<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_banner.aspx.cs" Inherits="online_food_ordering.admin.manage_banner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	<div class="row">
	<h1 class="grid_title ml10 ml15">Manage Banner</h1>
	<div class="col-12 grid-margin stretch-card">
		<div class="card">
			<div class="card-body">
				<form id="fo1" runat="server" class="forms-sample" method="post" enctype="multipart/form-data">
					<div class="form-group">
						<asp:Label ID="lblimage" runat="server" Text="Image"></asp:Label>
						<asp:FileUpload ID="f1" accept="image/*" runat="server" name="image" class="form-control" placeholder="Banner Image" />
						<div class="error mt8"><asp:Label ID="lblerror" runat="server"></asp:Label></div>
					</div>
					<div class="form-group">
						<asp:Label ID="lblheading" runat="server" Text="Heading"></asp:Label>
						<asp:TextBox ID="txtheading" runat="server" class="form-control" placeholder="Heading" name="heading"></asp:TextBox>
					</div>
					<div class="form-group">
						<asp:Label ID="lblsub_heading" runat="server" Text="Sub Heading"></asp:Label>
						<asp:TextBox ID="txtsub_heading" runat="server" class="form-control" placeholder="Sub Heading" name="sub_heading"></asp:TextBox>
					</div>
					<div class="form-group">
						<asp:Label ID="lbllink" runat="server" Text="Link"></asp:Label>
						<asp:TextBox ID="txtlink" runat="server" class="form-control" placeholder="Link" name="link"></asp:TextBox>
					</div>
					<div class="form-group">
						<asp:Label ID="lbllink_txt" runat="server" Text="Link Text"></asp:Label>
						<asp:TextBox ID="txtlink_txt" runat="server" class="form-control" placeholder="Link Text" name="link_txt"></asp:TextBox>
					</div>
					<div class="form-group">
						<asp:Label ID="lblbannerorder" runat="server" Text="Order Number"></asp:Label>
						<asp:TextBox ID="txtbannerorder" runat="server" class="form-control" placeholder="Order Number" name="order_number" TextMode="Number"></asp:TextBox>
					</div>
					<asp:Button ID="bttnsubmit" runat="server" Text="Submit" class="btn btn-primary mr-2" name="submit" OnClick="bttnsubmit_Click" />
				</form>
			</div>
		</div>
	</div>

</div>
</asp:Content>
