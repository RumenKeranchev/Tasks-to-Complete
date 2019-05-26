using System;
using Battlefield.Constants;

namespace Battlefield.Entities.Army
{
	public class Artillery : ArmyUnit
	{
		public Artillery() : base(
			ArtilleryContstants.minHealth, ArtilleryContstants.maxHealth,
			ArtilleryContstants.minDefense, ArtilleryContstants.maxDefense,
			ArtilleryContstants.minAttackPower, ArtilleryContstants.maxAttackPower,
			ArtilleryContstants.minAttackRange, ArtilleryContstants.maxAttackRange,
			ArtilleryContstants.Cost)
		{
		}

		public override void SpecialAbility()
		{
			throw new NotImplementedException();
		}
	}
}