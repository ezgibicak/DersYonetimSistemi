$(
	function () {
		$(".btnOnayla").click(
			function () {
				var id = $(this).attr("kullaniciid");
				Swal.fire({
					title: 'Kullanıcı Onayı',
					text: "Kullanıcı Onaylanacak Emin Misiniz?",
					type: 'warning',
					showCancelButton: true,
					confirmButtonColor: '#3085d6',
					cancelButtonColor: '#d33',
					confirmButtonText: 'ONAYLA',
					cancelButtonText: 'VAZGEÇ'

				}).then((result) => {
					if (result.value == true) {
						KullaniciOnayla(id);
					}
				}
				)
			}

		);
		$(".btnOnayIptal").click(
			function () {
				var id = $(this).attr("kullaniciid");
				Swal.fire({
					title: 'Kullanıcı Onayı İptal',
					text: "Kullanıcı Onayı İptal Edilecek Emin Misiniz",
					type: 'question',
					showCancelButton: true,
					confirmButtonColor: '#3085d6',
					cancelButtonColor: '#d33',
					confirmButtonText: 'ONAY İPTAL',
					cancelButtonText: 'VAZGEÇ'

				}).then((result) => {
					if (result.value == true) {
						KullaniciOnaylaİptal(id);
					}
				}
				)
			}

		);
		$(".btnKullaniciSil").click(
			function () {
				var id = $(this).attr("kullaniciid");
				Swal.fire({
					title: 'Kullanıcı Silme',
					text: "Kullanıcı Silinecek Emin Misiniz?",
					type: 'warning',
					showCancelButton: true,
					confirmButtonColor: '#3085d6',
					cancelButtonColor: '#d33',
					confirmButtonText: 'ONAYLA',
					cancelButtonText: 'VAZGEÇ'

				}).then(
					function () {
						$.ajax({
							data: { id: id },
							method: "post",
							success: function (response) {

								Swal.fire({
									title: 'Kullanıcı Silme',
									text: response.Mesaj,
									type: 'success',

									confirmButtonColor: '#3085d6',
									cancelButtonColor: '#d33',
									confirmButtonText: 'TAMAM'

								}).then(
									function () {
										window.location.reload();
									}
								)

							},
							error: function () {

								Swal.fire({
									title: 'Kullanıcı Silme',
									text: 'İşlem Başarısız',
									type: 'warning',

									confirmButtonColor: '#3085d6',
									cancelButtonColor: '#d33',
									confirmButtonText: 'TAMAM'

								})

							}

						});

					}
				)
			}
		);

		function KullaniciOnayla(id) {

			$.ajax({

				url: "/Administration/Home/KullaniciOnayla",
				data: { kid: id },
				method: "post",
				success: function (response) {

					Swal.fire({
						title: 'Kullanıcı Onayı',
						text: response.Mesaj,
						type: 'success',

						confirmButtonColor: '#3085d6',
						cancelButtonColor: '#d33',
						confirmButtonText: 'TAMAM'

					}).then(
						function () {
							window.location.reload();
						}
					)

				},
				error: function () {

				}
			});
		}
		function KullaniciOnaylaİptal(id) {
			$.ajax({
				url: "/Administration/Home/KullaniciOnayIptal",
				data: { kid: id },
				method: "post",
				success: function (response) {

					Swal.fire({
						title: 'Kullanıcı Onay İptal',
						text: response.Mesaj,
						type: 'success',

						confirmButtonColor: '#3085d6',
						cancelButtonColor: '#d33',
						confirmButtonText: 'TAMAM'

					}).then(
						function () {
							window.location.reload();
						}
					)

				},
				error: function () {



				}

			});
		}
	})