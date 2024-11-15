using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SemanticKernelCopilot.Plugins;
using System;
using System.IO;

public class ExportPlugin
{
    [KernelFunction("export_data_to_file")]
    [Description("Creates a txt file containing data")]
    public void ExportTextFile(string fileName, string stringData)
    {
        // Define the directory path
        string directoryPath = @"C:\Code\SemanticKernalDemos\export";

        // Ensure the directory exists
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Combine the directory path with the file name
        string fullPath = Path.Combine(directoryPath, fileName);

        // Write all text to the specified file
        File.WriteAllText(fullPath, stringData);

        Console.WriteLine($"File saved successfully at {fullPath}");
    }
}