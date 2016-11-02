
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

    // carousel auto play-pause
    $("#es-home-carousel-videos").on('slid.bs.carousel', function () {
        var itemActive = $(this).children(".carousel-inner").children(".item.active")
        var itemNotActive = $(this).children(".carousel-inner").children(".item").not(".active");

        ////itemActive.children(".video").get(0).play();

        itemNotActive.children(".video").each(function (key, value) {
            value.pause();
        });
    });

    // test  

    ////$("#es-music-upload").submit(function () {
    ////    $('#modalMisicWindowMain').modal('hide');

    ////    $('#es-loading').show();
    ////});

    ////function musicUploadSubmit () {
    ////    $('#modalMisicWindowMain').modal('hide');

    ////    $('#es-loading').show();
    ////}
});
