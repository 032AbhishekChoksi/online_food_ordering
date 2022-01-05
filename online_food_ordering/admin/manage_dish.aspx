<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_dish.aspx.cs" Inherits="online_food_ordering.admin.manage_dish" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	<div class="row">
		<h1 class="grid_title ml10 ml15">Dish</h1>
		<div class="col-12 grid-margin stretch-card">
			<div class="card">
				<div class="card-body">
					<form id="fo1" runat="server" class="forms-sample" method="post" enctype="multipart/form-data">
						<div class="form-group">
							<asp:Label ID="lblcategory" runat="server" Text="Category"></asp:Label>
							<asp:DropDownList ID="ddtcategory_id" runat="server" class="form-control" name="category_id">
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<asp:Label ID="lbldish" runat="server" Text="Dish"></asp:Label>
							<asp:TextBox ID="txtdish" runat="server" name="dish" class="form-control" placeholder="dish"></asp:TextBox>
							<div class="error mt8" id="error" runat="server" style="display: none">Dish already added</div>
						</div>
						<div class="form-group">
							<asp:Label ID="lbltype" runat="server" Text="Type"></asp:Label>
							<asp:DropDownList ID="ddttype" runat="server" class="form-control" name="type">
								<asp:ListItem Value="" Selected="True">Select Type</asp:ListItem>
								<asp:ListItem Value="veg">Veg</asp:ListItem>
								<asp:ListItem Value="non-veg">Non Veg</asp:ListItem>
							</asp:DropDownList>
						</div>
						<div class="form-group">
							<asp:Label ID="lbldishdetail" runat="server" Text="Dish Detail"></asp:Label>
							<asp:TextBox ID="txtdish_detail" runat="server" name="dish_detail" class="form-control" placeholder="Dish Detail" TextMode="MultiLine"></asp:TextBox>
						</div>
						<div class="form-group">
							<asp:Label ID="lbldishimage" runat="server" Text="Dish Image"></asp:Label>
							<asp:FileUpload ID="f1" accept="image/*" runat="server" name="image" class="form-control" placeholder="Dish Image" />
							<%-- <asp:RegularExpressionValidator
												ID="FileUpLoadValidator" runat="server"
												ErrorMessage="Upload jpeg, jpe and png only."
												ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.png|.PNG)$"
												ControlToValidate="f1" class="error mt8">  
											</asp:RegularExpressionValidator> --%>
							<div class="error mt8"><asp:Label ID="Label1" runat="server"></asp:Label></div>
						</div>



						<div class="form-group" id="dish_box1">
							<asp:Label ID="lbldishattribute" runat="server" Text="Dish Attributes"></asp:Label>
							<% var id = Convert.ToInt32(Request.QueryString["id"]);
								if (id == 0)
								{


							%>
							<div class="row">
								<div class="col-4">
									<input type="text" class="form-control" placeholder="Attribute" name="attribute">
								</div>
								<div class="col-3">
									<input type="text" class="form-control" placeholder="Price" name="price">
								</div>
								<div class="col-3">
									<select name="status" class="form-control">
										<option value="1">Active</option>
										<option value="0">Deactive</option>
									</select>
								</div>
							</div>
							<%}
							else
							{  %>
							<asp:Repeater ID="r1" runat="server">
								<ItemTemplate>
									<div class="row mt8">
										<div class="col-4">
											<input type="hidden" name="dish_details_id" value="<%# Eval("id") %>">

											<input type="text" class="form-control" placeholder="Attribute" name="attribute" value="<%# Eval("attribute") %>">
										</div>
										<div class="col-3">
											<input type="text" class="form-control" placeholder="Price" name="price" required value="<%# Eval("price") %>">
										</div>
										<div class="col-3">
											
											<select name="status" class="form-control">												
												<option value="1" <%# Eval("status").ToString() != "False" ? "selected" : " " %>>Active</option>
												<option value="0" <%# Eval("status").ToString() != "True" ? "selected" : " " %>>Deactive</option>
										</select>
										</div>
										<% var no = noofdishdetails;
											if (no!= 1)
											{ %>
												<div class="col-2">
													<button type="button" class="btn badge-danger mr-2" onclick="remove_more_new('<%# Eval("id") %>')">Remove</button>
												</div>
										
										<% } %>
									</div>
								</ItemTemplate>
							</asp:Repeater>
							<%} %>
						</div>



						<asp:Button ID="bttnsubmit" runat="server" class="btn btn-primary mr-2" Text="Submit" OnClick="bttnsubmit_Click" />
						<button type="button" class="btn badge-danger mr-2" onclick="add_more()">Add More</button>
					</form>
				</div>
			</div>
		</div>

	</div>
	<input type="hidden" id="add_more" value="1" />
	<script>
		function add_more() {
			var add_more = jQuery('#add_more').val();
			add_more++;
			jQuery('#add_more').val(add_more);
			var html = '<div class="row mt8" id="box' + add_more + '"><div class="col-4"><input type="hidden" name="dish_details_id" value="0"><input type="text" class="form-control" placeholder="Attribute" name="attribute"></div><div class="col-3"><input type="text" class="form-control" placeholder="Price" name="price"></div><div class="col-3"><select name="status" class="form-control"><option value="1">Active</option><option value="0">Deactive</option></select></div><div class="col-2"><button type="button" class="btn badge-danger mr-2" onclick=remove_more("' + add_more + '")>Remove</button></div></div>';
			jQuery('#dish_box1').append(html);
		}

		function remove_more(id) {
			jQuery('#box' + id).remove();
		}

		function remove_more_new(id) {
			var result = confirm('Are you sure?');
			if (result == true) {
				var cur_path = window.location.href;
				window.location.href = cur_path + "&dish_details_id=" + id;
			}
		}
	</script>
</asp:Content>
