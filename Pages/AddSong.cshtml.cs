using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleAzureCosmosDbWebApp.Models;
using SimpleAzureCosmosDbWebApp.Services;

namespace SimpleAzureCosmosDbWebApp.Pages
{
    public class AddSongModel : PageModel
    {
        private readonly ICosmosDbService _cosmosDbService;
        public AddSongModel(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [BindProperty]
        public Item song { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                song.Id = Guid.NewGuid().ToString();
                song.Link = "https://www.youtube.com/results?search_query=" + song.Name;
                await _cosmosDbService.AddItemAsync(song);
            }
            return RedirectToPage("./Index");
        }
    }
}
