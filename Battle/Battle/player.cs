using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    class player
    {
        //名字
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int level;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        
        //血量
        private int hp;

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        //魔力值
        private int mp;

        public int MP
        {
            get { return mp; }
            set { mp = value; }
        }

        //攻击力
        private int attack;

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        
        //暴击
        private int critical;

        public int Critical
        {
            get { return critical; }
            set { critical = value; }
        }
        //格挡
        private int block;

        public int Block
        {
            get { return block; }
            set { block = value; }
        }

        public string[] skill = { "群攻(消耗MP10)", "治愈(消耗MP10)", "同归于尽(消耗MP10)" };
        public int[] S = { 1, 0, 0 };
        public string[] prop = { "HP回复药", "MP回复药", "神秘物品1", "神秘物品2" };
        public int[] P = { 1, 0, 0, 0 };
    }
}
