using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Easy_2031166.Classes
{
    class Player
    {
        private List<Pokemon> PokemonsCollection = new List<Pokemon>();
        private List<Energy> EnergiesCollection = new List<Energy>();
        private Pokemon Enemy = null;
        private Pokemon CurrentPokemon = null;
        private List<Pokemon> ActivePokemons = new List<Pokemon>(); // creat new list only with active pokemons


        public Pokemon CurrentFighter { get => CurrentPokemon;}
        public Pokemon Target { get => Enemy; set => Enemy = value; }
        public List<Pokemon> ActivePokemonsList { get => ActivePokemons; }

        public Player()
        {
            PokemonsCollection.Add(GameFactory.CreatePartnerPikachu());
            CurrentPokemon = PickPokemon();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            PokemonsCollection.Add(pokemon);
        }

        public void AddEnergy(Energy energy)
        {
            if (!EnergiesCollection.Contains(energy))
            {
                EnergiesCollection.Add(energy);
            }
            else
            {
                Message.PrintWarning("Already have this energy");
            }
        }

        public void ActivateAllPokemons()
        {

            foreach (Energy e in EnergiesCollection.ToArray())//create a copy list to erase item on original list without problems
            {
                foreach (Pokemon p in PokemonsCollection)
                {
                    if (p.Type == e && !(p.Hp==p.Hp_max))
                    {
                        p.Heal();
                        Message.PrintInfo("You used " + e + " energy on " + p.Name + ". It's status is now " + p.State + " and it's HP is " + p.Hp);
                        Console.WriteLine("\n");
                        EnergiesCollection.Remove(e);//remove item from original list.
                    }
                }
            }
        }

        public Pokemon PickPokemon()
        {
            Pokemon FastestPokemon = null;
            CreateActivesList();
            
            //ActivePokemons.Clear();
            //foreach (Pokemon p in PokemonsCollection)//add actives pokemons from pokemons colletion to the new list
            //{
            //    if (p.State == "ACTIVE")
            //    {
            //        ActivePokemons.Add(p);
            //    }
            //}

            if (ActivePokemons.Count == 1)//if there's only one, return this one. TODO
            {
                return ActivePokemons[0];
            }

            FastestPokemon = ActivePokemons[0];//if there are more than 1 Check which active pokemon is fastest
            for (int i = 1; i < ActivePokemons.Count; i++)
            {
                
                if (FastestPokemon.Speed < ActivePokemons[i].Speed)
                {
                    FastestPokemon = ActivePokemons[i];
                }

            }
            return FastestPokemon;
        }

        public void PrepareBattle(Pokemon enemy)
        {
            ActivateAllPokemons();
            Enemy = enemy;
            CurrentPokemon = PickPokemon();
            Message.PrintInfo(CurrentPokemon.Name + " was selected for battle, with " + CurrentPokemon.Speed + " speed!\n");

        }

        public void ShowEnergies()
        {
            if (EnergiesCollection.Count == 0)
            {
                Message.PrintInfo("You have no energies in your collection.\n");
            }
            else
            {
                Console.Write("Energies Collection: ");
                foreach (Energy e in EnergiesCollection)
                {
                    Console.Write(e.ToString().ToUpperInvariant() + " | ");
                    
                }
                Console.WriteLine();
            }
        }

        public void ShowPokemons()
        {
            Console.Write("Pokemons Collection:\n");
            foreach (Pokemon p in PokemonsCollection)
            {
                Console.Write(p.Name + " : " + p.State + " | Hp : "+p.Hp+" | Level : "+p.Level+" | Type : "+p.Type+"\n");
                
            }
            Console.WriteLine();
        }

        public Pokemon TrainPokemons()
        {
            CurrentPokemon = null;
            Enemy = null;
            Pokemon winner = null;
            
            if(ActivePokemons.Count == 2)
            {
                CurrentPokemon = ActivePokemons[0];
                Enemy = ActivePokemons[1];
            }
            else if (ActivePokemons.Count > 2)
            {
                do
                {
                    CurrentPokemon = ActivePokemons[RNG.GetInstance().Next(0, ActivePokemons.Count)];
                    Enemy = ActivePokemons[RNG.GetInstance().Next(0, ActivePokemons.Count)];
                } while (CurrentPokemon == Enemy);
            }
            

            GameManager.Battle();
            
            if (CurrentPokemon.State == "INNACTIVE")
            {
                Enemy.LevelUp(CurrentPokemon);
                winner = Enemy;
            }
            else
            {
                CurrentPokemon.LevelUp(Enemy);
                winner = CurrentPokemon;
            }
            Enemy.Heal();
            CurrentPokemon.Heal();
            return winner;
        }

        public void CreateActivesList ()
        {
            ActivePokemons.Clear();

            foreach (Pokemon p in PokemonsCollection)//add actives pokemons from pokemons colletion to the new list
            {
                if (p.State == "ACTIVE")
                {
                    ActivePokemons.Add(p);
                }
            }
        }
    }
}
