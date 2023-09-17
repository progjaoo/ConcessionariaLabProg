using Concessionaria.Model.Models;

namespace Concessionaria.View.ViewModel
{
    public class VendaVM
    {
        public int Codigo { get; set; }
        public int Codigoveiculo { get; set; }
        public string NomeVeiculo { get; set; }
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }

        public VendaVM()
        {
            
        }
        public static List<VendaVM> ListarTodasvendas()
        {
            var db = new ConcessionariaDBContext();
            var listaRetorno = new List<VendaVM>();
            var listaVendas = db.Venda.ToList();

            foreach (var v in listaVendas)
            {
                var venda = new VendaVM();
                venda.Codigo = v.IdVenda;
                venda.Codigoveiculo = v.VeiculoIdVeiculo;
                venda.NomeVeiculo = db.Veiculo.FirstOrDefault(x => x.IdVeiculo == v.VeiculoIdVeiculo).Nome;
                venda.CodigoCliente = v.ClienteIdCliente;
                venda.NomeCliente = db.Cliente.FirstOrDefault(x => x.IdCliente == v.ClienteIdCliente).Nome;
                listaRetorno.Add(venda);
            }
            return listaRetorno;
        }

    }
}
