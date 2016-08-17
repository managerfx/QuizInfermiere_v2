using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;
using System.Net;



namespace QuizInfermiere
{
	public class DataAccess : IDisposable
	{
		private SQLiteConnection connection;

		public DataAccess()
		{
			//http://www.managerfx.altervista.org/Ftp/InfermieriDataBase.db

			var updateDatabaseCore = DependencyService.Get<IUpdateDatabase>();
			var config = DependencyService.Get<IConfig>();
			updateDatabaseCore.UpdateData();

			connection = new SQLiteConnection(config.Piattaforma, Path.Combine(config.PersonalFolder, "InfermieriDataBase_.db"));


			
			connection.CreateTable<ANA_CATEGORIA>();
			//connection.CreateTable<Domanda>();
			//connection.CreateTable<RiepilogoRisposte>();
		}

		#region Categoria
		public void InsertCategoria(ANA_CATEGORIA categoria)
		{
			connection.Insert(categoria);
		}

		public void InsertListCategorie(List<ANA_CATEGORIA> lista)
		{
			foreach (var categoria in lista)
			{
				connection.Insert(categoria);
			}

		}

		public void UpdateCategoria(ANA_CATEGORIA categoria)
		{
			connection.Update(categoria);
		}

		public void DeleteCategoria(ANA_CATEGORIA categoria)
		{
			connection.Delete(categoria);
		}

		public ANA_CATEGORIA GetByID(int IdCategoria)
		{
			return connection.Table<ANA_CATEGORIA>().FirstOrDefault(f => f.ID_CATEGORIA == IdCategoria);
		}

		public List<ANA_CATEGORIA> GetAllCategorie()
		{
			

			return connection.Table<ANA_CATEGORIA>().OrderBy(c => c.ID_CATEGORIA).ToList();

		}

		#endregion

		#region Domanda

		public void InsertDomanda(Domanda domanda)
		{
			connection.Insert(domanda);
		}

		public void InsertListDomande(List<Domanda> lista)
		{
			foreach (var domanda in lista)
			{
				connection.Insert(domanda);
			}

		}

		public void UpdateDomanda(Domanda domanda)
		{
			connection.Update(domanda);
		}

		public void DeleteDomanda(Domanda domanda)
		{
			connection.Delete(domanda);
		}

		public Domanda GetByIDCategoriaDomanda(int IdCategoria, int nDomanda)
		{
			return connection.Table<Domanda>().FirstOrDefault(f => f.IdCategoria == IdCategoria&&f.NumeroDomanda==nDomanda);
		}

		public List<Domanda> GetByIdCategoria(int idCategoria)
		{
			return connection.Table<Domanda>().Where(f => f.IdCategoria == idCategoria).ToList();
		}

		public List<Domanda> GetAllDomanda()
		{
			return connection.Table<Domanda>().OrderBy(c => c.IdDomanda).ToList();
		}

		public int GetMaxDomande(int idCategoria)
		{
			return connection.Table<Domanda>().Where(f => f.IdCategoria == idCategoria).Count();
		}

		#endregion

		#region RiepilogoRisposte

		public RiepilogoRisposte GetUltimaDomanda()
		{
			return connection.Table<RiepilogoRisposte>().OrderByDescending(c => c.IdRiepilogo).FirstOrDefault();
		}


		public void InsertRisposta(RiepilogoRisposte risposta)
		{
			connection.Insert(risposta);
		}

		public void UpdateRisposta(RiepilogoRisposte risposta)
		{
			connection.Update(risposta);
		}

		public List<RiepilogoRisposte> GetRiepilogo()
		{
			return connection.Table<RiepilogoRisposte>().OrderBy(c => c.IdRiepilogo).ToList();
		}

		public void DeleteRisposte()
		{
			connection.DeleteAll<RiepilogoRisposte>();
		}



		#endregion



		public void Dispose()
		{
			connection.Dispose();
		}
	}
}

