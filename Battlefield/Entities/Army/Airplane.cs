using System;
using Battlefield.Constants;
using Battlefield.Interfaces;

namespace Battlefield.Entities.Army
{
	public class Airplane : ArmyUnit
	{
		public Airplane() : base(
			AirplaneConstants.minHealth, AirplaneConstants.maxHealth, 
			AirplaneConstants.minDefense, AirplaneConstants.maxDefense,
			AirplaneConstants.mintAtackPower, AirplaneConstants.maxAttackPower,
			AirplaneConstants.minAttackRange, AirplaneConstants.maxAttackRange)
		{
		}
	}
}