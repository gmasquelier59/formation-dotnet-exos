using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ui.Models;

namespace ui.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public List<Weather>? Weathers { get; set; } = new List<Weather>();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGet()
    {
        HttpClient client = new HttpClient();

        // Avec l'IP publique
        // Weathers = await client.GetFromJsonAsync<List<Weather>>("http://4.232.152.51/weatherforecast");

        // Avec l'IP privée
        // Weathers = await client.GetFromJsonAsync<List<Weather>>("http://10.1.1.16/weatherforecast");

        // Avec le nom d'hôte (recommandé)
        Weathers = await client.GetFromJsonAsync<List<Weather>>("http://pc1/weatherforecast");

        //Weathers = await client.GetFromJsonAsync<List<Weather>>("https://localhost:7199/weatherforecast");
    }
}
