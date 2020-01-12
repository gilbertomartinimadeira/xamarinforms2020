using App01_ConsultaCEP.Interfaces;
using App01_ConsultaCEP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            btnBuscar.IsEnabled = false;

            btnBuscar.Clicked += async (sender,args) => {

                //validar o input

                if( Regex.IsMatch(txtCEP.Text, @"\d{5}[-.\s]?\d{3}"))
                {
                    var endereco = await _cepService.BuscarEnderecoViaCEP(txtCEP.Text);
                    if (endereco != null && endereco.Valid)
                        lblEndereco.Text = endereco.ToString();
                    else
                    {
                        var erros = string.Concat(endereco.Notifications.Select(s => s.Message + "\n"));
                        await DisplayAlert("Atenção", erros, "Entendi");
                    }
                }
                else
                {
                    await DisplayAlert("Atenção", "O valor digitado não corresponde a um CEP válido", "Entendi");
                    txtCEP.Text = "";
                }                
            };


            txtCEP.TextChanged += (sender, args) => {
                btnBuscar.IsEnabled = !string.IsNullOrEmpty(txtCEP.Text);

                lblEndereco.Text = string.Empty;
            };
        }

        
    }
}
