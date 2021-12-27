<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="manage_dish.aspx.cs" Inherits="online_food_ordering.admin.manage_dish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	
<div class="row">
	<h1 class="grid_title ml10 ml15">Dish</h1>
	<div class="col-12 grid-margin stretch-card">
		<div class="card">
			<div class="card-body">
				<form id="fo1" runat="server" class="forms-sample" method="post" enctype="multipart/form-data">
					<div class="form-group">
						<asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
						<asp:DropDownList ID="category_id" runat="server" class="form-control" name="category_id">

						</asp:DropDownList>
						<%--<select>
							<option value="">Select Category</option>
							<?php
							while ($row_category = mysqli_fetch_assoc($res_category)) {
								if ($row_category['id'] == $category_id) {
									echo "<option value='" . $row_category['id'] . "' selected>" . $row_category['category'] . "</option>";
								} else {
									echo "<option value='" . $row_category['id'] . "'>" . $row_category['category'] . "</option>";
								}
							}
							?>
						</select>--%>
					</div>

					<div class="form-group">
						<label for="exampleInputName1">Dish</label>
						<input type="text" class="form-control" placeholder="dish" name="dish" required value="<?php echo $dish ?>">
						<div class="error mt8"><?php echo $msg ?></div>
					</div>
					<div class="form-group">
						<label for="exampleInputName1">Type</label>
						<select class="form-control" name="type" required>
							<option value="">Select Type</option>
							<?php
							foreach ($arrType as $list) {
								if ($list == $food_type) {
									echo "<option value='$list' selected>" . strtoupper($list) . "</option>";
								} else {
									echo "<option value='$list'>" . strtoupper($list) . "</option>";
								}
							}
							?>
						</select>

					</div>
					<div class="form-group">
						<label for="exampleInputEmail3" required>Dish Detail</label>
						<textarea name="dish_detail" class="form-control" placeholder="Dish Detail"><?php echo $dish_detail ?></textarea>
					</div>
					<div class="form-group">
						<label for="exampleInputEmail3">Dish Image</label>
						<input type="file" class="form-control" placeholder="Dish Image" name="image" <?php echo $image_status ?>>
						<div class="error mt8"><?php echo $image_error ?></div>
					</div>
					<div class="form-group" id="dish_box1">
						<label for="exampleInputEmail3">Dish Attributes</label>
						<?php if ($id == 0) { ?>
							<div class="row">
								<div class="col-4">
									<input type="text" class="form-control" placeholder="Attribute" name="attribute[]" required>
								</div>
								<div class="col-3">
									<input type="text" class="form-control" placeholder="Price" name="price[]" required>
								</div>
								<div class="col-3">
									<select name="status[]" class="form-control" required>
										<option value="1">Active</option>
										<option value="0">Deactive</option>
									</select>
								</div>
							</div>
							<?php } else {
							$dish_details_res = mysqli_query($con, "select * from dish_details where dish_id='$id'");
							$ii = 1;
							while ($dish_details_row = mysqli_fetch_assoc($dish_details_res)) {
							?>
								<div class="row mt8">
									<div class="col-4">
										<input type="hidden" name="dish_details_id[]" value="<?php echo $dish_details_row['id'] ?>">
										<input type="text" class="form-control" placeholder="Attribute" name="attribute[]" required value="<?php echo $dish_details_row['attribute'] ?>">
									</div>
									<div class="col-3">
										<input type="text" class="form-control" placeholder="Price" name="price[]" required value="<?php echo $dish_details_row['price'] ?>">
									</div>
									<div class="col-3">
										<select name="status[]" class="form-control" required>
											<?php if ($dish_details_row['status'] == 1) { ?>
												<option value="1" selected>Active</option>
												<option value="0">Deactive</option>
											<?php } else { ?>
												<option value="1">Active</option>
												<option value="0" selected>Deactive</option>
											<?php } ?>
										</select>
									</div>
									<?php if ($ii != 1) {
									?>
										<div class="col-2"><button type="button" class="btn badge-danger mr-2" onclick="remove_more_new('<?php echo $dish_details_row['id'] ?>')">Remove</button></div>

									<?php
									}
									?>
								</div>
						<?php
								$ii++;
							}
						} ?>
					</div>

					<button type="submit" class="btn btn-primary mr-2" name="submit">Submit</button>

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
		var html = '<div class="row mt8" id="box' + add_more + '"><div class="col-4"><input type="text" class="form-control" placeholder="Attribute" name="attribute[]" required></div><div class="col-3"><input type="text" class="form-control" placeholder="Price" name="price[]" required></div><div class="col-3"><select name="status[]" class="form-control" required><option value="1">Active</option><option value="0">Deactive</option></select></div><div class="col-2"><button type="button" class="btn badge-danger mr-2" onclick=remove_more("' + add_more + '")>Remove</button></div></div>';
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
