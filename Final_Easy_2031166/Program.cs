using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Easy_2031166.Classes;

namespace Final_Easy_2031166
{
    class Program
    {
        static void Main(string[] args)
        {
                ConsoleKeyInfo input;
                Message.PrintInfo(GameManager.currentPlayer.ToString() + "\n");
                Console.WriteLine(@"Welcome to                         ,'\
     _.----.        ____         ,'  _\   ___    ___     ____
 _,-'       `.     |    |  /`.   \,-'    |   \  /   |   |    \  |`.
 \      __    \    '-.  | /   `.  ___    |    \/    |   '-.   \ |  |
  \.    \ \   |  __  |  |/    ,','_  `.  |          | __  |    \|  |
    \    \/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |
     \     ,-'/  /   \    ,'   | \/ / ,`.|         /  /   \  |     |
      \    \ |   \_/  |   `-.  \    `'  /|  |    ||   \_/  | |\    |
       \    \ \      /       `-.`.___,-' |  |\  /| \      /  | |   |
        \    \ `.__,'|  |`-._    `|      |__| \/ |  `.__,'|  | |   |
         \_.-'       |__|    `-._ |              '-.|     '-.| |   |
                                 `'                            '-._|
                    C# Console Edition                              ");


                do
                {
                    Console.WriteLine("\n");
                    Message.PrintMainMenu("Menu : L = Look Around | A = Attack | S = Statistics |");
                    Message.PrintMainMenu("       E = Energies | P = Pokemons Collection | T = Training Actives Pokemons");
                    Message.PrintMainMenu("       Q = Quit");

                Console.ForegroundColor = ConsoleColor.White;
                    input = Console.ReadKey();
                    Console.ResetColor();

                    Console.WriteLine("\n");
                    Execute(input.Key);
                } while (!GameManager.gameOver && !GameManager.gameQuit);

        }
       
        private static void Execute(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.L:
                    RunAwayCounter();
                    break;
                case ConsoleKey.A:
                    if (GameManager.currentPlayer.Target == null)
                    {
                        Message.PrintInfo("There is no enemy to attack !");
                    }
                    else
                    {
                        GameManager.Battle();
                        GameManager.AfterBattle();
                    }
                    break;
                case ConsoleKey.S:
                    Message.PrintMenu(GameManager.currentPlayer.CurrentFighter.ToString());
                    break;
                case ConsoleKey.E:
                    GameManager.currentPlayer.ShowEnergies();
                    break;
                case ConsoleKey.P:
                    GameManager.currentPlayer.ShowPokemons();
                    break;
                case ConsoleKey.T:
                    if (GameManager.currentPlayer.Target == null)
                    {
                        GameManager.PokemonTrainig();
                    }
                    else{
                        Message.PrintDanger("There is a wild pokemon in front of you. You can't train right now");
                    }
                    
                    break;
                case ConsoleKey.Q:
                    Quit();
                        break;

                default:
                    Message.PrintDanger("Invalid Command ! Try again ...");
                    break;
            }
        }

        private static void Quit()
        {
            ConsoleKeyInfo input;
            if (GameManager.currentPlayer.Target == null)
            {
                Message.PrintDanger("Are you sure you want to leave the game? Y/N");
                input = Console.ReadKey();
                Console.ResetColor();
                Console.WriteLine("\n");
                if (input.Key == ConsoleKey.Y)
                {
                    GameManager.gameQuit = true;
                    Console.WriteLine("Good Bye !\nPress any key to close");
                    Console.Read();
                }
                else
                {
                    Message.PrintMainMenu("Getting back to game");
                    Console.ResetColor();
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Message.PrintDanger("You cannot quit the game !");
                Message.PrintDanger("There is an enemy in front of you !");
                GameManager.currentPlayer.Target.Attack(GameManager.currentPlayer.CurrentFighter);
            }
        }

        private static void RunAwayCounter()
        {
            if (GameManager.currentPlayer.Target == null)
            {
                GameManager.Explore();
            }
            else
            {
                if (GameManager.counter <=2)
                {
                    Message.PrintDanger("There is a " + GameManager.currentPlayer.Target.Name + " righ in front of you. You need to attack");
                    GameManager.counter++;
                }
                else
                {
                    GameManager.currentPlayer.Target.Attack(GameManager.currentPlayer.CurrentFighter);
                }

            }
        }

    }
}
