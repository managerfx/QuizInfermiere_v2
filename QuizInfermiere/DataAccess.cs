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

			connection.CreateTable<Ana_Categorie>();
			//connection.CreateTable<Domanda>();
			//connection.CreateTable<RiepilogoRisposte>();
		}

		#region Categoria
		public void InsertCategoria(Ana_Categorie categoria)
		{
			connection.Insert(categoria);
		}

		public void InsertListCategorie(List<Ana_Categorie> lista)
		{
			foreach (var categoria in lista)
			{
				connection.Insert(categoria);
			}

		}

		public void UpdateCategoria(Ana_Categorie categoria)
		{
			connection.Update(categoria);
		}

		public void DeleteCategoria(Ana_Categorie categoria)
		{
			connection.Delete(categoria);
		}

		public Ana_Categorie GetByID(int IdCategoria)
		{
			return connection.Table<Ana_Categorie>().FirstOrDefault(f => f.IdCategoria == IdCategoria);
		}

		public List<Ana_Categorie> GetAllCategorie()
		{
			return connection.Table<Ana_Categorie>().OrderBy(c => c.IdCategoria).ToList();
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

