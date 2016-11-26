$(function () {
    var mediaPlayElement = $("#es-media-play-element");
    var mediaPlayer = mediaPlayElement.get(0);
    var isPlay = false;

    function isAudioVideoPlayer() {
        var result = mediaPlayer !== undefined && mediaPlayer !== null &&
            mediaPlayer.volume !== undefined && mediaPlayer.volume !== null;

        return result;
    }

    if (isAudioVideoPlayer()) {
        mediaPlayer.volume = 0.5;
    }

    function formatTime(seconds) {
        minutes = Math.floor(seconds / 60);
        minutes = minutes >= 10 ? minutes : "0" + minutes;
        seconds = Math.floor(seconds % 60);
        seconds = seconds >= 10 ? seconds : "0" + seconds;
        return minutes + ":" + seconds;
    }

    function pause() {
        if (isAudioVideoPlayer()) {
            $(".es-item-paused-overlay").addClass("es-paused");
            $(".es-giant-resume-icon").addClass("es-item-active");
            $(".es-play-pause-icon").children(".fa").toggleClass("fa-pause");
            $(".es-play-pause-icon").children(".fa").toggleClass("fa-play");
            isPlay = false;
            mediaPlayer.pause();
        }
    }

    function play() {
        if (isAudioVideoPlayer()) {
            $(".es-giant-resume-icon").removeClass("es-item-active");
            $(".es-item-paused-overlay").removeClass("es-paused");
            $(".es-play-pause-icon").children(".fa").toggleClass("fa-play");
            $(".es-play-pause-icon").children(".fa").toggleClass("fa-pause");
            isPlay = true;
            mediaPlayer.play();
        }
    }

    function changeVolume(direction) {
        if (isAudioVideoPlayer()) {
            var percentage;
            var progressBar = $(".es-volume-bar");
            if (direction === '+') {
                mediaPlayer.volume += mediaPlayer.volume === 1 ? 0 : 0.1;
            }
            else if (direction === '-') {
                mediaPlayer.volume -= mediaPlayer.volume === 0 ? 0 : 0.1;
            }

            mediaPlayer.volume = parseFloat(mediaPlayer.volume).toFixed(1);
            percentage = Math.floor(100 * mediaPlayer.volume);
            progressBar.attr("aria-valuenow", percentage);
            progressBar.css("width", percentage + "%");
        }
    }

    function updateProgressBar() {
        if (isAudioVideoPlayer()) {
            var progressBar = $('.es-progress-bar');
            var percentage = Math.floor(100 / mediaPlayer.duration * mediaPlayer.currentTime);
            var remainingTimeConverted = formatTime(mediaPlayer.duration - mediaPlayer.currentTime);

            progressBar.attr("aria-valuenow", percentage);
            progressBar.css("width", percentage + "%");
            $(".time-remaining").text(remainingTimeConverted);

            if (percentage === 100) {
                pause();
            }
        }
    }

    function seekVolumeBar(e) {
        var volumeBar = $('.es-volume-bar');
        var percent = e.offsetX / this.offsetWidth;
        var transformedPersent = percent * 100;

        mediaPlayer.volume = percent;
        volumeBar.attr("aria-valuenow", transformedPersent);
        volumeBar.css("width", transformedPersent + "%");
    }

    function seekProgressBar(e) {
        var percent = e.offsetX / this.offsetWidth;
        mediaPlayer.currentTime = percent * mediaPlayer.duration;
    }

    // start play
    $(".es-media-details-play-container").click(function () {
        $(".es-media-details-show").addClass("noscroll");
        $(".es-item-player").addClass("es-item-active");

        play();
    });  

    // play video
    $(".es-giant-resume-icon").click(function () {
        play();
    });

    $(".es-play-pause-icon").click(function () {
        if (isPlay) {
            pause();
        } else {
            play();
        }
    });

    // pause video
    $(".es-item-content").click(function () {
        pause();
    });

    // pause and exit video
    $(".es-close-icon").click(function () {
        pause();

        $(".es-item-player").removeClass("es-item-active");
        $(".es-media-details-show").removeClass("noscroll");
    });

    // show controls
    function toggleControls() {
        var controlsTop = $(".es-player-controls.es-top-bar");
        var controlsBottom = $(".es-player-controls.es-bottom-bar");
        var timeout = 7000;

        if (controlsTop.hasClass("es-controls-top-active") ||
            controlsBottom.hasClass("es-controls-bottom-active")) {
            return;
        }

        controlsTop.addClass("es-controls-top-active");
        controlsBottom.addClass("es-controls-bottom-active");                

        setTimeout(function () {
            controlsTop.removeClass("es-controls-top-active");
            controlsBottom.removeClass("es-controls-bottom-active");
        }, timeout);
    }      

    $(".es-item-player").mousemove(function () {
        toggleControls();
    });
    
    // play icons hover
    $(".play").hover(function () {
        $(this).toggleClass("fa-5x");
    });

    $(".es-giant-resume-icon em").hover(function () {
        $(this).toggleClass("fa-2x");
    });

    // back to details hover
    $(".es-media-details-back em").hover(function () {
        $(this).toggleClass("fa-3x");
    });

    // progress bar
    if (isAudioVideoPlayer()) {
        mediaPlayer.addEventListener('timeupdate', updateProgressBar, false);

        $(".es-volume-bar-container").click(seekVolumeBar);
        $(".es-progress-bar-container").click(seekProgressBar);
    }

    // volume bar
    $(".es-volume-down").click(function () {
        changeVolume("-");
    });

    $(".es-volume-up").click(function () {
        changeVolume("+");
    });
});