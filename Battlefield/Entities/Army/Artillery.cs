using System;
using Battlefield.Constants;

namespace Battlefield.Entities.Army
{
	public class Artillery : ArmyUnit
	{
		public Artillery() : base(
			ArtilleryConstants.minHealth, ArtilleryConstants.maxHealth,
			ArtilleryConstants.minDefense, ArtilleryConstants.maxDefense,
			ArtilleryConstants.minAttackPower, ArtilleryConstants.maxAttackPower,
			ArtilleryConstants.minAttackRange, ArtilleryConstants.maxAttackRange,
			ArtilleryConstants.Cost)
		{
		}

		public override void SpecialAbility()
		{
			throw new NotImplementedException();
		}
	}
}