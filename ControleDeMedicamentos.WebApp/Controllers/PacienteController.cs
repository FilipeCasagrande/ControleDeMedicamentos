using ControleDeMedicamentos.Dominio.ModucloPaciente;
using ControleDeMedicamentos.Infraestrutura.Arquivos.ModuloPaciente;
using ControleDeMedicamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.WebApp.Controllers;

public class PacienteController : Controller
{
    private readonly RepositorioPacienteEmArquivo repositorioPaciente;

    public PacienteController(RepositorioPacienteEmArquivo repositorioPaciente)
    {
        this.repositorioPaciente = repositorioPaciente;
    }

    public IActionResult Index()
    {
        var paciente = repositorioPaciente.SelecionarRegistros();

        var visualizarVm = new VisualizarPacientesViewModel(paciente);
        return View(visualizarVm);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarPacienteViewModel();
        return View(cadastrarVM);
    }
    [HttpPost]
    public IActionResult Cadastrar(CadastrarPacienteViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        var entidade = new Paciente(cadastrarVm.Nome, cadastrarVm.Telefone, cadastrarVm.Cpf, cadastrarVm.Cartao);

        repositorioPaciente.CadastrarRegistro(entidade);

        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var registro = repositorioPaciente.SelecionarRegistroPorId(id);

        var editarVm = new EditarPacienteViewModel(
            registro.Id,
            registro.Nome,
            registro.Telefone,
            registro.Cpf,
            registro.Cartao);
        return View(editarVm);
    }
    [HttpPost]
    public IActionResult Editar(EditarPacienteViewModel editarVM)
    {
        if (!ModelState.IsValid)
            return View(editarVM);

        var entidade = new Paciente(
            editarVM.Nome,
            editarVM.Telefone,
            editarVM.Cpf,
            editarVM.Cartao);

        repositorioPaciente.EditarRegistro(entidade.Id, entidade);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var registro = repositorioPaciente.SelecionarRegistroPorId(id);

        
        var excluirVm = new ExcluirPacienteViewModel(
            registro.Id,
            registro.Nome
            );
        return View(excluirVm);
    }
    [HttpPost]
    public IActionResult Excluir(ExcluirPacienteViewModel excluirVm)
    {
        repositorioPaciente.ExcluirRegistro(excluirVm.Id);

        return RedirectToAction(nameof(Index));


    }

}
