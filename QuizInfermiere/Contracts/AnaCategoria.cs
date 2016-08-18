using SQLite.Net.Attributes;

namespace QuizInfermiere.Contracts
{
    [Table("ANA_CATEGORIA")]
    public class AnaCategoria
    {
        [PrimaryKey, AutoIncrement]
        [Column("ID_CATEGORIA")]
        public int IdCategoria { get; set; }
        [Column("DES_CATEGORIA")]
        public string DesCategoria { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", DesCategoria);
        }

    }
}

