using Battlefield.Entities;

namespace Battlefield.Interfaces
{
	public interface IAttackable
	{
		/// <summary>
		/// <para>Perform an attack on the selected target. The damage is equal to the unit's attack subtracting the targets defense
		/// and subtracting the range differance (in persents) from the units attack power if higher than 0, or add it if less than 0
		///</para>
		/// <para>
		/// Example:
		/// 126 - 69 - (126 * 0.31) =  18</para>
		/// <para>unit's attack  - target's defense -/+ (unit's attack * +/- (double)(unit's range - target's range))  = Math.Round(17.94)</para>
		/// </summary>
		/// <param name="unit"></param>
		/// <returns>Returns the remaining health of the attacked unit</returns>
		int Attack( IUnit unit );
	}
}