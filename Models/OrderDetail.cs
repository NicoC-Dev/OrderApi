namespace OrdersApi.Models;

public class OrderDetail
{
    public int Id { get; set; }
    public decimal SubTotal { get; set; }
    public int Quantity { get; set; }

    //Relacion con Order
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    //Relacion con Product
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

}