using System;
using SQLite.Net.Attributes;

namespace QuizInfermiere
{
	public class ANA_CATEGORIA
	{
		[PrimaryKey, AutoIncrement]
		public int ID_CATEGORIA {get; set;}
		public string DES_CATEGORIA { get; set; }

		public override string ToString()
		{
			return string.Format("{0}", DES_CATEGORIA);
		}

	}
}

