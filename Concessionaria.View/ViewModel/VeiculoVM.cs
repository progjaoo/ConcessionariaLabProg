using Concessionaria.Model.Models;

namespace Concessionaria.View.ViewModel
{
    public class VeiculoVM
    {
        public int Codigo { get; set; }
        public int CodigoConcessionaria { get; set; }
        public string NomeConcessionaria { get; set; }
        public string Nome { get; set;}
        public int? Ano { get; set;}
        public string Fabricante { get; set;}
        public bool Usado { get; set;}
        public decimal? Preco { get; set;}
        public string Tipo { get; set;}

        public VeiculoVM()
        {

        }

        public static VeiculoVM SelecionarVeiculo(int id)
        {
            var db = new ConcessionariaDBContext();
            var veiculo = db.Veiculo.Find(id);
            return new VeiculoVM()
            {
                Codigo = veiculo.IdVeiculo,
                CodigoConcessionaria = veiculo.ConcessionariaIdConcessionaria,
                NomeConcessionaria = db.Concessionaria.Find(veiculo.ConcessionariaIdConcessionaria).Nome,
                Nome = veiculo.Nome,
                Ano = veiculo.Ano,
                Fabricante = veiculo.Marca,
                Usado = veiculo.Usado,
                Preco = veiculo.Preco,
                Tipo = veiculo.TipoVeiculo,
            };
        }
        public static List<VeiculoVM> ListarTodosVeiculos()
        {
            var db = new ConcessionariaDBContext();
            var listaRetorno = new List<VeiculoVM>();
            var listaVeiculos = db.Veiculo.ToList();

            foreach ( var v in listaVeiculos)
            {
                var veiculo = new VeiculoVM();
                veiculo.Codigo = v.IdVeiculo;
                veiculo.CodigoConcessionaria = v.ConcessionariaIdConcessionaria;
                veiculo.NomeConcessionaria = db.Concessionaria.FirstOrDefault(x => x.IdConcessionaria == v.ConcessionariaIdConcessionaria).Nome;
                veiculo.Nome = v.Nome;
                veiculo.Ano = v.Ano;
                veiculo.Fabricante = v.Marca;
                veiculo.Usado = v.Usado;
                veiculo.Preco = v.Preco;
                veiculo.Tipo = v.TipoVeiculo;
                listaRetorno.Add(veiculo);
            }
            return listaRetorno;
        }



    }
}
