using ControleDeMedicamentos.Dominio.Compartilhado;
using System.Text.RegularExpressions;


namespace ControleDeMedicamentos.Dominio.ModuloFornecedor
{
    public class Fornecedor : EntidadeBase<Fornecedor>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }

        protected Fornecedor() { }

        public Fornecedor(string nome, string telefone, string cnpj) : this()
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Telefone = telefone;
            Cnpj = cnpj;
        }

        public override void AtualizarRegistro(Fornecedor registroAtualizado)
        {
            Nome = registroAtualizado.Nome;
            Telefone = registroAtualizado.Telefone;
            Cnpj = registroAtualizado.Cnpj;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O campo 'Nome' é obrigatório.\n";

            else if (Nome.Length < 2 || Nome.Length > 100)
                erros += "O campo 'Nome' deve conter entre 2 e 100 caracteres.\n";

            if (string.IsNullOrWhiteSpace(Telefone))
                erros += "O campo 'Telefone' é obrigatório.\n";

            else if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$"))
                erros += "O campo 'Telefone' deve seguir o padrão (DDD) 0000-0000 ou (DDD) 00000-0000.\n";

            if (string.IsNullOrWhiteSpace(Cnpj))
                erros += "O campo 'CNPJ' é obrigatório.\n";

            else if (!Regex.IsMatch(Cnpj, @"/^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/"))
                erros += "O campo CNPJ deve seguir um formato válido";

            return erros;
        }
    }
}
