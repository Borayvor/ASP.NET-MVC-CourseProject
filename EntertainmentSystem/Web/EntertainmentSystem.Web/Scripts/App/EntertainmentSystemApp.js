$(function () {
    // upload Picture content
    $('.chooseUploadPictureBtn').click(function (e) {
        e.preventDefault();
        $('.inputUploadPictureBtn').click();
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