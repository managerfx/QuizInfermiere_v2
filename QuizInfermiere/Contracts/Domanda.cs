using SQLite.Net.Attributes;

namespace QuizInfermiere.Contracts
{
    [Table("DOMANDE")]
    public class Domanda
	{
		[PrimaryKey, AutoIncrement]
        [Column("ID_DOMANDA")]
        public int IdDomanda { get; set; }
        [Column("ID_CATEGORIA")]
        public int IdCategoria { get; set; }
        [Column("NUMERO_DOMANDA")]
        public int NumeroDomanda { get; set; }
        [Column("DES_DOMANDA")]
        public string Question { get; set; }
        [Column("RISPOSTA_1")]
        public string RispostaUno { get; set; }
        [Column("RISPOSTA_2")]
        public string RispostaDue { get; set; }
        [Column("RISPOSTA_3")]
        public string RispostaTre { get; set; }
        [Column("RISPOSTA_4")]
        public string RispostaQuattro { get; set; }
        [Column("RISPOSTA_CORRETTA")]
        public string RispostaEsatta { get; set; }

		public override string ToString()
		{
			return string.Format("Question={0}", Question);
		}
	}
}

