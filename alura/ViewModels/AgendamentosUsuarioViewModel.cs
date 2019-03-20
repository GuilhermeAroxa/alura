using System;
using System.Collections.ObjectModel;
using System.Linq;
using alura.Data;
using alura.Models;
using SQLite;
using Xamarin.Forms;

namespace alura.ViewModels
{
    public class AgendamentosUsuarioViewModel : BaseViewModel
    {
        ObservableCollection<Agendamento> lista = new ObservableCollection<Agendamento>();
        public ObservableCollection<Agendamento> Lista
        {
            get
            {
                return lista;
            }
            private set
            {
                lista = value;
                OnPropertyChanged();
            }
        }

        public AgendamentosUsuarioViewModel()
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgentamentoDAO dao = new AgentamentoDAO(conexao);

                var listaordenada = dao.Lista.OrderBy(l => l.DataAgendamento).ThenBy(l => l.HoraAgendamento);
                foreach (var itemDB in listaordenada)
                {
                    Lista.Add(itemDB);
                }
            }
        }
    }
}
