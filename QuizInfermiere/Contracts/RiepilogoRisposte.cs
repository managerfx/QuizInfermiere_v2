using SQLite.Net.Attributes;

namespace QuizInfermiere.Contracts
{
    [Table("RIEPILOGO_RISPOSTE")]
    public class RiepilogoRisposte
	{
		[PrimaryKey, AutoIncrement]
        [Column("ID_RIEPILOGO")]
        public int IdRiepilogo { get; set;}
        [Column("ID_CATEGORIA")]
        public int IdCategoria { get; set; }
        [Column("NUMERO_DOMANDA")]
        public int NumeroDomanda { get; set; }
        [Column("DOMANDA")]
        public string Question { get; set; }
        [Column("RISPOSTA_DATA")]
        public string RispostaData { get; set; }
        [Column("IS_ESATTA")]
        public bool Esatta { get; set; }


		public override string ToString()
		{
			return string.Format("{0}", Question);
		}
	}
}

