$(function(){
    // upload content
    $('.choosePictureBtn').click(function (e) {
        e.preventDefault();
        $('.inputUploadPictureBtn').click();
    });

    $('.sendUploadPictureBtn').click(function () {
        window.EntertainmentSystemAjax.content.withPicture($(".inputUploadPictureBtn")[0].files[0], window.mediaContentClickedId);
    });
})