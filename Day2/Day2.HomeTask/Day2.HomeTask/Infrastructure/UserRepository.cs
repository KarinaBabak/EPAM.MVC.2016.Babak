using Day2.HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Day2.HomeTask.Infrastructure
{
    public static class UserRepository
    {
        public static List<UserViewModel> Users = new List<UserViewModel>();

        public static void Add(UserViewModel user)
        {
            Users.Add(user);
        }

        public static async Task AddAsync(UserViewModel user)
        {
            await Task.Delay(2000);
            Add(user);
        }

        public static List<UserViewModel> GetUsers()
        {
            Thread.Sleep(2000);
            return Users;
        }

        public static void Clear()
        {
            Users.Clear();
        }
    }
}