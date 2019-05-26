using Battlefield.Constants;

namespace Battlefield.Entities.Army
{
	public class Tank : ArmyUnit
	{
		public Tank() : base(
			TankConstants.minHealth, TankConstants.maxHealth,
			TankConstants.minDefense, TankConstants.maxDefense,
			TankConstants.minAttackPower, TankConstants.maxAttackPower,
			TankConstants.minAttackRange, TankConstants.maxAttackRange,
			TankConstants.Cost )
		{
		}

		public override void SpecialAbility()
		{
			throw new System.NotImplementedException();
		}
	}
}