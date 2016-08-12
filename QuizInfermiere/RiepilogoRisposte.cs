using System;
using SQLite.Net.Attributes;

namespace QuizInfermiere
{
	public class RiepilogoRisposte
	{
		[PrimaryKey, AutoIncrement]
		public int IdRiepilogo { get; set;}
		public int IdCategoria { get; set; }
		public int NumeroDomanda { get; set; }
		public string Question { get; set; }
		public string RispostaData { get; set; }
		public bool Esatta { get; set; }


		public override string ToString()
		{
			return string.Format("{0}", Question);
		}
	}
}

