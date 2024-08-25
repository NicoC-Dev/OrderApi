
namespace OrderApi.DTOs;

public class CreateOrderDTO()
{
    public List<OrderDetailDTO> OrderDetails {get; set;} = new List<OrderDetailDTO>();

}