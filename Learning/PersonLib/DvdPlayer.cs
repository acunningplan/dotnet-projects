using static System.Console;

namespace Shared
{
    public class DvdPlayer : IPlayable
    {
        public void Pause()
        {
            WriteLine("DVD player has paused.");
        }
        public void Play()
        {
            WriteLine("DVD player is playing");
        }
    }
}
