namespace OrdersApi.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime DateOrder { get; set; }
    public decimal Total { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}