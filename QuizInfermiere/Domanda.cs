using System;
using SQLite.Net.Attributes;

namespace QuizInfermiere
{
	public class Domanda
	{
		[PrimaryKey, AutoIncrement]
		public int IdDomanda { get; set; }
		public int IdCategoria { get; set; }
		public int NumeroDomanda { get; set; }
		public string Question { get; set; }
		public string RispostaUno { get; set; }
		public string RispostaDue { get; set; }
		public string RispostaTre { get; set; }
		public string RispostaQuattro { get; set; }
		public string RispostaEsatta { get; set; }

		public override string ToString()
		{
			return string.Format("Question={0}", Question);
		}
	}
}

