using System.ComponentModel;
using System.Net.Http.Json;
using Microsoft.SemanticKernel;

namespace SemanticKernelCopilotAPIPlugin.Plugins;

public class BookPlugin
{
    HttpClient _httpClient;

    public BookPlugin()
    {
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5141")
        };
    }
    
    [KernelFunction("get_books")]
    [Description("get all the books from the API")]
    public async Task<List<BookHelper>> GetBooksAsync()
    {
        var response = await _httpClient.GetAsync("/api/books");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<BookHelper>>();
    }
     
    [KernelFunction("get_book")]
    [Description("get a single book. Always Prompt the user before getting the book")]
    public async Task<BookHelper> GetBookByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/api/Books/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BookHelper>();
        }

        throw new HttpRequestException($"Error fetching book with ID {id}: {response.ReasonPhrase}");
    }
}

public class BookHelper
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsBorrowed { get; set; }
}