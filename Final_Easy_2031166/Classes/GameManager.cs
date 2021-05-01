using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Easy_2031166.Classes
{
    class GameManager
    {
        public static Player currentPlayer = new Player();
        public static bool gameOver=false;
        public static bool gameQuit = false;
        public static int counter;

        
        public static void Explore()
        {
            int random = RNG.GetInstance().Next(0, 5);
            switch (random)
            {
                case 0:
                case 1:
                    currentPlayer.AddEnergy(GameFactory.Get_Random_Energy());
                    break;
                case 2:
                case 3:
                    Pokemon enemy = GameFactory.Get_Random_Pokemon();
                    currentPlayer.PrepareBattle(enemy);
                    break;
                case 4:
                default:
                    Console.WriteLine("Nothing found, look again");
                    break;
            }
        }


        public static void Battle()
        {
            counter = 0;
            while (currentPlayer.Target.State == "ACTIVE" && currentPlayer.CurrentFighter.State == "ACTIVE")
            {
                int TargetSpeed = currentPlayer.Target.Speed;
                int CurrentSpeed = currentPlayer.CurrentFighter.Speed;

                if (TargetSpeed > CurrentSpeed)
                {
                    currentPlayer.Target.Attack(currentPlayer.CurrentFighter);
                    currentPlayer.CurrentFighter.Attack(currentPlayer.Target);
                }
                else if (TargetSpeed < CurrentSpeed)
                {
                    currentPlayer.CurrentFighter.Attack(currentPlayer.Target);
                    currentPlayer.Target.Attack(currentPlayer.CurrentFighter);
                }
                else
                {
                    int random = RNG.GetInstance().Next(0, 100);
                    if (random % 2 == 0)
                    {
                        currentPlayer.CurrentFighter.Attack(currentPlayer.Target);
                        currentPlayer.Target.Attack(currentPlayer.CurrentFighter);
                    }
                    else
                    {
                        currentPlayer.Target.Attack(currentPlayer.CurrentFighter);
                        currentPlayer.CurrentFighter.Attack(currentPlayer.Target);
                    }

                }
            }
        }

        public static void AfterBattle()
        {
            if (currentPlayer.Target.State == "INNACTIVE")
            {
                currentPlayer.AddPokemon(currentPlayer.Target);
                currentPlayer.CurrentFighter.LevelUp(currentPlayer.Target);
                Message.PrintMainMenu("\nCongratulations!!!\nYou won the battle and captured " + currentPlayer.Target.Name + "\n"); 
            }
            if(currentPlayer.CurrentFighter.State == "INNACTIVE")
            {
                Message.PrintDanger(currentPlayer.CurrentFighter.Name +  " lost battle!!\n");
                if (currentPlayer.ActivePokemonsList.Count == 1)
                {
                    Message.PrintDanger("All your pokemons are fainted\nGame Over");
                    gameOver = true;
                    Console.Read();
                }
                else
                {
                    Message.PrintWarning("You ran away\n");
                }

            }
            currentPlayer.Target = null;
        }

        public static void PokemonTrainig()
        {
            ConsoleKeyInfo contin;
            Message.PrintMainMenu("Welcome to training mode, two random actives pokemons in your Pokedex will be selected ");
            Message.PrintMainMenu("to fight each other. The winner will improve exp");
            Message.PrintMainMenu("Don't worry, they will still be Actives and with Full Hp after fight");
            Message.PrintMainMenu("Would you like to continue? Y/N");
            contin = Console.ReadKey();

            if (contin.Key == ConsoleKey.Y)
            {
                currentPlayer.CreateActivesList();
                if (GameManager.currentPlayer.ActivePokemonsList.Count >= 2)
                {
                    GameManager.currentPlayer.TrainPokemons();


                }
                else
                {
                    Message.PrintInfo("You don't have enough actives Pokemons to train");
                }
                currentPlayer.Target = null;
            }
            

        }
    }
}
