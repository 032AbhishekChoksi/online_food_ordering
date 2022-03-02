<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRedirect.aspx.cs" Inherits="online_food_ordering.user.pgRedirect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Merchant Check Out Page</title>
</head>
<body>
    <center><h1>Please do not refresh this page...</h1></center>
		<form method="post" action="<%= PAYTM_TXN_URL %>" name="f1">
		<table border="1">
			<tbody>
				<% foreach (string key in paramList.Keys) { %>
					<input type="hidden" name='<%= key %>' value='<%= paramList[key] %>' />
				<% } %>
				<input type="hidden" name="CHECKSUMHASH" value='<%= checksum %>' />
			</tbody>
		</table>
		<script type="text/javascript">
			document.f1.submit();
        </script>
	</form>
</body>
</html>
