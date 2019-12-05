using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    class monster
    {
        public string name;
        public int HP;
        public int attack;
        public string skName;
        public int skAttack;
        public int hp;

        public void Initializing( )
        {
            HP = 10;
            attack = 4;
            skAttack = 5;
            hp = HP;
        }

    }
}
