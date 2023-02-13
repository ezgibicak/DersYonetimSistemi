$(function () {

	$("#btnKaydet").click(function () {

		$("#LoadingContainerPart").show();
		var vModel = {
			Sifre: $("#txtSifre").val(),
			YeniSifre: $("#txtYeniSifre").val(),
			YeniSifreTekrar: $("#txtYeniSifreTekrar").val()
		}
		$.ajax({
			url:"/Administration/Home/SifreDegistir",
			data: vModel,
			method: "post",
			datatype: "json",
			success: function (response) {
				$("#LoadingContainerPart").hide();
				if (response.Result) {
					
					Swal.fire({
						title: 'İŞLEM BAŞARILI',
						text: response.Mesaj,
						type: 'success',

						confirmButtonColor: '#3085d6',
						cancelButtonColor: '#d33',
						confirmButtonText: 'TAMAM'

					}).then(
						function () {
							
							window.location.href="/Administration/Home/LogOut"
						}
					)
					
				}
				else {

					Swal.fire({
						type: 'error',
						title: 'HATALI İŞLEM',
						text: response.Mesaj
					})
				}
			},
			error: function () {


			}
		})


	});

	$("#btnResimGüncelle").click(

		function () {

			$("#ResimGüncelle").trigger("click");
		}

	)

	$("#ResimGüncelle").change(

		function () {

			var file = $("#ResimGüncelle")[0].files[0];
			//alert(file.name);

			var formData = new FormData();
			formData.append(file.name, file);

			$.ajax({
				url: "/Administration/Home/ResimGüncelle",
				data: formData,
				method: "post",
				datatype: "json",
				contentType: false,
				processData: false,
				success: function (response) {

					//window.location.reload();
					if (response.Result) {



						var resim = response.UserPhoto;
						$("#img1").attr("src", resim);
						$("#img2").attr("src", resim);
						$("#img3").attr("src", resim);
						$("#img4").attr("src", resim);
						$("#img5").attr("src", resim)




					}
					else {



						Swal.fire(
							'Hatalı İşlem',
							response.Mesaj,
							'error'

						)
					}


				},
				error: function () {


				}

			});





		});

	$("#btnProfilBilgileriDegistir").click(function () {


		var Model = {

			Ad: $("#inputName").val(),
			Soyad: $("#inputLastName").val(),
			Email: $("#inputEmail").val(),
			DogumTarihi: $("#DogumTarihi").val(),
			TelNo: $("#inputTelefon").val(),
		}
		$.ajax({

			url: "/Administration/Home/ProfilBilgileriGüncelle",
			data: Model,
			method: "post",
			datatype: "json",
			success: function (response) {

				if (response.Result) {

					Swal.fire({
						title: 'İŞLEM BAŞARILI',
						text: response.Mesaj,
						type: 'success',

						confirmButtonColor: '#3085d6',
						cancelButtonColor: '#d33',
						confirmButtonText: 'TAMAM'

					})
					

				}
				else {

					Swal.fire({
						type: 'error',
						title: 'HATALI İŞLEM',
						text: response.Mesaj
					})
				}


			},

			error: function () {

				Swal.fire({
					type: 'error',
					title: 'HATALI İŞLEM',
					text: response.Mesaj
				})

			}

		})

	})


})