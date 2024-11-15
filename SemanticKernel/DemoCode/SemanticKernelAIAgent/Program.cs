using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.Agents.Chat;
using Microsoft.SemanticKernel.ChatCompletion;

// Build configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Read the values from the configuration
var modelId = configuration["AzureOpenAI:ModelId"];
var endpoint = configuration["AzureOpenAI:Endpoint"];
var apiKey = configuration["AzureOpenAI:ApiKey"];

var builder = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey);
//    .AddOllamaChatCompletion(modelId:"llama3.2")


var kernel = builder.Build();

ChatCompletionAgent projectAgent = new()
{
    Name = "pm",
    Instructions = "You're a project manager. You write a document about wishes, tasks and costs and hands that in at the manager",
    Kernel = kernel,
};

ChatCompletionAgent devAgent = new()
{
    Name = "dev",
    Instructions = "You're a developer. Handles code development and technical implementation tasks, whether it's writing code, testing, or deploying applications. You write in HTML and CSS",
    Kernel = kernel,
};

ChatCompletionAgent managerAgent = new()
{
    Name = "manager",
    Instructions = "You're a manager bot.Who will approve the code and the final product.",
    Kernel = kernel,
};


var terminateFunction = kernel.CreateFunctionFromPrompt(
    "Terminate once the manager has approved the final product");

var history = new ChatHistory();


AgentGroupChat chat =
    new(projectAgent, devAgent, managerAgent)
    {
        ExecutionSettings =
            new()
            {
                TerminationStrategy =
                    new ApprovalTerminationStrategy()
                    {
                        Agents = [managerAgent],
                        MaximumIterations = 6,
                    }
            }
    };



string userInput = """"
                   I want to develop html page about cats. 
                   Keep it very simple. And get final approval from the manager. Show me the final code that the developer has made, and the documentation of the project manager.
                   """;
                   """";

chat.AddChatMessage(new ChatMessageContent(AuthorRole.User, userInput));
Console.WriteLine($"# {AuthorRole.User}: '{userInput}'");

await foreach (var content in chat.InvokeAsync())
{
    Console.WriteLine($"# {content.Role} - {content.AuthorName ?? "*"}: '{content.Content}'");
}

sealed class ApprovalTerminationStrategy : TerminationStrategy
{
    protected override Task<bool> ShouldAgentTerminateAsync(Agent agent, IReadOnlyList<ChatMessageContent> history, CancellationToken cancellationToken)
        => Task.FromResult(history[history.Count - 1].Content?.Contains("approve", StringComparison.OrdinalIgnoreCase) ?? false);
}
