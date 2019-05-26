using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Battlefield.Constants;
using Battlefield.Entities.Army;
using Battlefield.Interfaces;

namespace Battlefield.Entities
{
	public class BaseCamp
	{
		private int health;

		private bool takesDamage;

		private readonly List< ArmyUnit > army;

		public BaseCamp()
		{
			this.Health = BaseCampConstants.Health;
			this.army = new List< ArmyUnit >();
		}

		public int Health { get; private set; }

		/// <summary>
		/// Returns true if the remaining army count is less then 40%
		/// </summary>
		public bool IsDamageable => this.TakesDamage();

		public IEnumerable< ArmyUnit > Army
		{
			get
			{
				var myArmy = this.army;

				return myArmy;
			}
		}

		public void AddToArmy( ArmyUnit unit )
		{
			if ( unit != null )
			{
				this.army.Add( unit );
			}
		}

		private bool TakesDamage()
		{
			this.takesDamage = ( double ) this.Army.Count() / 100 < 0.4;

			return this.takesDamage;
		}
	}
}