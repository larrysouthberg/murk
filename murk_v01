using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2_Murk_v01
{
    class Program
    {
        static void PrintInfo(string heroName, int heroHealthPoints, int heroDamage, int regenNumber, string mobName, int mobHealthPoints, int mobDamage)
        {
            Console.Clear();
            Console.WriteLine(heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
            Console.WriteLine();
            Console.WriteLine(mobName + "\t - HP " + "[" + mobHealthPoints + "]" + " DMG " + "[" + mobDamage + "]");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            int heroClassId = 0;
            string heroName = "Неизвестный";

            bool selected = false;
            bool exit = false;
            bool errorCheck = false;

            do
            {
                
                int menuSelect;
                Console.WriteLine("Главное меню");
                Console.WriteLine();
                Console.WriteLine("1. Запуск");
                Console.WriteLine("2. Параметры");
                Console.WriteLine("3. Выход");

                errorCheck = !(int.TryParse(Console.ReadLine(), out menuSelect));

                switch (menuSelect)
                {
                    case 1:

                        Console.Clear();
                        Console.WriteLine("Предвечный морок v0.1");
                        Console.ReadLine();

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Выберите персонажа:");
                            Console.WriteLine();
                            Console.WriteLine("1. Лучник");
                            Console.WriteLine("2. Мечник");
                            Console.WriteLine("3. Маг");
                            errorCheck = !(int.TryParse(Console.ReadLine(), out menuSelect));

                            switch (menuSelect)
                            {
                                case 1:
                                    heroClassId = 1;
                                    selected = true;
                                    break;
                                case 2:
                                    heroClassId = 2;
                                    selected = true;
                                    break;
                                case 3:
                                    heroClassId = 3;
                                    selected = true;
                                    break;
                                default:
                                    errorCheck = true;
                                    continue;
                            }
                        } while (errorCheck == true);

                        Console.Clear();
                        Console.WriteLine("Введите имя:");
                        heroName = Console.ReadLine();

                        break;
                    case 2:
                        
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Параметры");
                            Console.WriteLine();
                            Console.WriteLine("1. Назад");
                            errorCheck = !(int.TryParse(Console.ReadLine(),out menuSelect));

                            switch (menuSelect)
                            {
                                case 1:
                                    Console.Clear();
                                    continue;
                                default:
                                    errorCheck = true;
                                    continue;
                            }
                            
                        } while (errorCheck == true);
                        break;
                    case 3:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Подтвердите выход:");
                            Console.WriteLine();
                            Console.WriteLine("1. Выход");
                            Console.WriteLine("2. Отмена");
                            errorCheck = !(int.TryParse(Console.ReadLine(), out menuSelect));
                            switch (menuSelect)
                            {
                                case 1:
                                    exit = true;
                                    break;
                                case 2:
                                    Console.Clear();
                                    continue;
                                default:
                                    errorCheck = true;
                                    break;
                            }
                        } while (errorCheck == true);
                        break;
                    default:
                        break;
                }

                Console.Clear();
            } while (selected == false && exit == false);

            if (exit == true)
            {
                return ;
            }

            //hero 
            int heroCoinsVolume = 0;
            int regenNumber = 10;
            int regenValue = 30;
            int heroSkillId = 1;
            int heroHealthPoints = 0;
            int heroDamage = 0;

            switch (heroClassId)
            {
                case 1:

                    heroHealthPoints = 120;
                    heroDamage = 25;
                    break;
                case 2:
                    heroHealthPoints = 140;
                    heroDamage = 20;
                    break;
                case 3:
                    heroHealthPoints = 80;
                    heroDamage = 40;
                    break;
            }

            Console.WriteLine("Глава 1. Топи");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine(heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
            Console.WriteLine();
            Console.WriteLine("Пробираясь через болото, вы наткнулись на тварь, она выглядит враждебно");
            Console.WriteLine();
            Console.WriteLine("1. Атаковать");
            Console.WriteLine("2. Принять судьбу");

            int selectAttackOrNo = int.Parse(Console.ReadLine());

            switch (selectAttackOrNo)
            {
                case 1:

                    //mob
                    string mobName = "Тварь";
                    int mobClassId = 0;
                    int mobDamage = 10;
                    int mobHealthPoints = 100;
                    int mobLevel = 1;
                    int mobCoinsVolume = 0;

                    bool heroDeath = false;
                    bool mobDeath = false;

                    while (heroDeath == false && mobDeath == false)
                    {

                        PrintInfo(heroName, heroHealthPoints, heroDamage, regenNumber, mobName, mobHealthPoints, mobDamage);

                        Console.WriteLine("1. Атаковать");
                        Console.WriteLine("2. Использовать зелье регенерации");
                        int selectAction = int.Parse(Console.ReadLine());

                        switch (selectAction)
                        {
                            case 1:
                                mobHealthPoints -= heroDamage;
                                break;
                            case 2:
                                heroHealthPoints += regenValue;
                                regenNumber--;
                                break;
                            default:
                                break;
                        }

                        if (heroHealthPoints <= 0)
                        {
                            heroDeath = true;
                            Console.Clear();
                            Console.WriteLine(heroName + " погибает");
                            break;
                        }
                        if (mobHealthPoints <= 0)
                        {
                            mobDeath = true;
                            Console.Clear();
                            Console.WriteLine(mobName + " погибает");
                            break;
                        }

                        PrintInfo(heroName, heroHealthPoints, heroDamage, regenNumber, mobName, mobHealthPoints, mobDamage);

                        heroHealthPoints -= mobDamage;

                        if (heroHealthPoints <= 0)
                        {
                            heroDeath = true;
                            Console.Clear();
                            Console.WriteLine(heroName + " погибает");
                            break;
                        }
                        if (mobHealthPoints <= 0)
                        {
                            mobDeath = true;
                            Console.Clear();
                            Console.WriteLine(mobName + " погибает");
                            break;
                        }

                    }
                    break;
                case 2:
                    heroDeath = true;
                    Console.Clear();
                    Console.WriteLine(heroName + " погибает");
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
