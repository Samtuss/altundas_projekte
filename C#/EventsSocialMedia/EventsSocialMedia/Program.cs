namespace EventsSocialMedia;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Event Social Media Bsp");

        Post post = new Post();

        post.GotLiked += post.Post_GotLiked;
        post.Viral += post.ViralHandler;
        post.Milestone += post.MilestoneHandler;


        for (int i = 0; i < 12; i++)
        {
            post.Like();
            Console.WriteLine($"Likes: {post.Counter}");
            Thread.Sleep(500);
        }
    }


}
