using System;

namespace _28._12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[3];

            users[0] = new User( "Anastasiya", "Dajweoi1");
            users[1] = new User( "Elizaveta", "A2opkoi1");
            users[2] = new User( "Yelena", "23Fikswe");

            string input;

            do
            {
                Console.WriteLine("\n1.User əlavə et");
                Console.WriteLine("2.Userlere bax");
                Console.WriteLine("3.Userler üzrə axtarış et");

                input = Console.ReadLine();

                if (input == "1")
                {
                    NewUser(ref users, CreateUser());
                }

                else if (input == "2")
                {
                    ShowUsersInfo(users);
                }

                else if (input == "3")
                {
                    Console.WriteLine("Axtaris deyerini daxil edin:");
                    string find = Console.ReadLine();

                    var filter = searchUser(ref users, find);
                    ShowUsersInfo(filter);
                }

            } while (input != "1" || input != "2" || input != "3");
        }

        static void ShowUsersInfo(User[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].Showinfo());
            }
        }

        static User[] searchUser(ref User[] arr, string find)
        {
            User[] newArr = new User[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].UserName.Contains(find, StringComparison.OrdinalIgnoreCase))
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = arr[i];
                }
            }
            return newArr;
        }

        static User[] NewUser(ref User[] users, User user)
        {
            Array.Resize(ref users, users.Length + 1);
            users[users.Length - 1] = user;

            return users;
        }

        static User CreateUser()
        { 
            User usr = new User("                 ", "                  ");
            do
            {
                Console.Write("Username daxil edin: \n");
                usr.UserName = Console.ReadLine();

            } while (usr.UserName == null);

            do
            {
                Console.Write("Pass daxil edin: \n");
                usr.Password = Console.ReadLine();

            } while (usr.Password == null);

            return usr;
        }

    }
}
