<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="dish.aspx.cs" Inherits="online_food_ordering.admin.dish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
	
<div class="card">
	<div class="card-body">
		<h1 class="grid_title">Dish Master</h1>
		<a href="manage_dish.aspx" class="add_link">Add Dish</a>
		<div class="row grid_box">

			<div class="col-12">
				<div class="table-responsive">
					  <asp:Repeater ID="r1" runat="server">
					<HeaderTemplate>
					<table id="order-listing" class="table">
						<thead>
							<tr>
								<th width="10%">S.No #</th>
								<th width="15%">Category</th>
								<th width="25%">Dish</th>
								<th width="15%">Image</th>
								<th width="15%">Added On</th>
								<th width="20%">Actions</th>
							</tr>
						</thead>
						<tbody>
							</HeaderTemplate>
					<ItemTemplate>
									<tr>
										<td><?php echo $i ?></td>
										<td><?php echo $row['category'] ?></td>
										<td><?php echo $row['dish'] ?>&nbsp;(<?php echo strtoupper( $row['type']) ?>)</td>
										<td><a target="_blank" href="<?php echo SITE_DISH_IMAGE . $row['image'] ?>"><img src="<?php echo SITE_DISH_IMAGE . $row['image'] ?>" /></a></td>
										<td>
											<?php
											$dateStr = strtotime($row['added_on']);
											echo date('d-m-Y', $dateStr);
											?>
										</td>
										<td>
											<a href="manage_dish.php?id=<?php echo $row['id'] ?>"><label class="badge badge-success hand_cursor">Edit</label></a>&nbsp;
											<?php
											if ($row['status'] == 1) {
											?>
												<a href="?id=<?php echo $row['id'] ?>&type=deactive"><label class="badge badge-danger hand_cursor">Active</label></a>
											<?php
											} else {
											?>
												<a href="?id=<?php echo $row['id'] ?>&type=active"><label class="badge badge-info hand_cursor">Deactive</label></a>
											<?php
											}

											?>
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
</asp:Content>
