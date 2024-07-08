using MiniApp.Exceptions;
using MiniApp.Models;
using MiniApp.Services;
using System.Linq.Expressions;

namespace MiniApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            UserService userService = new UserService();
            CategoryService categoryService = new CategoryService();
            MedicineService medicineService = new MedicineService();

           
            Console.WriteLine("Welcome!");
        menu1:
            Console.WriteLine("1. Register ");
            Console.WriteLine("2. Login ");
            Console.WriteLine("3. Show menu ");
            Console.WriteLine("4. Exit ");
           

            while (true)
            {
                Console.WriteLine();
                Console.Write("Choose ");

                int opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        User user = new User();
                        Console.Write("Enter Fullname:");
                        user.Fullname = Console.ReadLine();
                        Console.Write("Enter Email:");
                        user.Email = Console.ReadLine();
                        Console.Write("Enter Password:");
                        user.Password = Console.ReadLine();
                        userService.AddUser(user);
                        Console.WriteLine();
                        break;
                    case 2:
                        User loggedInUser = null;

                        Console.Write("Enter email:");
                        string email = Console.ReadLine();

                        Console.Write("Enter password:");
                        string password = Console.ReadLine();
                        Console.WriteLine();
                        try
                        {
                            loggedInUser = userService.Login(email, password);
                            Console.WriteLine("success login!\n");
                            Console.WriteLine();

                            goto menu2;
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        goto menu1;
                        break;
                    case 4:
                        return;
                        break;
                    default:
                        Console.WriteLine("Choose is not found!\n");
                        break;
                }


            }

        menu2:
           
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create category:");
            Console.WriteLine("2. Create Medicine:");
            Console.WriteLine("3. Show all medicine:");
            Console.WriteLine("4. search medicine by id:");
            Console.WriteLine("5. search medicine by name:");
            Console.WriteLine("6. Search medicine by category:");
            Console.WriteLine("7. Delete medicine:");
            Console.WriteLine("8. Update medicine:");
            Console.WriteLine("9. show menu:");
            Console.WriteLine("10. Log out:");
           

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.Write("choose: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Category category = new Category();
                        Console.Write("Category name:");
                        category.Name = Console.ReadLine();
                        categoryService.CreateCategory(category);


                        break;
                    case "2":
                        foreach (var item in DB.categories)
                        {
                            Console.WriteLine($"{item.Id} {item.Name}");
                        }
                        Medicine medicine = new Medicine();
                        Console.Write("Medicine Name:");
                        medicine.Name = Console.ReadLine();
                        Console.Write("Medicine Price:");
                        medicine.Price = int.Parse(Console.ReadLine());
                        Console.Write("Medicine Category:");
                        medicine.CategoryId = int.Parse(Console.ReadLine());
                        medicine.CreatedDate = DateTime.Now;
                        medicineService.CreateMedicine(medicine,medicine.CategoryId);
                        break;
                    case "3":
                        foreach (var item in medicineService.GetAllMedicines())
                        {
                            Console.WriteLine($"Name:{item.Name} Price:{item.Price} Category:{item.CategoryId} CreatedDate:{item.CreatedDate}");
                        }
                        break;
                    case "4":
                        Console.Write("Medicine id:");
                        int id = int.Parse(Console.ReadLine());
                        try
                        {
                            var med = medicineService.GetMedicineById(id);
                            Console.WriteLine($"Name:{med.Name} Price:{med.Price} Category:{med.CategoryId} CreatedDate:{med.CreatedDate}");

                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "5":

                        Console.Write("Medicine name:");
                        string name = Console.ReadLine();
                        try
                        {
                            var medName = medicineService.GetMedicineByName(name);
                            Console.WriteLine($"Name:{medName.Name} Price:{medName.Price} Category:{medName.CategoryId} CreatedDate:{medName.CreatedDate}");

                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "6":
                        Console.WriteLine("Category names:");
                        for (int i = 0; i < DB.categories.Length; i++)
                        {
                            Console.WriteLine($"{DB.categories[i].Id}-{DB.categories[i].Name}");
                        }
                        Console.Write("Category id:?\n");
                        int categoryId = int.Parse(Console.ReadLine());
                        try
                        {
                            medicineService.GetMedicineByCategory(categoryId);
                         
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "7":
                        Console.Write("delete medicine id:");
                        int removeId = int.Parse(Console.ReadLine());
                        try
                        {
                            medicineService.RemoveMedicine(removeId);
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "8":
                        Console.Write("update medicine id:");
                        int medId = int.Parse(Console.ReadLine());
                        Medicine medicine2 = new Medicine();
                        Console.Write("New Name:");
                        medicine2.Name = Console.ReadLine();
                        Console.Write("New Price:");
                        medicine2.Price = int.Parse(Console.ReadLine());
                        Console.Write("New Category:");
                        medicine2.CategoryId = int.Parse(Console.ReadLine());
                        medicine2.CreatedDate = DateTime.Now;
                        try
                        {
                            medicineService.UpdateMedicine(medId, medicine2);
                        }
                        catch (NotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "9":
                        goto menu2;
                    case "10":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Choose correct command!:");
                        break;
                }
            }
        }
    }
}