namespace Entities
{
	public class Phone
	{
		public string Number { get; set; }

		public PhoneType Type { get; set; }
	}

	public enum PhoneType
	{
		Home = 0,
		Work = 1
	}
}
