namespace Battlefield.Interfaces
{
	public interface IUnit
	{
		/// <summary>
		/// Move the unit by a specified amount and check if within attack range.
		/// </summary>
		/// <returns>If within attack range returns true</returns>
		bool Move( int target );
	}
}