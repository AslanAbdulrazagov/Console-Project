using MiniApp.Exceptions;

namespace MiniApp.Models
{
    public class User : BaseEntity
    {
        private string _fullName;
        public string Email { get; set; }
        private string _password;
        public string Fullname
        {
            get => _fullName;
            set
            {
                while (value.Length < 3 || value.Length > 15)
                {
                    Console.WriteLine("name length is not correct!");
                    Console.Write("enter again:");
                    value = Console.ReadLine();
                }
                if (value.Length >= 3 && value.Length <= 15) _fullName = value;
            }

        }
       
   

        public string Password
        {
            get => _password;
            set
            {
                while (true)
                {
                    bool isDigit = false;
                    bool isUpper = false;
                    bool isLower = false;
                    if (value.Length >= 8)
                    {
                        for (int i = 0; i < value.Length; i++)
                        {
                            if (char.IsDigit(value[i])) isDigit = true;
                            else if (char.IsUpper(value[i])) isUpper = true;
                            else if (char.IsLower(value[i])) isLower = true;
                            if (isDigit && isLower && isUpper)
                            {
                                _password = value;
                                return;
                            }
                        }
                        Console.WriteLine("password again:");
                        value = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("password contains at least 8 chars:");
                        value = Console.ReadLine();
                    }

                }

            }

        }
    }
}