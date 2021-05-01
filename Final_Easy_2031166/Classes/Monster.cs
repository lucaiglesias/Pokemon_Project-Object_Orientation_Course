using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Easy_2031166.Classes
{
    public abstract class Monster : IMonster
    {
        private string name;
        private int hp;
        private int ap;
        private int hp_max;
        private int exp;//TODO
        private int level;//TODO

        public Monster(string name, int hp, int ap)
        {
            this.name = name;
            this.hp = hp;
            this.ap = ap;
            this.hp_max = hp;
        }

        public string Name { get => name; set => name = value; }
        public int Ap { get => ap; set => ap = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Hp_max { get => hp_max; set => hp_max = value; }
        public int Exp { get => exp; set => exp = value; }//TODO
        public int Level { get => level; set => level = value; }//TODO

        public virtual void ReceiveDamage(int damage)
        {
            this.hp -= damage;
        }
        public abstract void Attack(Monster target);



    }
}
