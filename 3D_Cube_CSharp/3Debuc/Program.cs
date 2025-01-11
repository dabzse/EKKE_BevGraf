using OpenTK;

namespace OpenTk_kocka
{
    class Program
    {
        public static void Main(string[] args)
        {
            GameWindow window = new GameWindow(500, 500);
            Game gm = new Game(window);
        }
    }
}
