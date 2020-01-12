using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace App01_ConsultaCEP.Model
{
    public class Endereco : Notifiable
    {
        public string Cep { get; private set; }
        public string Logradouro { get;  private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Localidade { get; private set; }
        public string Uf { get; private set; }
        public string Unidade { get; private set; }
        public string IBGE { get; private set; }
        public string GIA { get; private set; }     

        public Endereco(string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string unidade, string iBGE, string gIA)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Unidade = unidade;
            IBGE = iBGE;
            GIA = gIA;

            Validate();
        }

        public override string ToString()
        {
            return $@"
                   RUA: {Logradouro} - {Unidade}               
                   BAIRRO: {Bairro} 
                   CIDADE: {Localidade} 
                   ESTADO: {Uf}
                   CEP: {Cep}";
        }

        public void Validate()
        {
            AddNotifications(new Contract().Requires()
                .IsNotNullOrEmpty(Cep,nameof(Cep), "O CEP não pode ser vazio")
                .IsNotNullOrEmpty(Logradouro, nameof(Logradouro), "O Logradouro não pode ser vazio"));
        }

    }
}
