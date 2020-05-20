using System;
using System.IO;

namespace OOP_lab_5_7_2
{
    class Hospital : Reception
    {
        public static void Add()
        {
            StreamWriter file = new StreamWriter("base.txt", true);

            Console.WriteLine("\nВведiть новi данi");

            Console.Write("Прiзище: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("Фах: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("День: ");

            file.WriteLine(Console.ReadLine());

            Console.Write("Змiна: ");

            file.WriteLine(Console.ReadLine());

        Retry:
            Console.Write("Кiлькiсть вiдвiдувачiв:");

            try
            {
                file.WriteLine(int.Parse(Console.ReadLine()));
            }
            catch (SystemException)
            {
                Console.WriteLine("Кiлькiсть вiдвiдувачiв має бути вказана лише числом!");

                goto Retry;
            }

            file.Close();

            ReadBase();
        }

        public static void Remove()
        {
            Console.WriteLine();

            Write();

            Console.Write("Порядковий номер запису для видалення: ");

            bool[] remove = new bool[Program.doctors.Length];

            for (int i = 0; i < remove.Length; ++i)
            {
                remove[i] = false;
            }

            try
            {
                remove[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не існує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                if (!remove[i])
                {
                    file.WriteLine(Program.doctors[i].Surename);
                    file.WriteLine(Program.doctors[i].Profession);
                    file.WriteLine(Program.doctors[i].Day);
                    file.WriteLine(Program.doctors[i].Shift);
                    file.WriteLine(Program.doctors[i].VisitorsCount);
                }
            }

            Console.Write("Видалено!\n");

            file.Close();

            ReadBase();
        }

        public static void Edit()
        {
            Console.WriteLine();

            Write();

            Console.Write("Порядковий номер запису для редагування: ");

            bool[] edit = new bool[Program.doctors.Length];

            for (int i = 0; i < edit.Length; ++i)
            {
                edit[i] = false;
            }

            try
            {
                edit[int.Parse(Console.ReadLine()) - 1] = true;
            }
            catch (SystemException)
            {
                Console.WriteLine("Такого запису не існує!");
                return;
            }

            StreamWriter file = new StreamWriter("base.txt");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                if (edit[i])
                {
                    Console.WriteLine("Введiть новi данi");

                    Console.Write("Прiзище: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("Фах: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("День: ");

                    file.WriteLine(Console.ReadLine());

                    Console.Write("Змiна: ");

                    file.WriteLine(Console.ReadLine());

                Retry:
                    Console.Write("Кiлькiсть вiдвiдувачiв:");

                    try
                    {
                        file.WriteLine(int.Parse(Console.ReadLine()));
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("Кiлькiсть вiдвiдувачiв має бути вказана лише числом!");

                        goto Retry;
                    }
                }
                else
                {
                    file.WriteLine(Program.doctors[i].Surename);
                    file.WriteLine(Program.doctors[i].Profession);
                    file.WriteLine(Program.doctors[i].Day);
                    file.WriteLine(Program.doctors[i].Shift);
                    file.WriteLine(Program.doctors[i].VisitorsCount);
                }
            }

            Console.Write("Змiни внесено!\n");

            file.Close();

            ReadBase();
        }

        public static void InitialiseBase(int n)
        {
            Program.doctors = new Reception[n];
        }

        public static void Write()
        {
            const string Format = "{0, -20} {1, -25} {2, -10} {3, -10} {4, -25}";

            Console.WriteLine(Format, "Прiзище", "Фах", "День", "Змiна", "Кiлькiсть вiдвiдувачiв");

            for (int i = 0; i < Program.doctors.Length; ++i)
            {
                Console.WriteLine(Format, Program.doctors[i].Surename, Program.doctors[i].Profession, Program.doctors[i].Day, Program.doctors[i].Shift, Program.doctors[i].VisitorsCount);
            }
        }

        public static void Read()
        {
            ReadBase();
            ReadKey();
        }

        public static void ReadBase()
        {
            StreamReader file = new StreamReader("base.txt");

            string[] tempStr = file.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            InitialiseBase(tempStr.Length / 5);

            for (int i = 0; i < tempStr.Length; i += 5)
            {
                Program.doctors[i / 5] = new Reception(tempStr[i], tempStr[i + 1], tempStr[i + 2], tempStr[i + 3], int.Parse(tempStr[i + 4]));
            }

            file.Close();
        }

        public static void ReadKey()
        {

        Start:

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Вихiд: Esc");

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.OemPlus:
                    Add();
                    goto Start;

                case ConsoleKey.E:
                    Edit();
                    goto Start;

                case ConsoleKey.OemMinus:
                    Remove();
                    goto Start;

                case ConsoleKey.Enter:
                    Write();
                    goto Start;

                case ConsoleKey.Escape:
                    return;

                default:
                    Console.WriteLine();
                    goto Start;
            }
        }
    }
}
