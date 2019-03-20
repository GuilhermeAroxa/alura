using System;
using System.IO;
using alura.Data;
using alura.Droid;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))]
namespace alura.Droid
{
    class SQLite_android : ISQLite
    {
        private const string nomeArquivoDB = "Agendamento.db3";

        public SQLiteConnection PegarConexao()
        {
            var caminhoDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path,
                nomeArquivoDB);

            return new SQLite.SQLiteConnection(caminhoDB);
        }
    }
}