using ControleDeMedicamentos.Dominio.ModuloPrescricao;
using ControleDeMedicamentos.Infraestrutura.Arquivos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloPrescricao;

public class RepositorioPrescricaoEmArquivo : RepositorioBaseEmArquivo<Prescricao>
{
    public RepositorioPrescricaoEmArquivo(ContextoDados contextoDados) : base(contextoDados) { }

    protected override List<Prescricao> ObterRegistros()
    {
        return contextoDados.Prescricoes;
    }
}

