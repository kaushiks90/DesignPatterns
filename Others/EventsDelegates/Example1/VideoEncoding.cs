using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventsDelegates.Example1
{
   
    internal class VideoEncoding
    {
        private static void MainMethod()
        {
            MessageSubscriber m = new MessageSubscriber();
            EmailSubscriber E = new EmailSubscriber();
            Publisher p = new Publisher();
            p.videoEncoded += m.onVideoEncoded;

            Video video = new Video() { Title = "Video 1" };
            p.Encode(video);
            p.videoEncoded += E.onVideoEncoded;
            video = new Video { Title = "Video 2" };
            p.Encode(video);
            Console.ReadLine();
        }
    }

    public class VideoEventArgs : EventArgs
    {
        public Video video { get; set; }
    }
    public class Video
    {
        public string Title { get; set; }
    }

    public class Publisher
    {
        public EventHandler<VideoEventArgs> videoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video");
            Thread.Sleep(3000);
            onVideoEncoded(video);
        }
        public void onVideoEncoded(Video video)
        {
            if (videoEncoded != null)
            {
                videoEncoded(this, new VideoEventArgs() { video = video });
            }
        }
    }
    public class MessageSubscriber
    {
        public void onVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Message Service ,A new video has been encoded {0}", e.video.Title);
        }
    }
    public class EmailSubscriber
    {
        public void onVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Email Service, A new Video has been encoded {0}", e.video.Title);
        }
    }

}
