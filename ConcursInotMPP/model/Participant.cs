namespace ConcursInotMPP.model
{
	public class Participant : IHasId<int>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public int Age { get; set; }

		public Participant(){}
		public Participant(string name, string email, int age)
		{
			Name = name;
			Email = email;
			Age = age;
		}

		
	}
}
