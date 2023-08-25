using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Program
{
    internal class Password
    {
        public static string MenuName { get; set; }

        public static bool StartLogin()
        {

            {
                bool IsLoggedIn = false;
                int MenuNumber = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Hvad vil du?");
                    Console.WriteLine("-1 Login med eksisterende bruger");
                    Console.WriteLine("-2 skift password og brugernavn");
                    Console.WriteLine("-3 Exit");
                    try 
                    {
                        MenuNumber = int.Parse(Console.ReadLine());
                       
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Du skal tast et tal ind");
                        Console.ReadKey();
                    }

                    switch (MenuNumber)
                    {
                        case 1:
                            {
                                if (UserLogin())
                                {
                                    Console.WriteLine("Du er logget ind");
                                    IsLoggedIn = true;
                                    Console.ReadKey();
                                }
                                break;
                            }
                        case 2:
                            {
                                CodeChange();
                                break;
                            }
                        case 3:
                            {
                                System.Environment.Exit(0);
                                break;
                            }
                        default:
                            break;
                    }
                        
                          
                } while (!IsLoggedIn);
                return true;
            }
            {
            }
        }
        public static void CodeChange()
        { 
            string username = "";
            string password;
            bool pass = false;
            bool user = false;
            while (!user)
            {
                Console.Clear();
                Console.WriteLine("Her kan du skift username. Du kan også vælge at ikke ændre det ved at skrive den igen \n");
                Console.WriteLine("Skrive et Username: ");
                username = Console.ReadLine();
                if (string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("Du kan ikke have et tomt username");
                    Console.ReadKey();
                }
                else if (username.Any(u => char.IsWhiteSpace(u)))
                {
                    Console.WriteLine("Du må ikke have mellemrum i din brugernavn");
                    Console.ReadKey();
                }
                else
                {

                    user = true;
                }
            }
            while (!pass)
            {
                Console.Clear();
                Console.WriteLine("Her kan du skift password. Du kan også vælge at skrive den sammen password igen hvis du ikke vil ændre det \n");
                Console.WriteLine("Skrive en Password: ");
                password = Console.ReadLine();
                if (string.IsNullOrEmpty(password))
                {
                    Console.Clear();
                    Console.WriteLine("Du kan ikke have en tom password");
                    Console.ReadKey();

                }

                else if (!SpecialCharacters(password))

                {
                    Console.Clear();
                    Console.WriteLine("Du har brug for en af de her speciale tegn: ! \" # $ % & '");
                    Console.ReadKey();


                }
                else if (!MinLength(password))
                {
                    Console.Clear();
                    Console.WriteLine("Din password skal bestå af 12 characthers");
                    Console.ReadKey();


                }
                else if (password.Any(space => char.IsWhiteSpace(space)))
                {
                    Console.Clear();
                    Console.WriteLine("Du må ikke have mellemrum i dit password");
                    Console.ReadKey();


                }
                else if (!CapitalLetters(password))
                {
                    Console.Clear();
                    Console.WriteLine("Password har brug for at have lowercase og uppercase letters");
                    Console.ReadKey();

                }
                else if (!NumbersInEnds(password))
                {
                    Console.Clear();
                    Console.WriteLine("Du kan ikke have tal i slutning af passwordet");
                    Console.ReadKey();

                }
                else if (!OldPassword(password))
                {
                    Console.Clear();
                    Console.WriteLine("Passwordet kan ikke være den sammen som den gammle");
                    Console.ReadKey();

                }
                else
                {
                    pass = true;
                    Console.WriteLine("Du har ændret password");
                    string usernameDesktop = Environment.UserName;
                    string path = @"C:\Users\" + usernameDesktop + @"\Desktop\users.txt";
                    File.WriteAllText(path, password + " " + username);


                    Console.ReadKey();
                }

            }
            bool MinLength(string password1)
            {
                if (password1.Length < 12) return false;
                return true;
            }
            bool NumbersInEnds(string password1)
            {
                char first = password1[0];
                char last = password1[password1.Length - 1];
                if (char.IsNumber(first) || char.IsNumber(last)) return false;
                return true;
            }
            bool CapitalLetters(string password1)
            {
                if (password1.ToUpper() == password || password1.ToLower() == password1) return false;
                return true;
            }
            bool OldPassword(string password1)
            {
                string computerusername = Environment.UserName;
                string Mypath = @"C:\Users\" + computerusername + @"\Desktop\users.txt";

                string text = "";
                try
                {
                    text = File.ReadAllText(Mypath);
                }
                catch
                {
                    return true;
                }

                string[] passwords = text.Split('\n');
                for (int i = 0; i < passwords.Length; i++) if (password1 == passwords[i]) return false;
                return true;

            }

            bool SpecialCharacters(string password1)
            {

                char[] array = new char[] { char.Parse("!"), char.Parse("\""), char.Parse("#"), char.Parse("$"), char.Parse("%"), char.Parse("&"), char.Parse("'") };

                bool specialChar = false;
                bool number = false;

                for (int i = 0; i < password1.Length; i++)
                {
                    char c = password[i];
                    if (array.Contains(c))
                    {
                        specialChar = true;
                    }
                    else if (char.IsDigit(c))
                    {
                        number = true;
                    }
                }
                if (number && specialChar) return true;
                return false;
            }
        }
        public static bool UserLogin()
        {
            bool done = false;
            string user;
            string password;
            while (!done)
            {
                Console.Clear();
                Console.WriteLine("Loginside");
                Console.WriteLine("Username: ");
                user = Console.ReadLine();
                Console.WriteLine("Password: ");
                password = Console.ReadLine();
                if (LoginFil(user, password))
                {
                    done = true;
                    MenuName = user;
                    return true;
                }
                else
                {
                    Console.WriteLine("Username eller password er forkert!");

                }
                Console.ReadKey();
            }
            return false;
        }
        public static bool LoginFil(string user, string password)
        {
            bool auth = false;
            string usernameDesktop = Environment.UserName;
            string path = @"C:\Users\" + usernameDesktop + @"\Desktop\users.txt";
            string users = File.ReadAllText(path);
            string[] userArray = users.Split(' ');
                if(userArray[1] == user && userArray[0] == password)
                {
                    auth = true;
                }
            if (auth)
            {
                return true;
            }
            return false;
        }
    }
    }
