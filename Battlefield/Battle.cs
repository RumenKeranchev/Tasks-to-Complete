namespace Battlefield
{
	public class Battle
	{
		private static Battle instance;

		private Battle()
		{
		}

		public static Battle GetInstance()
		{
			if ( instance == null )
			{
				instance = new Battle();
			}

			return instance;
		}
	}
}