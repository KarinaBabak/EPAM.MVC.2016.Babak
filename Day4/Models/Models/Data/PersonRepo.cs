using Models.Models;

namespace Models.Data
{
	public class PersonRepo : IPersonRepo
	{
		private readonly Person[] _personRepo;

		public PersonRepo()
		{
			_personRepo = new[]
			{
				new Person {FirstName = "Guybrush", LastName = "Threepwood"},
				new Person {FirstName = "Arthas", LastName = "Menethil"},
				new Person {FirstName = "Illidan", LastName = "Stormrage"},
				new Person {FirstName = "Falstad", LastName = "Wildhammer",},
				new Person {FirstName = "Garrosh", LastName = "Hellscream",},
				new Person {FirstName = "Jaina", LastName = "Proudmoore", },
			};
		}

		public Person[] GetAll()
		{
			return _personRepo;
		}
	}
}