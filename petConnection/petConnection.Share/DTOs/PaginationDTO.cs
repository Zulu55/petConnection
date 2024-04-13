﻿using System;
namespace petConnection.Share.DTOs
{
	public class PaginationDTO
	{
		public int Id { get; set; }
		public int Page { get; set; } = 1;
		public int RecordsNumber { get; set; } = 10;
	}
}

