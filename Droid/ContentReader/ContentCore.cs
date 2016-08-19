using System;
using QuizInfermiere.Repository;
using System.Reflection;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuizInfermiere.Droid.ContentReader.ContentProviderImplementation))]

namespace QuizInfermiere.Droid.ContentReader
{
    class ContentProviderImplementation : IContentProvider
    {
        private static Assembly _CurrentAssembly;

        private Assembly CurrentAssembly
        {
            get
            {
                if (_CurrentAssembly == null)
                {
                    _CurrentAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                }

                return _CurrentAssembly;
            }
        }

        public string LoadContent(string relativePath)
        {
            string localDBUrl = Path.Combine(Path.GetDirectoryName(CurrentAssembly.GetName().CodeBase), relativePath);
            var uri = new Uri(FixURI(localDBUrl)).LocalPath;
            return File.ReadAllText(uri);
        }

        public string CompletePath(string relativePath)
        {
            string localDBUrl = Path.Combine(Path.GetDirectoryName(CurrentAssembly.GetName().CodeBase), relativePath);
            var uri = new Uri(FixURI(localDBUrl)).LocalPath;
            return uri;
        }

        private string FixURI(string url)
        {
            if (url.StartsWith("file:/s"))
                url = url.Replace("file:/s", "file://s");

            return url;
        }

    }
}