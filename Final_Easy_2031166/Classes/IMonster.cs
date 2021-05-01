using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Easy_2031166.Classes
{
    public interface IMonster
    {
        void ReceiveDamage(int damage);
        void Attack(Monster target);
    }
}
