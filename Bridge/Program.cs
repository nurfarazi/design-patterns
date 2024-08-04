namespace Bridge;

class Program
{
    static void Main(string[] args)
    {
        IVideoProcessor hdProcessor = new HDProcessor();
        IVideoProcessor fhdProcessor = new FHDProcessor();

        VideoService youtube = new YouTube(hdProcessor);
        VideoService netflix = new Netflix(fhdProcessor);

        youtube.Play("Funny Cats Compilation");
        netflix.Play("Stranger Things Episode 1");
    }
}

public interface IVideoProcessor
{
    void ProcessVideo(string video);
}

public class HDProcessor : IVideoProcessor
{
    public void ProcessVideo(string video)
    {
        Console.WriteLine("Processing video in HD quality: " + video);
    }
}

public class FHDProcessor : IVideoProcessor
{
    public void ProcessVideo(string video)
    {
        Console.WriteLine("Processing video in FHD quality: " + video);
    }
}

public class UHDProcessor : IVideoProcessor
{
    public void ProcessVideo(string video)
    {
        Console.WriteLine("Processing video in UHD quality: " + video);
    }
}

public abstract class VideoService
{
    protected IVideoProcessor videoProcessor;

    protected VideoService(IVideoProcessor processor)
    {
        videoProcessor = processor;
    }

    public abstract void Play(string video);
}

public class YouTube : VideoService
{
    public YouTube(IVideoProcessor processor) : base(processor)
    {
    }

    public override void Play(string video)
    {
        Console.WriteLine("YouTube: ");
        videoProcessor.ProcessVideo(video);
    }
}

public class Vimeo : VideoService
{
    public Vimeo(IVideoProcessor processor) : base(processor)
    {
    }

    public override void Play(string video)
    {
        Console.WriteLine("Vimeo: ");
        videoProcessor.ProcessVideo(video);
    }
}

public class Netflix : VideoService
{
    public Netflix(IVideoProcessor processor) : base(processor)
    {
    }

    public override void Play(string video)
    {
        Console.WriteLine("Netflix: ");
        videoProcessor.ProcessVideo(video);
    }
}

public class Prime : VideoService
{
    public Prime(IVideoProcessor processor) : base(processor)
    {
    }

    public override void Play(string video)
    {
        Console.WriteLine("Prime: ");
        videoProcessor.ProcessVideo(video);
    }
}