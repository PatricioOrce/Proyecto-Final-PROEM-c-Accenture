namespace Proyecto_Proem.Models
{
    public class Items
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }


        public Items()
        {

        }

        public Items(int codigo, string descripcion, int cantidad, double precio)
        {
            this.Codigo = codigo;
            this.Descripcion = descripcion; 
            this.Cantidad = cantidad;
            this.Precio = precio;

        }
    }
}
