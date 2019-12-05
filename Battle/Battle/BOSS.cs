using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    class BOSS
    {
        public string name;
        public int HP;
        public int attack;
        public string skName1;
        public int skAttack1;
        public string skName2;
        public int skAttack2;
        public string skName3;
        public int skAttack3;


        public void Initializing()
        {
            HP = 50;
            attack = 8;
            skAttack1 = 5;
        }
    }
}
