namespace build_web_api_aspnet_core.Models;
// defines a Pizza Class, comes from Model View Controller arch that api uses
public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }
}