// controller is a public class with methods known as actions
// actions are exposed as HTTP endpoints inside the web API Controller
using build_web_api_aspnet_core.Models;
using build_web_api_aspnet_core.Services;
using Microsoft.AspNetCore.Mvc;

namespace build_web_api_aspnet_core.Controllers;

[ApiController]
[Route("[controller]")] // defines mapping to controller token /pizza
public class PizzaController : ControllerBase // derives from ControllerBase to work with HTTP Requests in .NET Core
{
    public PizzaController()
    {
    }

    // GET all action
    [HttpGet] // responds only to GET
    /*
    retuns actionresult(base class for all action results) instance of type List<pizza> 
    queries service for all pizza and returns data
    */
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    // GET by Id action
    [HttpGet("{id}")] // responds to GET with id parameter 
    public ActionResult<Pizza> Get(int id) // REQUIRES ID
{
    var pizza = PizzaService.Get(id); // queries data for pizza with id

    if(pizza == null)// if not found
        return NotFound(); // doesnt exist 404

    return pizza; //exists 200
} 
    // POST action
    [HttpPost] //repsonds to POST
    /*
    returns an IActionResult Instance (lets client knows if request and succeeded returning new id of instances) 
    */
    public  IActionResult Create(Pizza pizza){
    PizzaService.Add(pizza);
    return CreatedAtAction(nameof(Get),  new {id = pizza.Id}, pizza); // first: action name, 
    }

    // PUT action
[HttpPut("{id}")] // responds to PUT requires id paramter
 public IActionResult Update(int id, Pizza pizza) // returns IActionResult because type isnt known
{
    if (id != pizza.Id)
        return BadRequest();
           
    var existingPizza = PizzaService.Get(id);
    if(existingPizza is null)
        return NotFound();
   
    PizzaService.Update(pizza);           
   
    return NoContent();
}

    // DELETE action
    [HttpDelete("{id}")] //responds to DELETE requires id
public IActionResult Delete(int id)
{
    var pizza = PizzaService.Get(id);
   
    if (pizza is null)
        return NotFound();
       
    PizzaService.Delete(id);
   
    return NoContent();
}
}