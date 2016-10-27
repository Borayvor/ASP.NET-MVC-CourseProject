
$(function () {
    // upload Music content
    $('.chooseUploadMusicBtn').click(function (e) {
        e.preventDefault();
        $(this).parent().children('.inputUploadMusicBtn').click();
    });

    $('.sendUploadMusicBtn').click(function (e) {
        $(this).parent().children('.es-upload-btn').click();
    });

    // upload Picture content
    $('.chooseUploadPictureBtn').click(function (e) {
        e.preventDefault();
        $(this).parent().children('.inputUploadPictureBtn').click();
    });

    $('.sendUploadPictureBtn').click(function (e) {        
        $(this).parent().children('.es-upload-btn').click();
    });

    // upload Video content
    $('.chooseUploadVideoBtn').click(function (e) {
        e.preventDefault();
        $(this).parent().children('.inputUploadVideoBtn').click();
    });

    $('.sendUploadVideoBtn').click(function (e) {
        $(this).parent().children('.es-upload-btn').click();
    });

    // test   
});