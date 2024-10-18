namespace PedidosAPI.Responses
{
    public partial class ProcessarPedidosResponse
    {
        public List<PedidoResponse> Pedidos { get; set; }
    }

    public partial class PedidoResponse
    {
        public int IdPedido { get; set; }
        public Dictionary<string, List<string>> Caixas { get; set; }

    }

}
