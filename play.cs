using System;
using System.Collections.Generic;
using System.Text;

namespace Ladders_and_ropes
{
    //מחלקת משחק 
    class play
    {
        private int[,]  board;// מטריצה לוח המשחק
        private int kobiya1;//קוביה 1
        private int kobiya2;//קוביה 2
        private player[] players;// 2 השחקנים
        private Point[] snakes;//מערך נחשים
        private Point[] ladder;//מערך סולמות
        private int gold1;
        private int gold2;
        public play(player[]players,int gold1,int gold2)
        {
            this.players = players;
            this.gold1 = gold1;
            this.gold2 = gold2;
            snakes = new Point[4];
            ladder = new Point[4];
            board = new int[10, 10];
        }
        //מילוי הלוח בפעם הראשונה 
        public void fullBoard()
        {
            int mone = 100;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = mone--;
                }
            }
        }
        //השמת הנחשים
        public void fullsnakes(Point[]p)
        {
            Console.WriteLine("snakes:");
            for (int i = 0; i < p.Length;  )
            {
                
                for (int j = 0; j < snakes.Length; j++)
                {
                    snakes[j] = p[i++];
                    Console.WriteLine(snakes[j].Gety() + "=>" + snakes[j].Getx());
                }
            }
        }
        //השמת הסולמות
        public void fullladder(Point[] p)
        {
            Console.WriteLine("ladders:");
            for (int i = 0; i < p.Length;)
            {
                for (int j = 0; j < ladder.Length; j++)
                {
                   ladder[j] = p[i++];
                    Console.WriteLine(ladder[j].Getx() + "=>" + ladder[j].Gety());
                }
            }
        }
        public void playnow()
        {
            int []count =   { 0, 0 };
            Random r = new Random();
            int a = 0;
            while(count[0]<100&&count[1]<100)
            {
                Console.WriteLine("round" + " " + ++a);
                for (int i = 0; i < 2; i++)
                {
                   int  sum = 0;
                    //רנדום של קוביות בכל סיבוב
                    kobiya1 = r.Next(1,6);
                    kobiya2 = r.Next(1,6);
                    sum = kobiya1 + kobiya2;
                    count[i] += sum;
                    if (count[i] >= 100)
                    {
                        Console.WriteLine(players[i].Getname() + " " + "rolled" + " " + sum);
                        Console.WriteLine("winner" + " " + players[i].Getname());
                        break;
                    }
                    Console.WriteLine(players[i].Getname() +" "  +"rolled" + " " + sum);
                    Console.WriteLine(players[i].Getname() + " "+"is on " + " " + count[i]);
                    for (int j = 0; j < snakes.Length; j++)
                    {
                        if(count[i]==snakes[j].Gety())
                        {
                            count[i] = snakes[j].Getx();
                            Console.Write(players[i].Getname() + " "+ "  has landed on a snake"    );
                            Console.WriteLine(  "and so he is on  " +  count[i]);
                        }
                        else
                            if(count[i] == ladder[j].Getx())
                        {
                            count[i] = ladder[j].Gety();
                            Console.Write(players[i].Getname() + " "+ "has landed on a ladder " );
                            Console.WriteLine("and so he is on  " + count[i]);
                        }
                    }
                    if (count[i] == gold1 || count[i] == gold2)
                    {
                        Console.WriteLine(players[i].Getname() + " " + "drop in gold");
                        if (count[0] < count[1])
                        {
                            int temp = count[0];
                            for (int j = 0; j < count.Length; j++)
                            {
                                if (i == j)
                                { 
                                    count[j] =count[1];

                                }
                                else
                                {
                                    count[j] = temp;
                                }
                            }
                        }
                        else
                        {
                            int temp1 = count[1];
                            for (int j = 0; j < count.Length; j++)
                            {
                                if (i == j)
                                {
                                    count[j] =count[0]; 

                                }
                                else
                                {
                                    count[j] = temp1;
                                }
                            }
                         }
                             
                    }
                }
            }
             
        }

    }
}
