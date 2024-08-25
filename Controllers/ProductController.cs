using AutoMapper;
using MaestroApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersApi.DTOs;
using OrdersApi.Models;

namespace OrdersApi.Controllers;

[ApiController]
[Route("api/Products")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public ProductController(AppDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    //Metodo Http Get para traer todos los productos ordenados por nombre.
    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get()
    {
        return await _context.Products.OrderBy(p => p.Name).ToListAsync();
    }


    //Metodo Http Post para ingresar los productos
    [HttpPost]
    public async Task<ActionResult> Post(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);

        //Convierte los nombre con mayusculas a minusculas.
        product.Name = product.Name.ToLower();

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return Ok();


    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);   

        product.Id = id;

        _context.Update(product);
        await _context.SaveChangesAsync();
        return Ok();


    }

    [HttpDelete("id:int")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleteProduct = await _context.Products.Where(p => p.Id == id).ExecuteDeleteAsync();

        if(deleteProduct == 0)
        {
            return NotFound();
        }

        return NoContent();


       
    }
    


    
}