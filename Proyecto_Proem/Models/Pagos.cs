namespace ProyectoProem.Models
{
    public class Pagos
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public double Importe { get; set; }
        public Clientes Cliente { get; set; }

        public Pagos()
        {

        }

        public Pagos(DateTime fecha, int clientesid, double importe, Clientes cliente)
        {
            this.Fecha = fecha;
            this.ClienteId = clientesid;
            this.Importe = importe;
            this.Cliente = cliente;
        }
    }
}
