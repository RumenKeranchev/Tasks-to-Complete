using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebTradingApp.Data.Models
{
	public class User : IdentityUser
	{
		public IEnumerable< TradeItem > Favourites { get; set; } = new List< TradeItem >();
	}
}