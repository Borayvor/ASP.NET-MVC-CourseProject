$(function () {
    // upload Music content
    $('.chooseUploadMusicBtn').click(function (e) {
        e.preventDefault();
        $('.inputUploadMusicBtn').click();
    });

    $('.sendUploadMusicBtn').click(function (e) {        
        $(this).parent().children(".es-upload-btn").click();
    });

    // upload Picture content
    $('.chooseUploadPictureBtn').click(function (e) {
        e.preventDefault();
        $('.inputUploadPictureBtn').click();
    });

    $('.sendUploadPictureBtn').click(function (e) {        
        $(this).parent().children(".es-upload-btn").click();
    });        

    // upload Video content
    $('.chooseUploadVideoBtn').click(function (e) {
        e.preventDefault();
        $('.inputUploadVideoBtn').click();
    });

    $('.sendUploadVideoBtn').click(function (e) {       
        $(this).parent().children(".es-upload-btn").click();
    });

    // test   
});