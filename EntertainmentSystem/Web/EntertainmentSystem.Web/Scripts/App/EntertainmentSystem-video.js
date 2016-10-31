$(function () {
    var mediaPlayer = $("#es-video-element").get(0);
    mediaPlayer.volume = 0.5;

    function formatTime(seconds) {
        minutes = Math.floor(seconds / 60);
        minutes = (minutes >= 10) ? minutes : "0" + minutes;
        seconds = Math.floor(seconds % 60);
        seconds = (seconds >= 10) ? seconds : "0" + seconds;
        return minutes + ":" + seconds;
    }

    function pause() {
        $(".es-video-paused-overlay").addClass("es-paused");
        $(".es-giant-resume-icon").addClass("es-video-active");
        $(".es-play-pause-icon").children(".fa").toggleClass("fa-pause");
        $(".es-play-pause-icon").children(".fa").toggleClass("fa-play");
        $("#es-video-element").get(0).pause();
    }

    function play() {
        $(".es-video-paused-overlay").removeClass("es-paused");
        $(".es-play-pause-icon").children(".fa").toggleClass("fa-play");
        $(".es-play-pause-icon").children(".fa").toggleClass("fa-pause");
        $("#es-video-element").get(0).play();
    }

    function changeVolume(direction) {
        var percentage;
        var progressBar = $(".es-volume-bar");

        if (direction === '+') {
            mediaPlayer.volume += mediaPlayer.volume === 1 ? 0 : 0.1;
        }
        else if (direction === '-') {
            mediaPlayer.volume -= (mediaPlayer.volume === 0 ? 0 : 0.1);
        }
           
        mediaPlayer.volume = parseFloat(mediaPlayer.volume).toFixed(1);        
        percentage = Math.floor(100 * mediaPlayer.volume);
        progressBar.attr("aria-valuenow", percentage);
        progressBar.css("width", percentage + "%");
    }

    function updateProgressBar() {        
        var progressBar = $('.es-progress-bar');
        var percentage = Math.floor((100 / mediaPlayer.duration) * mediaPlayer.currentTime);        
        var remainingTimeConverted = formatTime(mediaPlayer.duration - mediaPlayer.currentTime);
        progressBar.attr("aria-valuenow", percentage);
        progressBar.css("width", percentage + "%");        
        $(".time-remaining").text(remainingTimeConverted);

        if (percentage === 100) {
            pause();
        }
    }

    // start play video
    $(".es-media-details-play-container").click(function () {
        $(".es-media-details-video-show").addClass("noscroll");
        $("#es-video-container").addClass("es-video-active");
        $(".es-giant-resume-icon").removeClass("es-video-active");
        play();
    });

    // play video
    $(".es-giant-resume-icon").click(function () {
        $(this).removeClass("es-video-active");
        play();
    });

    $(".es-play-pause-icon").click(function () {        
        if ($(this).children(".fa").hasClass("fa-pause")) {
            play();
        } else {
            pause();
        }
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
        }, 5000);
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

    // progress bar
    $("#es-video-element").get(0).addEventListener('timeupdate', updateProgressBar, false);

    // volume bar
    $(".es-volume-down").click(function () {
        changeVolume("-");
    });

    $(".es-volume-up").click(function () {
        changeVolume("+");
    });
});