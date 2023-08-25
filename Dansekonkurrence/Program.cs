using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Program
{
        internal class Program
        {
            static void Main(string[] args)
            {
                string username = Environment.UserName;
                string path = @"C:\Users\" + username + @"\Desktop\users.txt";

                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                int valg = 0;
            
                Password.UserLogin();

            Console.WriteLine("Hvad vil du?");
            Console.WriteLine("-1 fodbold");
            Console.WriteLine("-2 dancekonkurrence");
            Console.WriteLine("-3 skift password eller brugernavn");
            
            try
            {
                valg = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Du skal skrive et tal");
                Console.ReadKey();
            }

            switch (valg)
            {
                case 1:
                    {
                        Console.Clear();
                        Mål.Afleveringer();
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        DansePartnerPoints person1 = new DansePartnerPoints();
                        DansePartnerPoints person2 = new DansePartnerPoints();

                        person1.Rating();
                        person2.Rating();

                        DansePartnerPoints par = person1 + person2;

                        Console.WriteLine($"{par.Navn} {par.Point}");
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Password.CodeChange();
                        Console.ReadKey();
                        break;
                    }
                    default:
                    break;
            }
            }
        }
    }

