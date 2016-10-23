namespace EntertainmentSystem.Web.Controllers.Tests
{
    using System.Collections.Generic;
    using Data.Models.Media;
    using NUnit.Framework;
    using ViewModels.Media;

    [TestFixture]
    public class HomeControllerTests
    {
        private List<MediaContentHomeViewModel> pictures = new List<MediaContentHomeViewModel>
        {
            new MediaContentHomeViewModel
            {
                Title = "pic1",
                ContentUrl = "http://i2.wp.com/www.cgmeetup.net/home/wp-content/uploads/2015/11/World-of-Warcraft-Legion-Cinematic-Trailer-3.jpg?resize=960%2C398",
                ContentType = ContentType.Picture
            },
            new MediaContentHomeViewModel
            {
                Title = "pic2",
                ContentUrl = "http://blogs-images.forbes.com/scottmendelson/files/2016/05/Warcraft-Movie-Mobile-Wallpapers-1200x675.jpg",
                ContentType = ContentType.Picture
            },
            new MediaContentHomeViewModel
            {
                Title = "pic3",
                ContentUrl = "http://www.hdwallpapers.in/download/garona_warcraft_movie-720x1280.jpg",
                ContentType = ContentType.Picture
            }
        };

        private List<MediaContentHomeViewModel> musics = new List<MediaContentHomeViewModel>
        {
            new MediaContentHomeViewModel
            {
                Title = "music1",
                ContentUrl = "http://downloads.khinsider.com/game-soundtracks/album/warcraft-orcs-and-humans/02-intro.mp3",
                ContentType = ContentType.Music
            },
            new MediaContentHomeViewModel
            {
                Title = "music2",
                ContentUrl = "http://downloads.khinsider.com/game-soundtracks/album/warcraft-orcs-and-humans/17-retrobution.mp3",
                ContentType = ContentType.Music
            },
            new MediaContentHomeViewModel
            {
                Title = "music3",
                ContentUrl = "http://downloads.khinsider.com/game-soundtracks/album/warcraft-orcs-and-humans/22-of-battle-and-ancient-warcraft.mp3",
                ContentType = ContentType.Music
            }
        };

        private List<MediaContentHomeViewModel> videos = new List<MediaContentHomeViewModel>
        {
            new MediaContentHomeViewModel
            {
                Title = "video1",
                ContentUrl = "http://video.webmfiles.org/big-buck-bunny_trailer.webm",
                ContentType = ContentType.Video
            },
            new MediaContentHomeViewModel
            {
                Title = "video2",
                ContentUrl = "http://easyhtml5video.com/images/happyfit2.webm",
                ContentType = ContentType.Video
            },
            new MediaContentHomeViewModel
            {
                Title = "video3",
                ContentUrl = "http://techslides.com/demos/sample-videos/small.webm",
                ContentType = ContentType.Video
            }
        };

        [Test]
        public void HomeIndexPicturesShouldWorkCorrectly()
        {
        }
    }
}
