using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPlenoCliente.Domain.Entidades
{
    public class Endereco
    {
        public int ID { get; private set; }

        [Description("cliente_id")]
        public int ClienteID { get; set; }
        public string CEP { get; private set; }
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
    }
}
