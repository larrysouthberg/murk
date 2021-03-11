using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murk_v01
{
    class Program
    {
        static void PrintInfo(string heroName, int heroHealthPoints, int heroDamage, int regenNumber, string mobName, int mobHealthPoints, int mobDamage)
        {
            //print info for battles
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

            //main menu
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
                            Console.WriteLine("2. Воин");
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
                            errorCheck = !(int.TryParse(Console.ReadLine(), out menuSelect));

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
                return;
            }

            //hero parametrs
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

            //battle with tvar'
            switch (selectAttackOrNo)
            {
                case 1:

                    //mob parametrs
                    string mobName = "Тварь";
                    int mobClassId = 0;
                    int mobDamage = 10;
                    int mobHealthPoints = 100;
                    int mobLevel = 1;
                    int mobCoinsVolume = 13;

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
                                if (regenNumber > 0)
                                {
                                    heroHealthPoints += regenValue;
                                    regenNumber--;
                                }
                                else
                                {
                                    break;
                                }
                                break;
                            default:
                                break;
                        }

                        if (heroHealthPoints <= 0)
                        {
                            heroDeath = true;
                            Console.Clear();
                            Console.WriteLine(heroName + " погибает");
                            Console.ReadLine();
                            return;
                        }
                        if (mobHealthPoints <= 0)
                        {
                            mobDeath = true;
                            heroCoinsVolume += mobCoinsVolume;
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
                            Console.ReadLine();
                            return;
                        }
                        if (mobHealthPoints <= 0)
                        {
                            mobDeath = true;
                            heroCoinsVolume += mobCoinsVolume;
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
                    Console.ReadLine();
                    return;
                default:
                    break;
            }
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Глава 2. Тьма");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine(heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
            Console.WriteLine();
            Console.WriteLine("Вдалеке виднеется город, но уже вечереет");
            Console.WriteLine();
            Console.WriteLine("1. Идти ночью");
            Console.WriteLine("2. Найти укрытие и дождаться утра");

            int selectChoice = int.Parse(Console.ReadLine());

            switch (selectChoice)
            {

                case 1:

                    Console.Clear();
                    Console.WriteLine(heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
                    Console.WriteLine();
                    Console.WriteLine("В кромешной тьме вы медленно приближаетесь к главным воротам, внезапно на вас нападает рейдер");
                    Console.WriteLine();
                    Console.WriteLine("1. Защищаться");
                    Console.WriteLine("2. Попытаться договориться");

                    int selectRaider = int.Parse(Console.ReadLine());

                    switch (selectRaider)
                    {
                        case 1:

                            //mob parametrs
                            string mobName = "Рейдер";
                            int mobClassId = 0;
                            int mobDamage = 15;
                            int mobHealthPoints = 75;
                            int mobLevel = 1;
                            int mobCoinsVolume = 283;

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
                                        if (regenNumber > 0)
                                        {
                                            heroHealthPoints += regenValue;
                                            regenNumber--;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        break;
                                    default:
                                        break;
                                }

                                if (heroHealthPoints <= 0)
                                {
                                    heroDeath = true;
                                    Console.Clear();
                                    Console.WriteLine(heroName + " погибает");
                                    Console.ReadLine();
                                    return;
                                }
                                if (mobHealthPoints <= 0)
                                {
                                    mobDeath = true;
                                    heroCoinsVolume += mobCoinsVolume;
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
                                    Console.ReadLine();
                                    return;
                                }
                                if (mobHealthPoints <= 0)
                                {
                                    mobDeath = true;
                                    heroCoinsVolume += mobCoinsVolume;
                                    Console.Clear();
                                    Console.WriteLine(mobName + " погибает");
                                    break;
                                }

                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine(heroName + " был крайне наивен");
                            Console.WriteLine("Смерть не заставила себя долго ждать");
                            Console.ReadLine();
                            return;
                        default:
                            break;
                    }

                    break;
                case 2:

                    Console.Clear();
                    Console.WriteLine(heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
                    Console.WriteLine();
                    Console.WriteLine("Выбор пал на небольшую пещеру и ствол мертвого дуба");
                    Console.WriteLine();
                    Console.WriteLine("1. Забраться в пещеру");
                    Console.WriteLine("2. Залезть в трещену в стволе");

                    int selectShelter = int.Parse(Console.ReadLine());

                    switch (selectShelter)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Произошёл обвал");
                            Console.WriteLine(heroName + " был погребён заживо");
                            Console.ReadLine();
                            return;
                        case 2:

                            Console.Clear();
                            Console.WriteLine(heroName + "\t - HP " + "[" + heroHealthPoints + "]" + " DMG " + "[" + heroDamage + "]" + " REG " + "[" + regenNumber + "]");
                            Console.WriteLine();
                            Console.WriteLine("Вы проснулись от жутких звуков, доносившихся из кустов");
                            Console.WriteLine("Решив осмотреться, вы обнаруживаете мерзкого монстра с горящими глазами, из его пасти стекает черная субстанция");
                            Console.WriteLine();
                            Console.WriteLine("1. Атаковать");
                            Console.WriteLine("2. Убежать");

                            selectAttackOrNo = int.Parse(Console.ReadLine());

                            //battle with dognivaushij' (eto smert')
                            switch (selectAttackOrNo)
                            {
                                case 1:

                                    //mob parametrs
                                    string mobName = "Догнивающий";
                                    int mobClassId = 0;
                                    int mobDamage = 50;
                                    int mobHealthPoints = 300;
                                    int mobLevel = 1;
                                    int mobCoinsVolume = 10000;

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
                                                if (regenNumber > 0)
                                                {
                                                    heroHealthPoints += regenValue;
                                                    regenNumber--;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                                break;
                                            default:
                                                break;
                                        }

                                        if (heroHealthPoints <= 0)
                                        {
                                            heroDeath = true;
                                            Console.Clear();
                                            Console.WriteLine(heroName + " погибает");
                                            Console.ReadLine();
                                            return;
                                        }
                                        if (mobHealthPoints <= 0)
                                        {
                                            mobDeath = true;
                                            heroCoinsVolume += mobCoinsVolume;
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
                                            Console.ReadLine();
                                            return;
                                        }
                                        if (mobHealthPoints <= 0)
                                        {
                                            mobDeath = true;
                                            heroCoinsVolume += mobCoinsVolume;
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
                                    Console.ReadLine();
                                    return;
                                default:
                                    break;
                            }
                            Console.ReadLine();

                            break;
                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Глава 3. Труп");
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
