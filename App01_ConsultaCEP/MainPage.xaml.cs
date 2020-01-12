using App01_ConsultaCEP.Interfaces;
using App01_ConsultaCEP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultaCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly IViaCEPService _cepService;

        public MainPage(IViaCEPService cepService)
        {
            InitializeComponent();

            _cepService = cepService;

            btnBuscar.Clicked += async (sender,args) => {
                var endereco = await _cepService.BuscarEnderecoViaCEP(txtCEP.Text);
                
                lblEndereco.Text = endereco.Logradouro;
            };


            txtCEP.TextChanged += (sender, args) => {
                lblEndereco.Text = string.Empty;
            };
        }

        
    }
}
