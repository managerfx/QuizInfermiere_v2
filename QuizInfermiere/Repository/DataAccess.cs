using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;
using QuizInfermiere.Configuration;
using QuizInfermiere.UpdateData;
using QuizInfermiere.Contracts;

namespace QuizInfermiere.Repository
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var updateDatabaseCore = DependencyService.Get<IUpdateDatabase>();
            //var contentAccess = DependencyService.Get<IContentProvider>();
            //var logger = DependencyService.Get<ILogger>();
            var config = DependencyService.Get<IConfig>();
            var dbAggiornato = updateDatabaseCore.UpdateData(ParametriConfigurazione.UrlDB, ParametriConfigurazione.NomeDB, config.PersonalFolder);


          //  ContentProviderImplementation cpi = new ContentProviderImplementation();

            TestPCLContent tpc = new TestPCLContent();
//            tpc.ContentProvider = contentAccess; //injection

            string content = tpc.GetCompletePathDB(); //loading



            if (dbAggiornato)
                connection = new SQLiteConnection(config.Piattaforma, Path.Combine(config.PersonalFolder, ParametriConfigurazione.NomeDB));
            else
            {
                connection = new SQLiteConnection(config.Piattaforma, content);
            }
            //logger.LogInfo("DB ok");
        }

        #region Categoria
        public void InsertCategoria(AnaCategoria categoria)
        {
            connection.Insert(categoria);
        }

        public void InsertListCategorie(List<AnaCategoria> lista)
        {
            foreach (var categoria in lista)
            {
                connection.Insert(categoria);
            }

        }

        public void UpdateCategoria(AnaCategoria categoria)
        {
            connection.Update(categoria);
        }

        public void DeleteCategoria(AnaCategoria categoria)
        {
            connection.Delete(categoria);
        }

        public AnaCategoria GetByID(int IdCategoria)
        {
            return connection.Table<AnaCategoria>().FirstOrDefault(f => f.IdCategoria == IdCategoria);
        }

        public List<AnaCategoria> AnaCategoria_GetAllCategorie()
        {
            return connection.Query<AnaCategoria>("SELECT * FROM ANA_CATEGORIA");
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
            return connection.Table<Domanda>().FirstOrDefault(f => f.IdCategoria == IdCategoria && f.NumeroDomanda == nDomanda);
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

