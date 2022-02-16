function renderButton() {
	gapi.signin2.render('g-signin2', {
		'scope': 'profile email',
		'width': 250,
		'height': 40,
		'longtitle': true,
		'theme': 'dark',
		'onsuccess': onSignIn,
		'onfailure': onFailure
	});
}
function onSignIn(googleUser) {

	var profile = googleUser.getBasicProfile();

	var googleTockenId = profile.getId();
	var name = profile.getName();
	var email = profile.getEmail();
	var image = profile.getImageUrl();
	$("#g-signin2").hide('fast');

	saveUserData(googleTockenId, name, email, image); // save data to our database for reference
}
// Sign-in failure callback
function onFailure(error) {
	alert(error);
}
// Sign out the user
function signOut() {
		var auth2 = gapi.auth2.getAuthInstance();
		auth2.signOut().then(function () {
			$("#loginDetails").hide();
			$("#loaderIcon").hide('fast');
			$("#g-signin2").show('fast');
		});
		auth2.disconnect();
}
function saveUserData(googleTockenId, name, email, image) {
	jQuery.ajax({
		url: 'login_register_submit',
		type: 'post',
		data: 'type=Google' + '&googleTockenId=' + googleTockenId + '&name=' + name + '&email=' + email + '&image=' + image,
		dataType: 'json',
		success: function (result) {
			var data = jQuery.parseJSON(result);
			if (data.status == 'success') {	
				signOut();
				window.location.href = 'shop';
			}
		}
	});
}