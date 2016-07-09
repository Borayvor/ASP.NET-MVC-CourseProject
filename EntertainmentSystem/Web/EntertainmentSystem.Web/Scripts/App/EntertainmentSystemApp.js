$(function(){
    // upload content
    $('.chooseUploadPictureBtn').click(function (e) {
        e.preventDefault();
        $('.inputUploadPictureBtn').click();
    });

    $('.sendUploadPictureBtn').click(function () {
        window.entertainmentSystemAjax.create.picture($(".inputUploadPictureBtn")[0].files[0]);
    });
})