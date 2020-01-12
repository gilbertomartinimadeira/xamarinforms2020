using App01_ConsultaCEP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App01_ConsultaCEP.Interfaces
{
    public interface IViaCEPService
    {
        Task<Endereco> BuscarEnderecoViaCEP(string cep);
    }
}
