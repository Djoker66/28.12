using System;

namespace _28._12_menu
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Store store = new Store("Konkakt Home")
            {
               ntbs = new Notebook[3] { new Notebook  { Name = "Macbook Pro 15", Price = 3500 }, 
                   new Notebook { Name = "Macbook Air", Price = 2500 },
                   new Notebook { Name = "Asus", Price = 2500 } }
            };

            Console.WriteLine(store.Name);
            Console.WriteLine(store.ntbs.Length + " - avg qiymet: " + store.AvgPrice.ToString("0.00"));


            Notebook[] notebooks = new Notebook[4];

            notebooks[0] = new Notebook("Macbook Pro 15", 3500);
            notebooks[1] = new Notebook("Macbook Pro 13", 2500);
            notebooks[2] = new Notebook("Macbook Air", 2500);
            notebooks[3] = new Notebook("Asus ROG", 3200);

            string input;
            do
            {
                Console.WriteLine("1. Notebooklar uzerinde axtaris");
                Console.WriteLine("2. Yeni notebook yarat");
                Console.WriteLine("3. Notebooklara bax");
                Console.WriteLine("0. Menudan cix");

                input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Axtaris deyerini daxil edin:");
                    string find = Console.ReadLine();

                    var filter = SearchByName(ref notebooks, find);
                    ShowNotebooksInfo(filter);
                }
                else if (input == "2")
                {

                    try
                    {
                        var notebook = CreateNotebook();
                        Array.Resize(ref notebooks, notebooks.Length + 1);
                        notebooks[notebooks.Length - 1] = notebook;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Xeta bas verdi, yeniden cehd edin");

                    }
                }
                else if (input == "3")
                {
                    ShowNotebooksInfo(notebooks);
                }


            } while (input != "0");

        }
       

    }
    
}
