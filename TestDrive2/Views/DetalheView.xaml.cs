﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {

        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 1000;
        private const int MP3_PLAYER = 500;

        public Veiculo Veiculo { get; set; }

        public string TextoFreioABS
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", FREIO_ABS);
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}", AR_CONDICIONADO);
            }
        }

        public string TextoMp3Player
        {
            get
            {
                return string.Format("Mp3 Player - R$ {0}", MP3_PLAYER);
            }
        }

        bool temFreioABS;
        public bool TemFreioAbs
        {
            get
            {
                return temFreioABS;
            }
            set
            {
                temFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        bool temAr;
        public bool TemAr
        {
            get
            {
                return temAr;
            }
            set
            {
                temAr = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        bool temMp3;
        public bool TemMp3
        {
            get
            {
                return temMp3;
            }
            set
            {
                temMp3 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal { get
            {
                return string.Format("Valor Total: R$ {0},",
                    Veiculo.Preco
                    + (TemFreioAbs ? FREIO_ABS : 0)
                    + (TemAr ? AR_CONDICIONADO : 0)
                    + (TemMp3 ? MP3_PLAYER : 0)
                    );
            }
        }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;

            this.BindingContext = this;
        }

        private void buttonProximo_Clicked(object sender, EventArgs e)
        {      
            Navigation.PushAsync(new AgentamentoView(Veiculo));
        }
    }
}