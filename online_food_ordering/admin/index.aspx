<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="online_food_ordering.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
		<h3>Dashboard</h3>
    <div class="row">
	<div class="col-md-6 col-lg-3 grid-margin stretch-card">
		<div class="card">
			<div class="card-body">
				<h1 class="font-weight-light mb-4">
					 110 Rs
				</h1>
				<div class="d-flex flex-wrap align-items-center">
					<div>
						<h4 class="font-weight-normal">Today Sale</h4>

					</div>
					<i class="mdi mdi-shopping icon-lg text-primary ml-auto"></i>
				</div>
			</div>
		</div>
	</div>
	<div class="col-md-6 col-lg-3 grid-margin stretch-card">
		<div class="card">
			<div class="card-body">
				<h1 class="font-weight-light mb-4">
						220 Rs
				</h1>
				<div class="d-flex flex-wrap align-items-center">
					<div>
						<h4 class="font-weight-normal">7 Days Sale</h4>
						<p class="text-muted mb-0 font-weight-light">Last 7 Days Sale</p>
					</div>
					<i class="mdi mdi-shopping icon-lg text-danger ml-auto"></i>
				</div>
			</div>
		</div>
	</div>
	<div class="col-md-6 col-lg-3 grid-margin stretch-card">
		<div class="card">
			<div class="card-body">
				<h1 class="font-weight-light mb-4">
					300 Rs
				</h1>
				<div class="d-flex flex-wrap align-items-center">
					<div>
						<h4 class="font-weight-normal">30 Days Sale</h4>
						<p class="text-muted mb-0 font-weight-light">Last 30 Days Sale</p>
					</div>
					<i class="mdi mdi-shopping icon-lg text-info ml-auto"></i>
				</div>
			</div>
		</div>
	</div>
	<div class="col-md-6 col-lg-3 grid-margin stretch-card">
		<div class="card">
			<div class="card-body">
				<h1 class="font-weight-light mb-4">
					350 Rs
				</h1>
				<div class="d-flex flex-wrap align-items-center">
					<div>
						<h4 class="font-weight-normal">365 Days Sale</h4>
						<p class="text-muted mb-0 font-weight-light">Last 365 Days Sale</p>
					</div>
					<i class="mdi mdi-shopping icon-lg text-success ml-auto"></i>
				</div>
			</div>
		</div>
	</div>
		<div class="col-md-6 col-lg-3 grid-margin stretch-card">
			<div class="card">
				<div class="card-body">
					<h1 class="font-weight-light mb-4">
						Raj Kachori<br/>
						<span style="font-size:15px;">10</span>
					</h1>
					<div class="d-flex flex-wrap align-items-center">
						<div>
							<h4 class="font-weight-normal">Most Sale Dish</h4>
						</div>
						<i class="mdi mdi-food icon-lg text-primary ml-auto"></i>
					</div>

				</div>
			</div>
		</div>
		<div class="col-md-6 col-lg-3 grid-margin stretch-card">
			<div class="card">
				<div class="card-body">
					<h1 class="font-weight-light mb-4">
						Abhishek Choksi <br/><span style="font-size:15px;">5</span>
					</h1>
					<div class="d-flex flex-wrap align-items-center">
						<div>
							<h4 class="font-weight-normal">Most Active User</h4>
						</div>
						<i class="mdi mdi-account icon-lg text-primary ml-auto"></i>
					</div>
				</div>
			</div>
</div>
</asp:Content>
