
using AutoMapper;
using MaestroApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderApi.DTOs;
using OrdersApi.Models;

namespace OrderApi.Controllers;

[ApiController]
[Route("Api/Orders")]
public class OrderController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public OrderController(AppDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Order>>> Get()
    {
        return await _context.Orders.OrderBy(o => o.DateOrder).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Order>> Post(CreateOrderDTO createOrderDto)
    {
        var order = _mapper.Map<Order>(createOrderDto);
        decimal total = 0;

        if(order.OrderDetails == null || !order.OrderDetails.Any())
        {
            return BadRequest();
        }

        foreach(var detail in order.OrderDetails)
        {
            var product = await _context.Products.FindAsync(detail.ProductId);

            if(product == null)
            {
                return NotFound();
            }
            
            detail.SubTotal = product.Price * detail.Quantity;

            total += detail.SubTotal;

        }

        order.DateOrder = DateTime.UtcNow;
        order.Total = total;

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return Ok();


    }

    


    
    


}