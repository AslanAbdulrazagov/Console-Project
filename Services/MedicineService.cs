using MiniApp.Exceptions;
using MiniApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp.Services
{
    public class MedicineService
    {
        public void CreateMedicine(Medicine medicine, int id)
        {
            foreach (var item in DB.categories)
            {
                if (item.Id == id)
                {
                    Array.Resize(ref DB.medicines, DB.medicines.Length + 1);
                    DB.medicines[DB.medicines.Length - 1] = medicine;
                    return;

                }

            }
            throw new NotFoundException("Category id tapilmadi");

        }
       public Medicine[] GetAllMedicines()
        {
            return DB.medicines;
        }
       public Medicine GetMedicineById(int id)
        {
            foreach (var item in DB.medicines)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            throw new NotFoundException("verilen id element tapilmadi");
        }

       public Medicine GetMedicineByName(string name)
        {
            foreach (var item in DB.medicines)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            throw new NotFoundException("verilen adli element tapilmadi");
        }

        public void GetMedicineByCategory(int id)
        {
            bool k = false;
            foreach (var item in DB.medicines)
            {
                if (item.CategoryId == id)
                {

                    Console.WriteLine(item.Name);
                    k = true;
                }
            }
            if (!k)
            {
                Console.WriteLine("tapilmadi");
            }


        }

        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            for (int i = 0; i < DB.medicines.Length; i++)
            {
                if (DB.medicines[i].Id == id)
                {
                    DB.medicines[i] = updatedMedicine;
                    return;
                }
            }
            throw new NotFoundException("verilen id ile derman tapilmadi!");
        }
        public void RemoveMedicine(int id)
        {
            for (int i = 0; i < DB.medicines.Length; i++)
            {
                if (DB.medicines[i].Id == id)
                {
                    for (int j = id; j < DB.medicines.Length - 1; j++)
                    {
                        DB.medicines[j] = DB.medicines[j + 1];
                    }
                    Array.Resize(ref DB.medicines, DB.medicines.Length - 1);
                    return;
                }
            }
            throw new NotFoundException("id tapilmadi");

        }
    }
}
