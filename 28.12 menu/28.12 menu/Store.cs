using System;
using System.Collections.Generic;
using System.Text;

namespace _28._12_menu
{
    internal class Store
    {
        public string Name;
        public Notebook[] ntbs;


        public Store(string name)
        {
            this.Name = name;
        }

        public double AvgPrice
        {
            get => _avgPrice();
        }
        private double _avgPrice()
        {
            double sum = 0;
            for (int i = 0; i < ntbs.Length; i++)
            {
                sum += ntbs[i].Price;
            }

            return sum / ntbs.Length;
        }


        static void ShowNotebooksInfo(Notebook[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].GetInfo());
            }
        }

        static Notebook[] SearchByName(ref Notebook[] arr, string search)
        {
            Notebook[] newArr = new Notebook[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Name.Contains(search))
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = arr[i];
                }
            }

            return newArr;
        }

        static Notebook CreateNotebook()
        {
            Console.WriteLine("Notebook yarat:");
            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new NameFormatException("Name deyeri minimum 3 uzunlquda olmalidir!");
            }

            double price;
            bool check = true;
            do
            {
                Console.WriteLine("enter price:");
                string priceStr = Console.ReadLine();
                check = double.TryParse(priceStr, out price);

                if (check == false)
                    Console.WriteLine("Price deyeri eded olmalidir");

            } while (!check);


            byte ram;

            do
            {
                Console.WriteLine("Ram:");
                string ramStr = Console.ReadLine();
                check = byte.TryParse(ramStr, out ram);

                if (check == false)
                    Console.WriteLine("Ram deyeri eded olmalidir");

            } while (!check);



            return new Notebook(name, price, ram);
        }

        static bool TryParseByte(string str, out byte num)
        {
            try
            {
                num = Convert.ToByte(str);
                return true;
            }
            catch (Exception)
            {
                num = 0;
                return false;
            }
        }
    }
}
