using Models.Infrastructure;
using System;
using System.Web;
using System.Web.Mvc;

namespace Models.Models
{
    [ModelBinder(typeof(PersonModelBinder))]
	public class Person
	{
        private static int id = 0;

        #region Properties
        public int PersonId
        {
            get { 
                return id; 
            }
            private set
            {
                id = value;
            }
        }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public Address HomeAddress { get; set; }
		public bool IsActive { get; set; }
		public Role Role { get; set; }
        #endregion

        public Person()
        {
            PersonId++;
        }
	}

	public enum Role
	{
		Admin,
		User,
		Guest
	}
}