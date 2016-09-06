using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day2.HomeTask.Models
{
    public class UserViewModel
    {
        private static int id = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }

        public UserViewModel()
        {
            id++;
        }
    }
}