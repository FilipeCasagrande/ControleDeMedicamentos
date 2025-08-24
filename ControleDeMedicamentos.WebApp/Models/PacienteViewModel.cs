using ControleDeMedicamentos.Dominio.ModucloPaciente;
using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentos.WebApp.Models;


public class CadastrarPacienteViewModel
{
    [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo 'Nome' deve conter entre 2 e 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo 'Telefone' é obrigatório.")]
    [RegularExpression(
        @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$",
        ErrorMessage = "O campo 'Telefone' deve seguir o padrão (DDD) 0000-0000 ou (DDD) 00000-0000."
    )]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo 'CPF' é obrigatório.")]
    [RegularExpression(
        @"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
        ErrorMessage = "O campo 'CPF' deve seguir o formato 000.000.000-00."
    )]

    public string Cpf { get; set; }
    [Required(ErrorMessage = "O campo 'Cartão' é obrigatório.")]
    [RegularExpression(@"^\d{15}$",
        ErrorMessage = "O campo 'Cartão' deve conter 15 dígitos."
    )]
    public string Cartao {get;set; } 

    public CadastrarPacienteViewModel() { }

    public CadastrarPacienteViewModel(string nome, string telefone, string cpf, string cartao) : this()
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
        Cartao = cartao;
    }
}

public class EditarPacienteViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo 'Nome' deve conter entre 2 e 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo 'Telefone' é obrigatório.")]
    [RegularExpression(
        @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$",
        ErrorMessage = "O campo 'Telefone' deve seguir o padrão (DDD) 0000-0000 ou (DDD) 00000-0000."
    )]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo 'CPF' é obrigatório.")]
    [RegularExpression(
        @"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
        ErrorMessage = "O campo 'CPF' deve seguir o formato 000.000.000-00."
    )]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O campo 'Cartão' é obrigatório.")]
    [RegularExpression(@"^\d{15}$",
        ErrorMessage = "O campo 'Cartão' deve conter 15 dígitos."
    )]
    public string Cartao { get; set; }

    public EditarPacienteViewModel() { }

    public EditarPacienteViewModel(Guid id, string nome, string telefone, string cpf, string cartao) : this()
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
        Cartao = cartao;
    }
}

public class ExcluirPacienteViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public ExcluirPacienteViewModel() { }

    public ExcluirPacienteViewModel(Guid id, string nome) : this()
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarPacientesViewModel
{
    public List<DetalhesPacienteViewModel> Registros { get; }

    public VisualizarPacientesViewModel(List<Paciente> Pacientes)
    {
        Registros = [];

        foreach (var p in Pacientes)
        {
            var detalhesVM = new DetalhesPacienteViewModel(
                p.Id,
                p.Nome,
                p.Telefone,
                p.Cpf,
                p.Cartao
            );

            Registros.Add(detalhesVM);
        }
    }
}
public class DetalhesPacienteViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    public string Cartao { get; set; }

    public DetalhesPacienteViewModel(Guid id, string nome, string telefone, string cpf, string cartao)
    {
        Id = id;
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
        Cartao = cartao;
    }
}

