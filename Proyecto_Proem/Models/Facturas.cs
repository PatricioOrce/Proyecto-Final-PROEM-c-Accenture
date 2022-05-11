using Proyecto_Proem.Models;

namespace ProyectoProem.Models
{
    public class Facturas
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public List<Items> Items { get; set; }
        public Clientes Cliente { get; set; }


        public Facturas()
        {

        }

        public Facturas(int id, int clienteid, int numero, DateTime fecha, List<Items> items)
        {
            this.Id = id;    
            this.ClienteId = clienteid;
            this.Numero = numero;
            this.Fecha = fecha;
            this.Items = items;
        }
    }
}
