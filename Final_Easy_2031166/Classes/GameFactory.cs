using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Easy_2031166.Classes
{
    public static class GameFactory
    {
        public static Energy Get_Random_Energy()
        {
            int random = RNG.GetInstance().Next(0, 4);
            switch (random)
            {
                case 0:
                    Message.PrintWarning("You found FIRE Energy (^_^)");
                    return Energy.FIRE;
                case 1:
                    Message.PrintWarning("You found GRASS Energy (^_^)");
                    return Energy.GRASS;
                case 2:
                    Message.PrintWarning("You found WATER Energy (^_^)");
                    return Energy.WATER;
                default:
                    Message.PrintWarning("You found LIGHTNING Energy (^_^)");
                    return Energy.LIGHTNING;
            }
        }
        public static Pokemon Get_Random_Pokemon()
        {
            int random = RNG.GetInstance().Next(0, 17);
            Pokemon randomPokemon = null;
            switch (random)
            {
                case 0:
                    Message.PrintDanger("The GRASS Pokemon Bulbasaur approaches (+_+) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Bulbasaur", ap: 28, hp: 100, speed: 50, type: Energy.GRASS);
                    break;
                case 1:
                    Message.PrintDanger("The GRASS Pokemon Treecko approaches (+_+) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Treecko", ap: 28, hp: 100, speed: 50, type: Energy.GRASS);
                    break;
                case 2:
                    Message.PrintDanger("The GRASS Pokemon Chikorita approaches (+_+) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Chikorita", ap: 35, hp: 100, speed: 45, type: Energy.GRASS);
                    break;
                case 3:
                    Message.PrintDanger("The GRASS Pokemon Bellossom approaches (+_+) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Bellossom", ap: 40, hp: 100, speed: 50, type: Energy.GRASS);
                    break;
                case 4:
                    Message.PrintDanger("The GRASS Pokemon Sunflora approaches (+_+) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Sunflora", ap: 20, hp: 100, speed: 30, type: Energy.GRASS);
                    break;
                case 5:
                    Message.PrintDanger("The FIRE Pokemon Charmander approaches (>_<) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Charmander", ap: 42, hp: 100, speed: 65, type: Energy.FIRE);
                    break;
                case 6:
                    Message.PrintDanger("The FIRE Pokemon Slugma approaches (>_<) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Slugma", ap: 30, hp: 100, speed: 20, type: Energy.FIRE);
                    break;
                case 7:
                    Message.PrintDanger("The FIRE Pokemon Charmander approaches (>_<) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Charmander", ap: 45, hp: 100, speed: 65, type: Energy.FIRE);
                    break;
                case 8:
                    Message.PrintDanger("The FIRE Pokemon Cyndaquil approaches (>_<) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Cyndaquil", ap: 40, hp: 100, speed: 70, type: Energy.FIRE);
                    break;
                case 9:
                    Message.PrintDanger("The WATER Pokemon Squirtle approaches (._.) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Squirtle", 48, 100, 56, type: Energy.WATER);
                    break;
                case 10:
                    Message.PrintDanger("The WATER Pokemon Seel approaches (._.) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Totodile", 55, 100, 43, type: Energy.WATER);
                    break;
                case 11:
                    Message.PrintDanger("The WATER Pokemon Seel approaches (._.) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Seel", 30, 100, 35, type: Energy.WATER);
                    break;
                case 12:
                    Message.PrintDanger("The WATER Pokemon Seel approaches (._.) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Wooper", 35, 100, 15, type: Energy.WATER);
                    break;
                case 13:
                    Message.PrintDanger("The LIGHTNING Pokemon Voltorb approaches (x_x) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Voltorb", ap: 30, hp: 100, speed: 100, type: Energy.LIGHTNING);
                    break;
                case 14:
                    Message.PrintDanger("The LIGHTNING Pokemon Electrode approaches (x_x) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Electrode", ap: 40, hp: 100, speed: 150, type: Energy.LIGHTNING);
                    break;
                case 15:
                    Message.PrintDanger("The LIGHTNING Pokemon Eelektrik approaches (x_x) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Eelektrik", ap: 50, hp: 100, speed: 76, type: Energy.LIGHTNING);
                    break;
                default:
                    Message.PrintDanger("The LIGHTNING Pokemon Helioptile approaches (x_x) Prepare for battle !");
                    randomPokemon = new Pokemon(name: "Helioptile", ap: 30, hp: 100, speed: 70, type: Energy.LIGHTNING);
                    break;
            }
            return randomPokemon;
        }

        public static Pokemon CreatePartnerPikachu()
        {
            Pokemon partner = new Pokemon(name: "Detective Pikachu", hp: 120, ap: 60, speed: 120, type: Energy.LIGHTNING);
            return partner;
        }
    }
}
