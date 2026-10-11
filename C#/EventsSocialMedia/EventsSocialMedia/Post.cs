using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSocialMedia;

public class Post
{
    private int _counter;
    public string Text  { get; set; }
    public int Counter { 
        get => _counter; 
        set
        {
            _counter = value;
            if (_counter % 5 == 0)
                Milestone?.Invoke(this, EventArgs.Empty);
        }
    }
    public event EventHandler<EventArgs> GotLiked;
    public event EventHandler<EventArgs> Viral;
    public event EventHandler<EventArgs> Milestone;


    public void Like()
    {
        Counter++;
        GotLiked?.Invoke(this, EventArgs.Empty);
        if (Counter > 10)
        {
            Viral?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Post_GotLiked(object sender, EventArgs e)
    {
        Console.WriteLine("Like erhalten.");
    }
    public void ViralHandler(object sender, EventArgs e)
    {
        Console.WriteLine("Der Post ist viral gegangen!");
    }
    public void MilestoneHandler(object sender, EventArgs e)
    {
        Console.WriteLine("Meilenstein erreicht!");
    }
}
