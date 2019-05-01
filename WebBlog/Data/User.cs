using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebBlog.Data
{
	public class User : IdentityUser
	{
		[ MinLength( 3 ) ]
		[ MaxLength( 12 ) ]
		public string FirstName { get; set; }

		[ MinLength( 3 ) ]
		[ MaxLength( 12 ) ]
		public string LastName { get; set; }

		public IEnumerable< BlogEntry > BlogEntries { get; set; } = new List< BlogEntry >();
	}
}