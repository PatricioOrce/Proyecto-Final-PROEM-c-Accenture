using System.ComponentModel.DataAnnotations;

namespace ProyectoProem.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Codigo es obligatorio.")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        public string Direccion { get; set; }
        public double SaldoCtaCte { get; set; }

        public Clientes()
        {

        }

        public Clientes(int id, int codigo, string nombre, string direccion)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;   
            this.Direccion = direccion;
        }
    }
}
