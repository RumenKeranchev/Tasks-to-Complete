using System;
using Battlefield.Constants;
using Battlefield.Interfaces;

namespace Battlefield.Entities.Army
{
	public class Artillery : ArmyUnit
	{
		public Artillery() : base(
			ArtilleryContstants.minHealth, ArtilleryContstants.maxHealth,
			ArtilleryContstants.minDefense, ArtilleryContstants.maxDefense,
			ArtilleryContstants.minAttackPower, ArtilleryContstants.maxAttackPower,
			ArtilleryContstants.minAttackRange, ArtilleryContstants.maxAttackRange )
		{
		}
	}
}