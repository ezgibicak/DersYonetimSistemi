$(function () {


	$("#Refresh").click(function () {

		$.ajax({
			url: "/Home/Captcha",
			datatype:"json",
			method: "post",
			success: function () {
				$("#imgCaptcha").attr("src", "/Home/Captcha")
			},
			error: function () {

			}


		})


	});
})