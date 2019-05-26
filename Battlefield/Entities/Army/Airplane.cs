using System;
using Battlefield.Constants;

namespace Battlefield.Entities.Army
{
	public class Airplane : ArmyUnit
	{
		public Airplane() : base(
			AirplaneConstants.minHealth, AirplaneConstants.maxHealth, 
			AirplaneConstants.minDefense, AirplaneConstants.maxDefense,
			AirplaneConstants.minAttackPower, AirplaneConstants.maxAttackPower,
			AirplaneConstants.minAttackRange, AirplaneConstants.maxAttackRange,
			AirplaneConstants.Cost)
		{
		}

		public override void SpecialAbility()
		{
			throw new NotImplementedException();
		}
	}
}