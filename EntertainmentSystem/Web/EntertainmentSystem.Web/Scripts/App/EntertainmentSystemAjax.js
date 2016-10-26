window.entertainmentSystemAjax = (function () {
    function send(url, fileSrc, title, cb, error) {
        var form = new FormData($("#hiddenAjaxPostForm"));

        var verificationToken = $('#hiddenAjaxPostForm input').val();
        form.append('__RequestVerificationToken', verificationToken);

        if (fileSrc) {
            form.append("File", fileSrc);
        }

        if (title) {           
            form.append("Title", title);
        }

        $.ajax({
            type: 'POST',
            url: url,
            data: form,
            processData: false,
            contentType: false
        }).done(cb).error(error);
    }

    function create(url, fileSrc, title) {
        send(url, fileSrc, title, function (response) {

            toastr.success("Successfully created !");

        }, function (error) {
            toastr.error("Invalid data");
        });
    }

    return {
        create: {
            video: function (fileSrc) {
                create("/UploadVideo/Create", fileSrc);
            },
            music: function (fileSrc) {
                create("/UploadMusic/Create", fileSrc);
            },
            picture: function (fileSrc, title) {
                create("/UploadPicture/Create", fileSrc, title);
            }
        }
    };
}());