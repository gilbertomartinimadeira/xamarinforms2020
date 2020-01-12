using App01_ConsultaCEP.Interfaces;
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
            
            Endereco end;
            var wc = new WebClient();


            string conteudo = wc.DownloadString(new Uri(novoEnderecoURL));
           
            end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            return Task.FromResult(end);
        }    

        
    }
}
