using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lab18UsingYourAPI.Models;
using Newtonsoft.Json;


namespace Lab18UsingYourAPI.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This shows the index page
        /// </summary>
        /// <returns>The index page</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This takes in the data from the api and puts it into the ListItemViewModel
        /// It then sends that information to the list page and displays the lists.
        /// </summary>
        /// <returns>The TodoList page</returns>
        public async Task<IActionResult> TodoList()
        {
            using (var client = new HttpClient())
            {
                // add the appropriate properties on top of the client base address.
                client.BaseAddress = new Uri("https://lab17createanapi.azurewebsites.net/");

                //the .Result is important for us to extract the result of the response from the call
                var response = client.GetAsync("/api/todoList").Result;
                var responseItem = client.GetAsync("/api/todoItem").Result;
                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                {
                    ListItemViewModel viewModel = new ListItemViewModel();
                    var stringResult = await response.Content.ReadAsStringAsync();
                    viewModel.TodoLists = JsonConvert.DeserializeObject<List<TodoList>>(stringResult);
                    if (responseItem.EnsureSuccessStatusCode().IsSuccessStatusCode)
                    {
                        var result = await responseItem.Content.ReadAsStringAsync();
                        viewModel.TodoItems = JsonConvert.DeserializeObject<List<TodoItem>>(result);
                    }
                    return View(viewModel);
                }
                return BadRequest();
            }
        }

        /// <summary>
        /// This takes the data that we get from the api and puts it into the ListItemViewModel.
        /// It then takes that data into the item page and displays the items.
        /// </summary>
        /// <returns>The TodoItem page</returns>
        public async Task<IActionResult> TodoItem()
        {
            using (var client = new HttpClient())
            {
                // add the appropriate properties on top of the client base address.
                client.BaseAddress = new Uri("https://lab17createanapi.azurewebsites.net/");

                //the .Result is important for us to extract the result of the response from the call
                var response = client.GetAsync("/api/todoList").Result;
                var responseItem = client.GetAsync("/api/todoItem").Result;
                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                {
                    ListItemViewModel viewModel = new ListItemViewModel();
                    var stringResult = await response.Content.ReadAsStringAsync();
                    viewModel.TodoLists = JsonConvert.DeserializeObject<List<TodoList>>(stringResult);
                    if (responseItem.EnsureSuccessStatusCode().IsSuccessStatusCode)
                    {
                        var result = await responseItem.Content.ReadAsStringAsync();
                        viewModel.TodoItems = JsonConvert.DeserializeObject<List<TodoItem>>(result);
                    }
                    return View(viewModel);
                }
                return BadRequest();
            }
        }
    }
}
