using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using LibVLCSharp.Shared;


// No la pude utilizar por falta de timepo pero me las ingenie para sehuir con el plan 
namespace EmDijes1.Services
{
    public class YouTubeService : IDisposable
    {
        private readonly LibVLC _libVLC;
        private readonly MediaPlayer _mediaPlayer;

        public MediaPlayer MediaPlayer => _mediaPlayer;

        public YouTubeService()
        {
            Core.Initialize();
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
        }

        public async Task PlayVideoFromUrlAsync(string youtubeUrl)
        {
            var youtube = new YoutubeClient();
            var videoId = VideoId.TryParse(youtubeUrl);
            if (videoId == null)
                throw new ArgumentException("La URL proporcionada no es un enlace válido de YouTube.", nameof(youtubeUrl));

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId.Value);
            var streamInfo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();

            if (streamInfo == null)
                throw new InvalidOperationException("No se encontró ningún stream muxed compatible para reproducir.");

            var streamUrl = streamInfo.Url;
            _mediaPlayer.Play(new Media(_libVLC, new Uri(streamUrl)));
        }

        public void Dispose()
        {
            _mediaPlayer?.Dispose();
            _libVLC?.Dispose();
        }
    }
}