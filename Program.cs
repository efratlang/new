using System;

namespace Ladders_and_ropes
{
    class Program
    {
        static void Main(string[] args)
        {
            player p = new player("efrat");
            player p1 = new player("zeevi");
            player[] parr = { p, p1 };
            Point[] ladderr = { new Point(3, 14),new Point(11,82),new Point(24,66) ,new Point(35,76)  };
            Point[] snak = { new Point(8,18), new Point(4,19), new Point(32,47), new Point(49,65) };
            play play = new play(parr,12,53);
            play.fullBoard();
            play.fullladder(ladderr);
            play.fullsnakes(snak);
            play.playnow();
            
            
        }
    }
}
