﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using alura.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace alura.ViewModels
{
    public class ListagemViewModel
    {
        public ObservableCollection<Veiculo> Veiculos { get; set; }
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";

        Veiculo veiculoselecionado;

        public Veiculo VeiculoSelecionado
        {
            get
            {
                return this.veiculoselecionado;
            }
            set
            {
                this.veiculoselecionado = value;
                if (veiculoselecionado != null)
                {
                    MessagingCenter.Send(veiculoselecionado, "veiculoselecionado");
                }
            }
        }
        public async Task getveiculos()
        {
            HttpClient cliente = new HttpClient();
            var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);
            var veiculosjson = JsonConvert.DeserializeObject<VeiculosJson[]>(resultado);

            foreach (var veiculojson in veiculosjson)
            {
                this.Veiculos.Add(new Veiculo
                {
                    Nome = veiculojson.nome,
                    Preco = veiculojson.preco
                });
            }
        }

        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }
    }

    public class VeiculosJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
