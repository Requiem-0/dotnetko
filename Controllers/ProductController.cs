using Microsoft.AspNetCore.Mvc;

namespace ProductApi;

[ApiController]
[Route("api/[controller]")]
public class ProductController: ControllerBase
{
    //List of product data

    private static readonly List<Product> products =new List<Product>
    {
        new Product
        {
            ID=1,
            Name="Laptop",
            Price= 9999.99m,
            ImageUrl="https://cdn.assets.prezly.com/5b79cc3a-6778-4bc7-a620-346a387dc95d/-/format/auto/aspire-vero_16-03.jpg"
        },

         new Product
        {
            ID=2,
            Name="Mobile",
            Price= 1000.99m,
            ImageUrl="https://www.dxomark.com/wp-content/uploads/medias/post-45678/galaxy-z-flip-by-samsung.png"
        }
    };

    [HttpGet()]
    [Route("getAll")]
    public ActionResult<List<Product>> Get()
    {
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id){
        var productABC =products.FirstOrDefault(p => p.ID == id);
        if(productABC == null)
        {
            return NotFound();
        }
        return Ok(productABC);
    }

    [HttpPost]
    public ActionResult<Product> Post(Product newproduct)
    {
        newproduct.ID = products.Max(p => p.ID) + 1;
        products.Add(newproduct);

        return CreatedAtAction(nameof(Get), new { id = newproduct.ID }, newproduct);
    }


    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var product = products.FirstOrDefault(p => p.ID == id);

        if (product == null)
        {
            return NotFound();
        }

        products.Remove(product);

        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Put (int id, Product product)
    {
        var existingProduct =products.FirstOrDefault( p => p.ID == id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        products.Remove(existingProduct);
        product.ID =id;
        products.Add(product);
        return Ok(product);
    }
}