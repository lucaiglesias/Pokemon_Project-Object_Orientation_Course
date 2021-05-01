using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Easy_2031166.Classes
{
    public enum Energy { FIRE, GRASS, LIGHTNING, WATER }
    public class Pokemon: Monster
    {
        private int speed;
        private Energy type;
        private bool fainted;
        //private int exp;
        //private int level;

        public int Speed { get => speed; set => speed = value; }
        public Energy Type { get => type; set => type = value; }
        public string State {get => fainted ? "INNACTIVE" : "ACTIVE"; }//Ternary operator
        //public int Exp { get => exp; set => exp = value; }
        //public int Level { get => level; set => level = value; }

        public Pokemon(string name, int ap, int hp, int speed, Energy type) :base(name,hp,ap)//call parent constructor
        {
            this.speed = speed;
            this.type = type;
            this.fainted = false;
            this.Exp = 0;
            this.Level = 1;
        }

        public override void ReceiveDamage(int damage)
        {
            this.Hp -= damage;
            
            if (this.Hp <= 0)
            {
                this.fainted = true;
                Message.PrintWarning(this.Name + " fainted ");
            }
            else
            {
                Message.PrintWarning(this.Name + " HP is now " + this.Hp);
            }
        }

        public override void Attack(Monster target)
        {
            if (this.fainted)
            {
                Console.WriteLine(this.Name + " is not active yet");
                //LevelUp(target);

            }
            else
            {
                int random_damage = RNG.GetInstance().Next(0, this.Ap);
                Message.PrintInfo(this.Name + " attacks " + target.Name + " with " + random_damage + " attack power!");
                target.ReceiveDamage(random_damage);
                
            }
        }

        public void Heal()
        {
            this.Hp = Hp_max;
            this.fainted = false;
        }

        public override string ToString()
        {
            return this.Name + ", Level: "+this.Level+ ", HP: " + this.Hp + ", AP: " + this.Ap + ", Speed: " + this.speed + ", State: " + this.State + ", Energy Type: " + this.type;
        }

        public void LevelUp(Monster target)
        {
            this.Exp += 2*target.Level;
            Message.PrintInfo(this.Name + " won "+2*target.Level+" points of experince. It's total now is "+this.Exp);
            int requiredXP = (int)Math.Floor(10 * Math.Pow(this.Level, 2));
            if (this.Exp >= requiredXP)
            {
                this.Level += 1;
                this.Hp = this.Hp_max + 10;
                this.Ap += 5;
                this.Exp -= requiredXP;
                Message.PrintInfo(this.Name + " is now level " + this.Level);

            }

        }
    }
}
