using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    class Program
    {
        //小怪战斗界面
        static void Screen1(player s1, monster s2, monster s3, ref string a1, ref string a2, ref string a3, ref string a4)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                      -----------------                   ");
            Console.WriteLine("                                                       小怪1                              ");
            Console.WriteLine("      -------------------                              HP  " + s2.HP + "                  ");
            Console.WriteLine("        " + s1.Name + "                                                                   ");
            Console.WriteLine("       等级:" + s1.Level + " 级                                        -----------------  ");
            Console.WriteLine("       HP:" + s1.HP + "                                                                   ");
            Console.WriteLine("       MP:" + s1.MP + "                                                                   ");
            Console.WriteLine("      -------------------                             -----------------                   ");
            Console.WriteLine("                                                       小怪2                              ");
            Console.WriteLine("                                                       HP  " + s3.HP + "                      ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                      ------------------                  ");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("  ");
            Console.WriteLine("            选择行动：                                       上一回合对战情况             ");
            Console.WriteLine("            1.攻击                                         " + a1);
            Console.WriteLine("            2.技能                                         " + a2);
            Console.WriteLine("            3.道具                                         " + a3);
            Console.WriteLine("                                                           " + a4);
            Console.WriteLine("   ");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            a1 = a2 = a3 = a4 = " ";
        }
        //BOSS战战斗界面
        static void Screen2(player s1, BOSS s4, ref string a1, ref string a2, ref string a3, ref string a4)
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("      -------------------                              -----------------                  ");
            Console.WriteLine("        " + s1.Name + "                                                                   ");
            Console.WriteLine("       等级:" + s1.Level + " 级                                       BOSS                ");
            Console.WriteLine("       HP:" + s1.HP + "                                           HP  " + s4.HP + "       ");
            Console.WriteLine("       MP:" + s1.MP + "                                                                   ");
            Console.WriteLine("      -------------------                             ------------------                  ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("  ");
            Console.WriteLine("            选择行动：                                       上一回合对战情况             ");
            Console.WriteLine("            1.攻击                                         " + a1);
            Console.WriteLine("            2.技能                                         " + a2);
            Console.WriteLine("            3.道具                                         " + a3);
            Console.WriteLine("            4.查看状态                                     " + a4);
            Console.WriteLine("   ");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            a1 = a2 = a3 = a4 = " ";
        }

        //二级菜单   技能界面
        static void SkillMenu(player s1)
        {
            Console.Clear();//清屏
            Console.WriteLine("-------------------------------");
            Console.WriteLine("  你所拥有的技能");
            for (int i = 0; i < 3; i++)
            {
                if (s1.S[i] == 1)
                {
                    Console.WriteLine("  {0}", i+1+ " . "+ s1.skill[i]  );
                }
                else
                    Console.WriteLine(" ");
            }
            Console.WriteLine("  0.退回主界面");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("选择行动：");

        }
        //二级菜单 道具界面
        static void PropMenu(player s1)
        {
            Console.Clear();//清屏
            Console.WriteLine("-------------------------------");
            Console.WriteLine("  你所拥有的道具");
            for (int i = 0; i < 4; i++)
            {
                if (s1.P[i] == 1)
                {
                    Console.WriteLine("  {0}", i + 1 + " . " + s1.prop[i]);
                }
                else
                    Console.WriteLine(" ");
            }
            Console.WriteLine("  0.退回主界面");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("选择行动：");
        }

        //通关
        static void Win()
        {
            Console.Clear();//清屏
            Console.Write("你打败了BOSS，通关了\n");
            Console.Write("恭喜恭喜");
            Console.ReadKey();
            System.Environment.Exit(0);//退出程序

        }
        //死亡
        static void End()
        {
            Console.Clear();//清屏
            Console.Write("你死了\n");
            Console.Write("再见");
            Console.ReadKey();
            System.Environment.Exit(0);//退出程序

        }
        static void Main(string[] args)
        {
            Random r = new Random();
            //创建人物
            player s1 = new player();
            Console.Write("请输入角色名：");
            s1.Name = Console.ReadLine();
            s1.HP = r.Next(12, 18);
            s1.MP = r.Next(10, 15);
            s1.Attack = r.Next(5, 8);
            s1.Block = r.Next(0, 2);
            s1.Level = 1;
            int hp = s1.HP;
            int mp = s1.MP;


            //创建小怪
            monster s2 = new monster();
            monster s3 = new monster();
            s2.Initializing();
            s3.Initializing();

            Console.WriteLine("============================================玩家=============================================");
            Console.WriteLine("玩家：" + s1.Name + ", 血量：" + s1.HP + ", 魔力值：" + s1.MP + "，攻击：" + s1.Attack + "，格挡:" + s1.Block);
            Console.WriteLine("成功创建人物");
            Console.WriteLine("按任意键进入游戏");
            Console.ReadKey();
            Console.Clear();//清屏

            string a1, a2, a3, a4;
            a1 = a2 = a3 = a4 = " ";
            Screen1(s1, s2, s3, ref a1, ref a2, ref a3, ref a4);
            Console.WriteLine("选择行动：");
            int a = Convert.ToInt32(Console.ReadLine());
            int cnt = 0;
           
            while (true)
            {
                switch (a)
                {
                    //普攻
                    case 1:
                        {
                            if (s2.HP != 0)
                            {

                                s2.HP -= s1.Attack;
                                a1 = "你使用了普攻";
                                a2 = "小怪1受到了" + s1.Attack + "点攻击";
                                if (s2.HP <= 0)
                                {
                                    s2.HP = 0;
                                    a3 = "小怪1死亡";
                                }
                            }

                            else
                            {
                                a1 = "你使用了普攻";
                                a2 = "小怪2受到了" + s1.Attack + "点攻击";
                                s3.HP -= s1.Attack;
                                if (s3.HP <= 0)
                                {
                                    s3.HP = 0;
                                    a3 = "小怪2死亡";
                                    a4 = "恭喜你获得了本轮战斗胜利,你将升级";
                                    s1.Level++;
                                    
                                    Console.Clear();//清屏
                                    Screen1(s1, s2, s3, ref a1, ref a2, ref a3, ref a4);
                                    Console.WriteLine("按任意键继续");
                                    Console.ReadKey();
                                    //Reflash(s1, s2, s3, a1, a2, a3, a4);
                                    //升级

                                    s1.Attack += r.Next(5, 10);
                                    s1.HP = r.Next(8, 12) + hp;
                                    s1.MP += r.Next(5, 10) + mp;
                                    s1.Block += r.Next(0, 5);

                                    //小怪升级
                                    s2.HP = s2.hp + r.Next(6, 10);
                                    s2.attack += r.Next(1, 3);
                                    s3.HP = s2.HP;
                                    s3.attack = s2.attack;
                                    cnt++;
                                    if (cnt==1)
                                    {
                                        a1 = "你习得了“治愈”技能和“同归于尽”技能";
                                        s1.S[1] = 1;
                                        s1.S[2] = 1;
                                        a2 = "你获得掉落的MP回复药水";
                                        s1.P[1] += 1;
                                        if (r.Next(10,20)>15)
                                        {
                                            a3 = "你意外捡到了神秘物品1";
                                            s1.P[2] += 1;
                                        }
                                        if(r.Next(10,20)>=17)
                                        {
                                            a4 = "你意外捡到了神秘物品2";
                                            s1.P[3] += 1;
                                        }
                                    }
                                    if(cnt==2)
                                    {
                                        s2.HP = 0;
                                        s3.HP = 0;
                                        a3 = "进入BOSS战";
                                        if (r.Next(10, 20) > 15)
                                        {
                                            a1 = "你意外捡到了神秘物品1";
                                            s1.P[2] += 1;
                                        }
                                        if (r.Next(10, 20) >= 17)
                                        {
                                            a2 = "你意外捡到了神秘物品2";
                                            s1.P[3] += 1;
                                        }
                                        
                                       
                                    }
                                    Console.Clear();//清屏
                                    Screen1(s1, s2, s3, ref a1, ref a2, ref a3, ref a4);
                                    Console.WriteLine("按任意键继续");
                                    Console.ReadKey();

                                }

                            }

                            break;
                        }
                        //技能
                    case 2:
                        {
                            SkillMenu(s1);
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (s1.MP >= 10)
                            {
                                a1 = a2 = a3 = a4 = " ";
                                s1.MP -= 10;
                                if (choice == 1)
                                {

                                    int n = s1.Attack + r.Next(1, 3) * s1.Level;
                                    s2.HP -= n;
                                    s3.HP -= n;
                                    a1 = "你成功使用了群攻";
                                    a2 = "小怪1和小怪2均受到了" + n + "点攻击";
                                    if (s2.HP <= 0 && s3.HP > 0)
                                    {
                                        a3 = "小怪1死亡";
                                        s2.HP = 0;
                                    }
                                    else if (s3.HP <= 0)
                                    {
                                        a3 = "小怪1和小怪2均死亡";
                                        a4 = "恭喜你获得了本轮战斗胜利,你将升级";
                                        s2.HP = 0;
                                        s3.HP = 0;
                                        Console.Clear();//清屏
                                        Screen1(s1, s2, s3, ref a1, ref a2, ref a3, ref a4);
                                        Console.WriteLine("按任意键继续");
                                        Console.ReadKey();

                                        s1.Attack += r.Next(5, 10);
                                        s1.HP = r.Next(8, 12) + hp;
                                        s1.MP += r.Next(5, 10) + mp;
                                        s1.Block += r.Next(0, 5);

                                        //小怪升级
                                        s2.HP = s2.hp + r.Next(6, 10);
                                        s2.attack += r.Next(1, 3);
                                        s3.HP = s2.HP;
                                        s3.attack = s2.attack;
                                        cnt++;
                                        if (cnt == 1)
                                        {
                                            a1 = "你习得了“治愈”技能和“同归于尽”技能";
                                            s1.S[1] = 1;
                                            s1.S[2] = 1;
                                            a2 = "你获得掉落的MP回复药水";
                                            s1.P[1] += 1;
                                            if (r.Next(10, 20) >= 15)
                                            {
                                                a3 = "你意外捡到了神秘物品1";
                                                s1.P[2] += 1;
                                            }
                                            if (r.Next(10, 20) >= 15)
                                            {
                                                a4 = "你意外捡到了神秘物品2";
                                                s1.P[3] += 1;
                                            }
                                        }
                                        if (cnt == 2)
                                        {
                                            s2.HP = 0;
                                            s3.HP = 0;
                                            a3 = "进入BOSS战";
                                            if (r.Next(10, 20) >= 15)
                                            {
                                                a1 = "你意外捡到了神秘物品1";
                                                s1.P[2] += 1;
                                            }
                                            if (r.Next(10, 20) >= 15)
                                            {
                                                a2 = "你意外捡到了神秘物品2";
                                                s1.P[3] += 1;
                                            }


                                        }
                                        Console.Clear();//清屏
                                        Screen1(s1, s2, s3, ref a1, ref a2, ref a3, ref a4);
                                        Console.WriteLine("按任意键继续");
                                        Console.ReadKey();

                                    }

                                }
                                if (choice == 2)
                                {
                                    s1.HP += 12;
                                    if (s1.HP > hp) s1.HP = hp;
                                    a1 = "你成功使用了治愈术";
                                    a2 = "你自身回复12点HP";
                                    
                                }
                                if (choice == 3)
                                {
                                    Console.Clear();//清屏
                                    Console.WriteLine("既然你非要这么选择我也没办法");
                                    Console.WriteLine("因为自身弱小，你选择了与小怪同归于尽");
                                    Console.WriteLine("但是BOSS尚未打败，唉");
                                    Console.WriteLine("按任意键继续");
                                    Console.ReadKey();
                                    End();
                                }
                            }
                            else
                            {
                                a1 = "技能使用失败";
                                a2 = "魔力值不足";
                            }
                            if(choice==0)
                            {
                                Console.Clear();//清屏
                                Console.WriteLine("你因为发呆或错误的行动延误了战机，敌方发起攻击");
                                Console.WriteLine("按任意键继续");
                                Console.ReadKey();
                            }
                            break;
                        }
                        //道具
                    case 3:
                        {
                            PropMenu(s1);
                            int choice = Convert.ToInt32(Console.ReadLine());
                            a1 = a2 = a3 = a4 = " ";
                            if (choice == 1)
                            {
                                s1.P[0]--;
                                s1.HP += 12;
                                if (s1.HP > hp) s1.HP = hp;
                                a1 = "你成功使用了HP回复药";
                                a2 = "你自身回复12点HP";
                            }
                            else if (choice == 2)
                            {
                                s1.P[1]--;
                                s1.MP += 12;
                                if (s1.MP > mp) s1.MP = mp;
                                a1 = "你成功使用了MP回复药";
                                a2 = "你自身回复12点MP";
                            }
                            else if (choice == 3)
                            {
                                Console.Clear();//清屏
                                Console.WriteLine("你使用了捡来的不明物质");
                                Console.WriteLine("你逐渐失去意识");
                                Console.WriteLine("按任意键继续");
                                Console.ReadKey();
                                End();
                            }
                            else if(choice==4)
                            {
                                Console.Clear();//清屏
                                Console.WriteLine("你使用了捡来的不明物质");
                                Console.WriteLine("你感觉理智出走");
                                Console.WriteLine("按任意键继续");
                                Console.ReadKey();
                                Console.Clear();//清屏
                                Console.WriteLine("失智的你干掉了所有怪物");
                                Console.WriteLine("你通关了");
                                Console.WriteLine("恭喜恭喜");
                                Console.WriteLine("按任意键继续");
                                Console.ReadKey();
                                System.Environment.Exit(0);//退出程序
                            }
                            else 
                            {
                                Console.Clear();//清屏
                                Console.WriteLine("退回战斗界面");
                                Console.WriteLine("按任意键继续");
                                Console.ReadKey();
                            }
                            break;
                        }
                }
                Console.Clear();//清屏
                Screen1(s1, s2, s3, ref a1, ref a2, ref a3, ref a4);
                Console.WriteLine("按任意键继续");
                Console.ReadKey();
                //两轮战跳出循环
                if (cnt == 2)
                    break;

                if (a==1||a==2)
                {
                    //小怪攻击
                a1 = "你受到敌方攻击";
                if (s2.HP > 0)
                {
                    s1.HP -= s2.attack;
                    a2 = "小怪1对你造成" + s2.attack + "点攻击";
                }
                s1.HP -= s3.attack;
                a3 = "小怪2对你造成" + s3.attack + "点攻击";
                Console.Clear();//清屏
                Screen1(s1, s2, s3, ref a1, ref a2, ref a3, ref a4);

                }
                if (s1.HP <= 0)
                {
                    Console.ReadKey();
                    Console.WriteLine("按任意键继续");
                    End();
                }
                else
                {
                    Console.WriteLine("选择行动：");
                    a = Convert.ToInt32(Console.ReadLine());
                }
            }
            //进入BOSS关卡
            BOSS s4 = new BOSS();
            s4.Initializing();
            Console.Clear();//清屏
            Screen2(s1, s4, ref a1, ref a2, ref a3, ref a4);
            Console.WriteLine("选择行动：");
            a = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                switch (a)
                {
                    case 1:
                        {
                            s4.HP -= s1.Attack;
                            a1 = "你使用了普攻";
                            a2 = "BOSS受到了" + s1.Attack + "点攻击";
                            if(s4.HP<=0)
                            {
                                Win();
                            }
                            break;
                        }
                    case 2:
                        {
                            SkillMenu(s1);
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (s1.MP >= 10)
                            {
                                a1 = a2 = a3 = a4 = " ";
                                s1.MP -= 10;
                                if (choice == 1)
                                {

                                    int n = s1.Attack + r.Next(1, 3) * s1.Level;
                                    s4.HP -= n;
                                    a1 = "你成功使用了群攻";
                                    a2 = "BOSS受到了" + n + "点攻击";
                                    if (s4.HP <= 0)
                                    {
                                        Win();
                                    }
                                }
                                if (choice == 2)
                                {
                                    s1.HP += 12;
                                    if (s1.HP > hp) s1.HP = hp;
                                    a1 = "你成功使用了治愈术";
                                    a2 = "你自身回复12点HP";
                                }
                                if (choice == 3)
                                {
                                    Console.Clear();//清屏
                                    Console.WriteLine("你在危难的时刻站了出来");
                                    Console.WriteLine("你选择与BOSS同归于尽");
                                    Console.WriteLine("你就是当代的董存瑞");
                                    Console.WriteLine("你牺牲自我，成全大家");
                                    Console.WriteLine("人们因为你过上幸福的生活");
                                    Console.WriteLine("你的名字代代相传");
                                    Console.WriteLine("你通关了");
                                    Console.WriteLine("可喜可贺，可喜可贺");
                                    Console.WriteLine("按任意键继续");
                                    Console.ReadKey();
                                    System.Environment.Exit(0);//退出程序
                                }
                            }
                            else
                            {
                                a1 = "技能使用失败";
                                a2 = "魔力值不足";
                            }
                            if (choice == 0)
                            {
                                Console.Clear();//清屏
                                Console.WriteLine("你因为发呆或错误的行动延误了战机，敌方发起攻击");
                                Console.WriteLine("按任意键继续");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            PropMenu(s1);
                            int choice = Convert.ToInt32(Console.ReadLine());
                            a1 = a2 = a3 = a4 = " ";
                            if (choice == 1)
                            {
                                s1.P[0]--;
                                s1.HP += 12;
                                if (s1.HP > hp) s1.HP = hp;
                                a1 = "你成功使用了HP回复药";
                                a2 = "你自身回复12点HP";
                            }
                            else if (choice == 2)
                            {
                                s1.P[1]--;
                                s1.MP += 12;
                                if (s1.MP > mp) s1.MP = mp;
                                a1 = "你成功使用了MP回复药";
                                a2 = "你自身回复12点MP";
                            }
                            else if (choice == 3)
                            {
                                Console.Clear();//清屏
                                Console.WriteLine("你使用了捡来的不明物质");
                                Console.WriteLine("你逐渐失去意识");
                                Console.WriteLine("按任意键继续");
                                Console.ReadKey();
                                End();
                            }
                            else if(choice==4)
                            {
                                Console.Clear();//清屏
                                Console.WriteLine("你使用了捡来的不明物质");
                                Console.WriteLine("你感觉理智出走");
                                Console.WriteLine("按任意键继续");
                                Console.ReadKey();
                                Console.Clear();//清屏
                                Console.WriteLine("失智的你打败了BOSS");
                                Console.WriteLine("你通关了");
                                Console.WriteLine("恭喜恭喜");
                                Console.WriteLine("按任意键继续");
                                Console.ReadKey();
                                System.Environment.Exit(0);//退出程序
                            }
                            else 
                            {
                                Console.Clear();//清屏
                                Console.WriteLine("退回战斗界面");
                                Console.WriteLine("按任意键继续");
                                Console.ReadKey();
                            }
                            break;
                        }
                   
                }
                Console.Clear();//清屏
                Screen2(s1, s4, ref a1, ref a2, ref a3, ref a4);
                Console.WriteLine("按任意键继续");
                Console.ReadKey();
                if(a==1||a==2)
                {
                    if (r.Next(0, 10) >= 7)
                    {
                        int m = s4.attack + r.Next(5, 8);
                        s1.HP -= m;
                        a1 = "。。。你运气太差，BOSS发大招了";
                        a2 = "你受到了"+ m + "点伤害";
                    }
                    else
                    {
                        int m = s4.attack + r.Next(2, 4);
                        s1.HP -= m;
                        a1 = "BOSS对你使用了普攻";
                        a2 = "你受到了" + m+ "点伤害";
                    }
                    Console.Clear();//清屏
                    Screen2(s1, s4, ref a1, ref a2, ref a3, ref a4);
                }
                if (s1.HP <= 0)
                {
                    Console.ReadKey();
                    Console.WriteLine("按任意键继续");
                    End();
                }
                else
                {
                    Console.WriteLine("选择行动：");
                    a = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }
}
