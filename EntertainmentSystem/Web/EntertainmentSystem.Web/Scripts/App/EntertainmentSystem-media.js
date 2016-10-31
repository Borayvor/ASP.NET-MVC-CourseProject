$(function () {
    var mediaPlayElement = $("#es-media-play-element");
    var mediaPlayer = mediaPlayElement.get(0);
    var isPlay = false;

    function isReadyMediaPlayer() {
        return (mediaPlayer !== undefined && mediaPlayer !== null);
    }

    if (isReadyMediaPlayer()) {
        mediaPlayer.volume = 0.5;
    }

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
        isPlay = false;
        mediaPlayer.pause();
    }

    function play() {
        $(".es-giant-resume-icon").removeClass("es-video-active");
        $(".es-video-paused-overlay").removeClass("es-paused");
        $(".es-play-pause-icon").children(".fa").toggleClass("fa-play");
        $(".es-play-pause-icon").children(".fa").toggleClass("fa-pause");
        isPlay = true;
        mediaPlayer.play();
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

    // start play
    $(".es-media-details-play-container").click(function () {
        $(".es-media-details-show").addClass("noscroll");
        $(".es-item-player").addClass("es-video-active");

        if (isReadyMediaPlayer()) {
            play();
        }
    });

    // play video
    $(".es-giant-resume-icon").click(function () {
        if (isReadyMediaPlayer()) {
            play();
        }
    });

    $(".es-play-pause-icon").click(function () {
        if (isPlay) {
            pause();
        } else {
            play();
        }
    });

    // pause video
    if (isReadyMediaPlayer()) {
        mediaPlayElement.click(function () {
            pause();
        });
    }

    // pause and exit video
    $(".es-close-icon").click(function () {
        if (isReadyMediaPlayer()) {
            pause();
        }

        $(".es-item-player").removeClass("es-video-active");
        $(".es-media-details-show").removeClass("noscroll");
    });

    // show controls
    function toggleControls() {
        var controlsTop = $(".es-player-controls.es-top-bar");
        var controlsBottom = $(".es-player-controls.es-bottom-bar");

        if (controlsTop.hasClass("es-controls-top-active") ||
            controlsBottom.hasClass("es-controls-bottom-active")) {
            return;
        }

        controlsTop.addClass("es-controls-top-active");
        controlsBottom.addClass("es-controls-bottom-active");

        setTimeout(function () {
            $(".es-player-controls.es-top-bar").removeClass("es-controls-top-active");
            $(".es-player-controls.es-bottom-bar").removeClass("es-controls-bottom-active");
        }, 5000);
    }

    if (isReadyMediaPlayer()) {
        mediaPlayElement.mousemove(function () {
            toggleControls();
        });
    }

    $(".es-giant-resume-icon").mousemove(function () {
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
    if (isReadyMediaPlayer()) {
        mediaPlayer.addEventListener('timeupdate', updateProgressBar, false);
    }

    // volume bar
    if (isReadyMediaPlayer()) {
        $(".es-volume-down").click(function () {
            changeVolume("-");
        });

        $(".es-volume-up").click(function () {
            changeVolume("+");
        });
    }
});