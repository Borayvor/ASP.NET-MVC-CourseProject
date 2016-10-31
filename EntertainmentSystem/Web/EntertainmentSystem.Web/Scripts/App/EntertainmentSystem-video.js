$(function () {
    function pause() {
        $(".es-video-paused-overlay").addClass("es-paused");
        $(".es-giant-resume-icon").addClass("es-video-active");
        $("#es-video-element").get(0).pause();
    }

    // start play video
    $(".es-media-details-play-container").click(function () {
        $(".es-media-details-video-show").addClass("noscroll");
        $("#es-video-container").addClass("es-video-active");
        $(".es-video-paused-overlay").removeClass("es-paused");
        $(".es-giant-resume-icon").removeClass("es-video-active");        
        $("#es-video-element").get(0).play();
    });

    // play video
    $(".es-giant-resume-icon").click(function () {
        $(this).removeClass("es-video-active");
        $(".es-video-paused-overlay").removeClass("es-paused");
        $("#es-video-element").get(0).play();
    });

    // pause video
    $("#es-video-element").click(function () {
        pause();
    });

    // pause and exit video
    $(".es-close-icon").click(function () {
        pause();
        $("#es-video-container").removeClass("es-video-active");
        $(".es-media-details-video-show").removeClass("noscroll");
    });

    // show controls
    function toggleControls() {
        $(".es-player-controls.es-top-bar").addClass("es-controls-top-active");
        $(".es-player-controls.es-bottom-bar").addClass("es-controls-bottom-active");
        
        setTimeout(function () {
            $(".es-player-controls.es-top-bar").removeClass("es-controls-top-active");
            $(".es-player-controls.es-bottom-bar").removeClass("es-controls-bottom-active");
        }, 500000);
    }

    $("#es-video-element").mouseover(function () {
        toggleControls();
    });

    $(".es-giant-resume-icon").mouseover(function () {
        toggleControls();
    });

    // play icons hover
    $(".play").hover(function () {
        $(this).toggleClass("fa-5x");
    });

    $(".es-giant-resume-icon em").hover(function () {
        $(this).toggleClass("fa-2x");
    });
});