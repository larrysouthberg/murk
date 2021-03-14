using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Murk_v2
{
    class Program
    {
        static int code, menuItem;
        static char[] cursorPosition = new char[255];

        //hero parametrs
        static int heroCoinsVolume = 0;
        static int regenNumber = 12;
        static int regenValue = 30;
        static int heroSkillId = 1;
        static int heroHealthPoints = 100;
        static int heroDamage = 20;
        static string heroName = "Неизвестный";

        static string[] mobName = { "Тварь    ", "Догнивающий", "Рейдер   ", "Пожиратель" };
        static int[] mobHealthPoints = { 100, 120, 80, 300 };
        static int[] mobDamage = { 10, 30, 15, 35 };
        static int[] mobCoinsVolume = { 12, 80, 30, 100 };

        static int mobId = 0;
        
        static void Clear()
        {
            Console.Clear();

        }

        static void Exit()
        {
            Clear();
            Environment.Exit(0);
        }

        static void TitlePrint()
        {
            Clear();
            Console.WriteLine("\n  Предвечный Морок v0.0.2");
            Console.ReadLine();
        }

        static void HeroDeath()
        {

            // reset stats
            heroCoinsVolume = 0;
            regenNumber = 10;
            regenValue = 30;
            heroSkillId = 1;
            heroHealthPoints = 100;
            heroDamage = 20;
            heroName = "Неизвестный";

            mobHealthPoints[0] = 100;
            mobHealthPoints[1] = 120;
            mobHealthPoints[2] = 80;
            mobHealthPoints[3] = 300;


            Clear();
            Console.WriteLine("\n  " + heroName + " погибает");
            Console.ReadLine();

            Menu();
        }

        static void PrintInfo(string heroName, int heroHealthPoints, int heroDamage, int regenNumber, string mobName, int mobHealthPoints, int mobDamage)
        {
            //print info for battles
            Console.Clear();
            Console.WriteLine("\n  " + heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
            Console.WriteLine();
            Console.WriteLine("  " + mobName + "\t - HP " + "[" + mobHealthPoints + "]" + " DMG " + "[" + mobDamage + "]");
            Console.WriteLine();
        }

        static void Battle(int mobId)
        {
            Console.Clear();
            Console.WriteLine("Battle");

           
            bool heroDeath = false;
            bool mobDeath = false;

            while (heroDeath == false && mobDeath == false)
            {

                code = 0; menuItem = 1; cursorPosition[0] = '>';

                do
                {
                    Clear();
                    PrintInfo(heroName, heroHealthPoints, heroDamage, regenNumber, mobName[mobId], mobHealthPoints[mobId], mobDamage[mobId]);
                    Console.Write("\n\n\n{0} Атаковать\n{1} Использовать зелье регенерации", cursorPosition[0], cursorPosition[1]);
                    code = Cursor(2);
                } while (code == 0);

                if (code == 1)
                {
                    mobHealthPoints[mobId] -= heroDamage;
                }
                else if (code == 2)
                {
                    if (regenNumber > 0)
                    {
                        heroHealthPoints += regenValue;
                        regenNumber--;
                    }
                }

                if (heroHealthPoints <= 0)
                {
                    heroDeath = true;
                    HeroDeath();
                }
                if (mobHealthPoints[mobId] <= 0)
                {
                    mobDeath = true;
                    heroCoinsVolume += mobCoinsVolume[mobId];
                    Console.Clear();
                    Console.WriteLine("\n  " + mobName[mobId] + " погибает");
                    Console.WriteLine("  Вы получили " + mobCoinsVolume[mobId] + " золота");
                    

                }

                PrintInfo(heroName, heroHealthPoints, heroDamage, regenNumber, mobName[mobId], mobHealthPoints[mobId], mobDamage[mobId]);

                heroHealthPoints -= mobDamage[mobId];

                if (heroHealthPoints <= 0)
                {
                    heroDeath = true;
                    HeroDeath();
                }
                if (mobHealthPoints[mobId] <= 0)
                {
                    mobDeath = true;
                    heroCoinsVolume += mobCoinsVolume[mobId];
                    Console.Clear();
                    Console.WriteLine("\n  " + mobName[mobId] + " погибает");
                    Console.WriteLine("  Вы получили " + mobCoinsVolume[mobId] + " золота");
                    Console.ReadLine();
                }

            }


            mobHealthPoints[0] = 100;
            mobHealthPoints[1] = 120;
            mobHealthPoints[2] = 80;
            mobHealthPoints[3] = 300;
        }

        static void Parametrs()
        {
            
            

            code = 0; menuItem = 1; cursorPosition[0] = '>';

            do
            {
                Clear();
                Console.WriteLine("\n  Параметры");
                Console.WriteLine();
                Console.WriteLine("  а где");

                Console.Write("\n\n\n{0} Назад", cursorPosition[0]);
                code = Cursor(1);
            } while (code == 0);
            if (code == 1)
            {
                Menu();
            }
            
        }

        static void StartGame()
        {

            
            ChapterOne();

        }

        static void ChapterOne()
        {
            Clear();
            Console.WriteLine("\n  Глава 1. Топи");
            Console.ReadLine();
            Clear();
            Swamp();
            ChapterTwo();
        }

        static void Swamp()
        {


            code = 0; menuItem = 1; cursorPosition[0] = '>';

            do
            {
                Clear();
                Console.WriteLine("\n  " + heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
                Console.WriteLine();
                Console.WriteLine("  Пробираясь через болото, вы наткнулись на тварь, она выглядит враждебно");
                Console.WriteLine();
                Console.Write("\n\n\n{0} Атаковать\n{1} Принять судьбу", cursorPosition[0], cursorPosition[1]);
                code = Cursor(2);
            } while (code == 0);

            if (code == 1)
            {
                Battle(0);
            }
            else if (code == 2)
            {
                HeroDeath();
            }


        }

        static void ChapterTwo()
        {
            code = 0; menuItem = 1; cursorPosition[0] = '>';

            do
            {
                Clear();
                Console.WriteLine("\n  " + heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
                Console.WriteLine();
                Console.WriteLine("  Вдалеке виднеется город, но уже вечереет");
                Console.WriteLine();
                Console.Write("\n\n\n{0} Идти ночью\n{1} Найти укрытие и дождаться утра", cursorPosition[0], cursorPosition[1]);
                code = Cursor(2);
            } while (code == 0);

            if (code == 1)
            {
                ToTown();
            }
            else if (code == 2)
            {
                NightChoice();
            }


            ChapterThree();
        }

        static void ToTown()
        {

            code = 0; menuItem = 1; cursorPosition[0] = '>';

            do
            {
                Clear();
                Console.WriteLine("\n  " + heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
                Console.WriteLine();
                Console.WriteLine("  В кромешной тьме вы медленно приближаетесь к главным воротам, внезапно на вас нападает рейдер");
                Console.WriteLine();
                Console.Write("\n\n\n{0} Защищаться\n{1} Попытаться договориться", cursorPosition[0], cursorPosition[1]);
                code = Cursor(2);
            } while (code == 0);

            if (code == 1)
            {
                Battle(2);
            }
            else if (code == 2)
            {
                Console.Clear();
                Console.WriteLine("\n  " + heroName + " был крайне наивен");
                Console.WriteLine("  Смерть не заставила себя долго ждать");
                Console.ReadLine();
                Menu();

            }

            


        }

        static void NightChoice()
        {
            
            code = 0; menuItem = 1; cursorPosition[0] = '>';

            do
            {
                Clear();
                Console.WriteLine("\n  " + heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
                Console.WriteLine();
                Console.WriteLine("  Выбор пал на небольшую пещеру и ствол мертвого дуба");
                Console.WriteLine();
                Console.Write("\n\n\n{0} Забраться в пещеру\n{1} Залезть в трещену в стволе", cursorPosition[0], cursorPosition[1]);
                code = Cursor(2);
            } while (code == 0);

            if (code == 1)
            {
                Cave();
            }
            else if (code == 2)
            {
                Oak();
            }


        }

        static void Cave()
        {
            Console.Clear();
            Console.WriteLine("\n  Произошёл обвал");
            Console.WriteLine("  " + heroName + " был погребён заживо");
            Console.ReadLine();
            Menu();
        }

        static void Oak()
        {
            Console.Clear();
            Console.WriteLine(heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
            Console.WriteLine();
            Console.WriteLine("Вы проснулись от жутких звуков, доносившихся из кустов");
            Console.WriteLine("Решив осмотреться, вы обнаруживаете мерзкого монстра с горящими глазами, из его пасти стекает черная субстанция");
            Console.WriteLine();
            Console.WriteLine("1. Атаковать");
            Console.WriteLine("2. Убежать");

            code = 0; menuItem = 1; cursorPosition[0] = '>';

            do
            {
                Clear();
                Console.WriteLine("\n  " + heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
                Console.WriteLine();
                Console.WriteLine("  Вы проснулись от жутких звуков, доносившихся из кустов");
                Console.WriteLine("  Решив осмотреться, вы обнаруживаете мерзкого монстра с горящими глазами,");
                Console.WriteLine("  из его пасти стекает черная субстанция");
                Console.WriteLine();
                Console.Write("\n\n\n{0} Атаковать\n{1} Убежать", cursorPosition[0], cursorPosition[1]);
                code = Cursor(2);
            } while (code == 0);

            if (code == 1)
            {
                Battle(1);
            }
            else if (code == 2)
            {
                HeroDeath();
            }

            ToTown();

        }

        static void ChapterThree()
        {
            Console.Clear();
            Console.WriteLine("\n  Глава 3. Труп");
            Console.WriteLine("  В разработке");
            Console.ReadLine();
            Menu();
        }

        static int Cursor(int maxi)
        {
            ConsoleKey btn = Console.ReadKey().Key;
            if (btn == ConsoleKey.Enter)
            {
                cursorPosition[menuItem - 1] = ' ';
                return menuItem;
            }
            if (btn == ConsoleKey.W || btn == ConsoleKey.UpArrow)
            {
                if (menuItem == 1)
                {
                    cursorPosition[0] = ' ';
                    menuItem = maxi;
                    cursorPosition[maxi - 1] = '>';
                    return 0;
                }
                else
                {
                    cursorPosition[menuItem - 1] = ' ';
                    cursorPosition[menuItem - 2] = '>';
                    menuItem--;
                    return 0;
                }
            }
            else if (btn == ConsoleKey.S || btn == ConsoleKey.DownArrow)
            {
                if (menuItem == maxi)
                {
                    cursorPosition[maxi - 1] = ' ';
                    menuItem = 1;
                    cursorPosition[0] = '>';
                    return 0;
                }
                else
                {
                    cursorPosition[menuItem - 1] = ' ';
                    cursorPosition[menuItem] = '>';
                    menuItem++;
                    return 0;
                }
            }
            else return 0;
        }

        static void Menu()
        {
            code = 0; menuItem = 1; cursorPosition[0] = '>';

            do
            {
                Clear();
                Console.Write("\n{0} Новая игра\n{1} Параметры\n{2} Выход", cursorPosition[0], cursorPosition[1], cursorPosition[2]);
                code = Cursor(3);
            } while (code == 0);
            if (code == 1)
            {
                StartGame();
            }
            else if (code == 2)
            {
                Parametrs();
            }
            else if (code == 3)
            {
                Exit();
            }
            

        }

        static void Main(string[] args)
        {

            


            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            TitlePrint();
            Menu();





            Console.ReadLine();
        }
    }
}
