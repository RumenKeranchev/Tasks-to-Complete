using System;
using Battlefield.Constants;
using Battlefield.Interfaces;

namespace Battlefield.Entities.Army
{
	public class Artilery : ArmyUnit
	{
		public Artilery() : base(
			ArtileryContstants.minHealth, ArtileryContstants.maxHealth,
			ArtileryContstants.minDefense, ArtileryContstants.maxDefense,
			ArtileryContstants.minAttackPower, ArtileryContstants.maxAttackPower,
			ArtileryContstants.minAttackRange, ArtileryContstants.maxAttackRange )
		{
		}
	}
}