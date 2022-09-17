
using System.Runtime.CompilerServices;

namespace TicTacToe
{
    class Drawing
    {
        static char CheckWin (char win, char[,] placement)
        {
            for (int i = 0; i < 3; i++)
            {
                if (placement[i, 0] == placement[i, 1] && placement[i, 0] == placement[i, 2])
                {
                    win = placement[i, 0];
                    break;
                }

                if (placement[0, i] == placement[1, i] && placement[0, i] == placement[2, i])
                {
                    win = placement[0, i];
                    break;
                }
            }

            if (placement[0, 0] == placement[1, 1] && placement[0, 0] == placement[2, 2])
            {
                win = placement[0, 0];
            }

            if (placement[0, 2] == placement[1, 1] && placement[0, 2] == placement[2, 0])
            {
                win = placement[0, 2];
            }

            return win;
        }
        static void Main(string[] args)
        {
            char[,] placement = new char[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            char win = '0';

            byte[] placementCheck = new byte[9]; 
            byte x, y, num;
            byte count = 0;
           
            do
            {
                Console.Clear();
                Console.WriteLine("   |   |   ");
                Console.WriteLine(" {0} | {1} | {2} ", placement[0, 0], placement[0, 1], placement[0, 2]);
                Console.WriteLine("___|___|___");
                Console.WriteLine("   |   |   ");
                Console.WriteLine(" {0} | {1} | {2} ", placement[1, 0], placement[1, 1], placement[1, 2]);
                Console.WriteLine("___|___|___");
                Console.WriteLine("   |   |   ");
                Console.WriteLine(" {0} | {1} | {2} ", placement[2, 0], placement[2, 1], placement[2, 2]);
                Console.WriteLine("   |   |   ");

                Console.WriteLine("\nWhat number do you want to \"Tic\"?");

                do
                {
                    byte.TryParse(Console.ReadLine(), out num);

                    if (num >= 1 && num <= 9)
                        if (placementCheck[num-1] == 0)
                            break;

                    Console.WriteLine("You must write a number between 1 and 10... or you just chose a wrong spot :]");

                } while (true);

                x = (byte)((num - 1) / 3);
                y = (byte)((num - 1) % 3);

                if (count % 2 == 0)
                {
                    placement[x, y] = 'X';
                    placementCheck[num - 1] = 1;
                }
                else
                {
                    placement[x, y] = 'O';
                    placementCheck[num - 1] = 2;
                }

                count++;

                if (count > 4)
                {
                    win = CheckWin(win, placement);
                }

            } while (win == '0' && count < 9);

            Console.Clear();
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", placement[0, 0], placement[0, 1], placement[0, 2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", placement[1, 0], placement[1, 1], placement[1, 2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", placement[2, 0], placement[2, 1], placement[2, 2]);
            Console.WriteLine("   |   |   ");

            if (win == '0')
            {
                Console.WriteLine("\nToo fucking bad. Nobody won. Get the fuck outa here you miserable pieces of shite!!!");
            }
            else
            {
                Console.WriteLine("\nWell hoopdy-doo, you just fucking won '{0}', and I finished my first game. Rejoice brethren!", win);
            }

            Console.ReadKey();
        }
    }
}