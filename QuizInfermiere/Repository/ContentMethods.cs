using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizInfermiere.Configuration;
using System.IO;

namespace QuizInfermiere.Repository
{
    public class TestPCLContent
    {
        private IContentProvider _ContentProvider;

        public IContentProvider ContentProvider
        {
            get
            {
                return _ContentProvider;
            }
            set
            {
                _ContentProvider = value;
            }
        }

        public string GetLocalDB()
        {
            //var localDb = string.Format(@"{0}\{1}", ParametriConfigurazione.NomeFolderContent, ParametriConfigurazione.NomeDBLocale);
            string localDb = Path.Combine(ParametriConfigurazione.NomeFolderContent, ParametriConfigurazione.NomeDBLocale);
            return _ContentProvider.LoadContent(localDb);
        }

        public string GetCompletePathDB()
        {
            //var localDb = string.Format(@"{0}\{1}", ParametriConfigurazione.NomeFolderContent, ParametriConfigurazione.NomeDBLocale);
            string contentFile = Path.Combine(ParametriConfigurazione.NomeFolderContent, ParametriConfigurazione.NomeDBLocale);
            var relativePath =  _ContentProvider.CompletePath(contentFile);

            string localXMLUrl = Path.Combine(Path.GetDirectoryName("QuizInfermiere"), relativePath);
            return new Uri(localXMLUrl).LocalPath;

        }


        
    }
}
