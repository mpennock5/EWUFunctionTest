public class JokeService 
{
    public Joke GetJoke() 
    {
        
        return new Joke 
        {
            Type = "programming",
            Setup = "What's the best thing about a Boolean?",
            Punchline = "Even if you're wrong, you're only off by a bit."
        };
    }
}