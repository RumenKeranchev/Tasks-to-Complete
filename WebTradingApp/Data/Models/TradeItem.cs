using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTradingApp.Data.Models
{
	public class TradeItem
	{
		public int Id { get; set; }

		[ Required ]
		public string Title { get; set; }

		[ Required ]
		public string Category { get; set; }

		[ DataType( DataType.Currency ) ]
		[ Range( 0, Double.MaxValue ) ]
		public double StartPrice { get; set; }

		//TODO: Validate that MinBetPrice > StartPrice + MinBetPrice
		[ DataType( DataType.Currency ) ]
		[ Range( 0, Double.MaxValue ) ]
		public double MinBetPrice { get; set; }

		public DateTime StartDate { get; set; } = DateTime.Now;

		public DateTime EndDate { get; set; } = DateTime.Now;

		[ Required ]
		public string Specifics { get; set; }

		[ Required ]
		public string Information { get; set; }

		public IEnumerable< byte[] > Pictures { get; set; } = new List< byte[] >();

		//TODO: If set to Bid, wait for EndDate to select winner
		//TODO: If set to Buy, the first who bids is the winner
		[Required ]
		public Options Options { get; set; }
	}
}