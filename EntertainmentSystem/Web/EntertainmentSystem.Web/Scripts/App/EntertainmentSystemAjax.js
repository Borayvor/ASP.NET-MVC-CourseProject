window.entertainmentSystemAjax = (function () {
    function send(url, fileSrc, id, cb, error) {
        var form = new FormData($("#hiddenAjaxPostForm"));

        var verificationToken = $('#hiddenAjaxPostForm input').val();
        form.append('__RequestVerificationToken', verificationToken);

        if (fileSrc) {
            form.append("File", fileSrc);
        }

        if (id) {
            form.append("Id", id);
        }
        
        $.ajax({
            type: 'POST',
            url: url,
            data: form,
            processData: false,
            contentType: false
        }).done(cb).error(error);
    }

    function create(url, fileSrc) {
        send(url, fileSrc, null, function (response) {

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
            picture: function (fileSrc) {
                create("/UploadPicture/Create", fileSrc);
            }
        }
    }
}())