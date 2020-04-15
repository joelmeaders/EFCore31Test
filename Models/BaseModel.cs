using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore31Test2.Models
{
	public abstract class BaseModel
	{
		[Key]
		public Guid Id { get; set; }
	}
}
