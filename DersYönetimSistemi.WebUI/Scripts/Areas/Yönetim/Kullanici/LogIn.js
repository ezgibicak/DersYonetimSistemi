$(
	function () {
$("#btnLogin").click(function () {

	var Model =
	{
		Email: $("#txtEmail").val(),
		Password: $("#txtPassword").val()
	}
	$.ajax({
		url: "/Administration/Home/LogIn",
		data: Model,
		method: "post",
		success: function (response) {

			if (response.Result) {

				Swal.fire({
					type: 'success',
					title: 'İŞLEM BAŞARILI',

				})

				setTimeout(function () {
					window.location.href = "/Administration/Home/Dashboard"
				}, 3000);

			}
			else {
				setTimeout(function () {
					Swal.fire({
						type: 'error',
						title: 'Hata',
						text: 'Kullanıcı Bulunamadı'
					})
				}, 3000);
			}
		},
		error: function () {
			Swal.fire({
				type: 'error',
				title: 'Hata',
				text: 'İşlem Sırasında Hata Oluştu'
			})

		}

	})

});
	})