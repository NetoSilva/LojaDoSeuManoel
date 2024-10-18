namespace LojaDoSeuManoel.Application.Results
{
    public partial class PedidosAppServiceProcessResult
    {
        public int PedidoId { get; set; }

        public Dictionary<string, List<string>> CaixasDictionary { get; set; }

        public string Observação { get; set; }

    }
}
