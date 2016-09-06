using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Day2.HomeTask.Models
{
    public static class UserRepository
    {
        public static List<UserViewModel> Users = new List<UserViewModel>();             
       
        public static void Add()
        {
            Users.Add(new UserViewModel()
            {
                FirstName = "Loly",
                LastName = "Pop"
            });
        }

        public static async Task AddAsync()
        {
            await Task.Delay(2000);            
            Add();
        }

        public static List<UserViewModel> GetUsers()
        {
            Thread.Sleep(2000);
            return Users;
        }
    }
}