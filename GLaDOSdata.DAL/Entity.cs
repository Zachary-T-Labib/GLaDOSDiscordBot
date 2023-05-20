using System;
using System.ComponentModel.DataAnnotations;

namespace GLaDOSdata.DAL
{
	public abstract class Entity
	{
		[Key]

		public int Id { get; set; }
	}
}

