$(function () {
    // upload Picture content
    $('.chooseUploadPictureBtn').click(function (e) {
        e.preventDefault();
        $('.inputUploadPictureBtn').click();
    });

    $('.sendUploadPictureBtn').click(function () {
        window.entertainmentSystemAjax.create.picture($(".inputUploadPictureBtn")[0].files[0]);
    });

    // upload Music content
    $('.chooseUploadMusicBtn').click(function (e) {
        e.preventDefault();
        $('.inputUploadMusicBtn').click();
    });

    $('.sendUploadMusicBtn').click(function () {
        window.entertainmentSystemAjax.create.music($(".inputUploadMusicBtn")[0].files[0]);
    });

    // upload Video content
    $('.chooseUploadVideoBtn').click(function (e) {
        e.preventDefault();
        $('.inputUploadVideoBtn').click();
    });

    $('.sendUploadVideoBtn').click(function () {
        window.entertainmentSystemAjax.create.video($(".inputUploadVideoBtn")[0].files[0]);
    });

    // test
});