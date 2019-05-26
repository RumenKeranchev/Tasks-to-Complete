using Battlefield.Constants;

namespace Battlefield.Entities.Army
{
	public class Infantry : ArmyUnit
	{
		public Infantry() : base(
			InfantryConstants.minHealth, InfantryConstants.maxHealth,
			InfantryConstants.minDefense, InfantryConstants.maxDefense,
			InfantryConstants.minAttackPower, InfantryConstants.maxAttackPower,
			InfantryConstants.minAttackRange, InfantryConstants.maxAttackRange,
			InfantryConstants.Cost )
		{
		}

		public override void SpecialAbility()
		{
			throw new System.NotImplementedException();
		}
	}
}