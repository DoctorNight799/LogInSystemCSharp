using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInSystem
{
    internal class Program
    {
        static bool isLoggedIn()
        {
            string username, password, un, pw;

            Console.Write("Enter username: ");
            username = Console.ReadLine();
            Console.Write("Enter password: ");
            password = Console.ReadLine();

            StreamReader sr = File.OpenText(@"c:\data\" + username + ".txt");
            un = sr.ReadLine();
            pw = sr.ReadLine();
            sr.Close();

            if (un == username && pw == password){
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            int choice;

            Console.Write("Make your choice.\n1:Registration\n2:LogIn\nYour choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string username, password;

                Console.Write("Enter username: ");
                username = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();

                if (!Directory.Exists(@"c:\data\"))
                {
                    Directory.CreateDirectory(@"c:\data\");
                }

                string path = (@"c:\data\" + username + ".txt");
                if (!File.Exists(path))
                {
                    StreamWriter sw = File.CreateText(path);
                    sw.WriteLine(username);
                    sw.WriteLine(password);
                    sw.Close();
                    Main(args);
                }
                else
                {
                    Console.WriteLine("Already exist.");
                    Main(args);
                }
            }
            else if(choice == 2)
            {
                bool status = isLoggedIn();
                if (!status)
                {
                    Console.WriteLine("Failed to login.");
                    Console.ReadLine();
                }
                else if (status)
                {
                    Console.WriteLine("Succesfully logged in.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Error.");
                    Console.ReadLine();
                }
            }
        }
    }
}
