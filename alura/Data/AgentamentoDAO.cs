using System;
using System.Collections.Generic;
using alura.Models;
using SQLite;

namespace alura.Data
{
    public class AgentamentoDAO
    {
        private readonly SQLiteConnection conexao;
        public AgentamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            this.conexao.CreateTable<Agendamento>();
        }

        private List<Agendamento> lista;
        public List<Agendamento> Lista
        {
            get
            {
                return conexao.Table<Agendamento>().ToList();
            }
            private set
            {
                lista = value;
            }
        }

        public void Salvar(Agendamento agendamento)
        {
            this.conexao.Insert(agendamento);
        }
    }
}
