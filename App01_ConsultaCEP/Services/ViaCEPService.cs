﻿using App01_ConsultaCEP.Interfaces;
using App01_ConsultaCEP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App01_ConsultaCEP.Services
{
    public class ViaCEPService : IViaCEPService
    {
        private static readonly string _enderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public Task<Endereco> BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoURL = string.Format(_enderecoURL, cep);            

            var webClient = new WebClient();

            string conteudo;

            try
            {
                conteudo = webClient.DownloadString(new Uri(novoEnderecoURL));
                
                return Task.FromResult(JsonConvert.DeserializeObject<Endereco>(conteudo));
            }
            catch
            {
                return Task.FromResult(new Endereco("","","","","","","","",""));
            }                                
        }    

        
    }
}
