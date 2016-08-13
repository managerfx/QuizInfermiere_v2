using System;
using SQLite.Net.Attributes;

namespace QuizInfermiere
{
	public class Ana_Categorie
	{
		[PrimaryKey, AutoIncrement]
		public int IdCategoria {get; set;}
		public string Categoria { get; set; }

		public override string ToString()
		{
			return string.Format("{0}", Categoria);
		}

	}
}

