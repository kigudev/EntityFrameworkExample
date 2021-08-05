namespace MyPetStore.Entities
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        // llaves foraneas
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        // propiedades de navegación
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}