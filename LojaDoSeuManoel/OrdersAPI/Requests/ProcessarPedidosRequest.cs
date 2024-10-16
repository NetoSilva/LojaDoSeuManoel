using System.Text.Json.Serialization;

namespace PedidosAPI.Requests
{
    public partial class ProcessarPedidosRequest
    {
        [JsonPropertyName("pedidos")]
        public PedidoDTO[]? PedidosDTO { get; set; }
    }

    public partial class PedidoDTO
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }

        [JsonPropertyName("produtos")]
        public ProdutoDTO[]? ProdutosDTO { get; set; }
    }

    public partial class ProdutoDTO
    {
        [JsonPropertyName("produto_id")]
        public string? ProdutoId { get; set; }

        [JsonPropertyName("dimensoes")]
        public DimensoesDTO? DimensaoDTO { get; set; }
    }

    public partial class DimensoesDTO
    {
        [JsonPropertyName("altura")]
        public double Altura { get; set; }

        [JsonPropertyName("largura")]
        public double Largura { get; set; }

        [JsonPropertyName("comprimento")]
        public double Comprimento { get; set; }
    }
}
