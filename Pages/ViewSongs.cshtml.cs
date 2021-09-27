using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleAzureCosmosDbWebApp.Models;
using SimpleAzureCosmosDbWebApp.Services;

namespace WebAppAzureCosmosDb.Pages
{

    public class AllSongs : PageModel
    {
        private readonly ICosmosDbService _cosmosDbService;
        public AllSongs(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [BindProperty]
        public List<Item> Songs { get; set; } = new List<Item>();

        public async Task<IActionResult> OnGet()
        {

            var allSongs = await _cosmosDbService.GetItemsAsync("SELECT * FROM c");

            foreach (var s in allSongs)
            {
                Songs.Add(s);
            }

            return Page();
        }

    }
}

