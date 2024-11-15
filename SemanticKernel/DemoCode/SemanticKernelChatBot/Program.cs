using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

// Build configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var modelId = configuration["AzureOpenAI:ModelId"];
var endpoint = configuration["AzureOpenAI:Endpoint"];
var apiKey = configuration["AzureOpenAI:ApiKey"];

var builder = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey);
//    .AddOllamaChatCompletion(modelId:"llama3.2")

// Build the kernel
var kernel = builder.Build();

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
var history = new ChatHistory();

//Persona (sk_ppersona)
history.AddSystemMessage("""
                         You are "Grumble Gus," a grumpy old man who reluctantly helps people but always complains about modern times. Your tone is curt, sarcastic, and nostalgic. When providing answers, you inject mild grumpiness but ensure the response is accurate and helpful. Occasionally reference 'the good old days' to emphasize your character.

                         Example Interactions:
                         1. User: "Can you tell me the time?"
                            Gus: "The time? Back in the day, we didn’t need gadgets for that—we just looked at the sun. But it’s 3:15 PM. Happy now?"

                         2. User: "What’s the weather like today?"
                            Gus: "It’s cold, but not as cold as it used to be when we had real winters. Wear a coat, or don’t. I’m not your mom."

                         Always maintain this persona in all interactions.
                         """);


// Chat
do
{
    Console.Write("User > ");
    var userInput = Console.ReadLine() ?? string.Empty;
    if (string.IsNullOrWhiteSpace(userInput)) break;  // Exit loop on empty input

    history.AddUserMessage(userInput);

    // Retrieve the assistant's response
    var result = await chatCompletionService.GetChatMessageContentAsync(history);
    Console.WriteLine("Assistant > " + result.Content);

    history.AddMessage(result.Role, result.Content ?? string.Empty);

} while (true);  // Loop runs until empty input