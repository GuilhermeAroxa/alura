using System;
using SQLite;

namespace alura.Data
{
    public interface ISQLite
    {
        SQLiteConnection PegarConexao();
    }
}
