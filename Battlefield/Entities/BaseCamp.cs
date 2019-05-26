using System.Collections.Generic;
using System.Linq;
using Battlefield.Constants;
using Battlefield.Entities.Army;
using Battlefield.Interfaces;

namespace Battlefield.Entities
{
	public class BaseCamp : IDefendable
	{
		#region Variables

		private int health;

		private readonly List< ArmyUnit > army;

		#endregion

		#region Constructors

		public BaseCamp()
		{
			this.Health = BaseCampConstants.Health;
			this.army = new List< ArmyUnit >();
		}

		#endregion

		#region Getters and Setters

		public int Health
		{
			get => this.health;
			private set
			{
				if ( value > 0 )
				{
					this.health = value;
				}
			}
		}

		public IEnumerable< ArmyUnit > Army
		{
			get
			{
				var myArmy = this.army;

				return myArmy;
			}
		}

		#endregion

		#region Methods

		public void AddToArmy( ArmyUnit unit )
		{
			if ( unit != null )
			{
				this.army.Add( unit );
			}
		}

		public void RemoveFromArmy( int id )
		{
			if ( id > 0 )
			{
				var unit = this.army.FirstOrDefault( u => u.Id == id );

				if ( unit != null && !unit.IsAlive() )
				{
					this.army.Remove( unit );
				}
			}
		}

		public int TakeDamage( int damage )
		{
			if ( this.CanTakeDamage() )
			{
				return this.Health -= damage;
			}

			return this.Health;
		}

		/// <summary>
		/// Returns true if the remaining army count is less then 35%
		/// </summary>
		public bool CanTakeDamage()
		{
			return ( double ) this.Army.Count() / 100 < 0.35;
		}

		#endregion
	}
}