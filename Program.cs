using System;
using System.Runtime.InteropServices;

Console.WriteLine(".NET Runtime Information:");
Console.WriteLine($" OS Name:     {RuntimeInformation.OSDescription}");
Console.WriteLine($" OS Version:  {Environment.OSVersion.Version}");
Console.WriteLine($" OS Platform: {GetOSPlatform()}");
Console.WriteLine($" RID:         {RuntimeInformation.RuntimeIdentifier}");
Console.WriteLine($" Base Path:   {AppContext.BaseDirectory}");
Console.WriteLine();
Console.WriteLine("Host:");
Console.WriteLine($"  Version:      {Environment.Version}");
Console.WriteLine($"  Architecture: {RuntimeInformation.ProcessArchitecture.ToString().ToLower()}");
Console.WriteLine($"  Framework:    {RuntimeInformation.FrameworkDescription}");
Console.WriteLine();
Console.WriteLine("User Information:");
Console.WriteLine($"  User Name:    {Environment.UserName}");
Console.WriteLine($"  User Domain:  {Environment.UserDomainName}");
Console.WriteLine();
Console.WriteLine("Environment variables:");
var envVars = Environment.GetEnvironmentVariables();
bool foundEnvVars = false;
foreach (System.Collections.DictionaryEntry envVar in envVars)
{
    string key = envVar.Key?.ToString() ?? "";
    if (key.StartsWith("DOTNET_", StringComparison.OrdinalIgnoreCase) ||
        key.StartsWith("NUGET_", StringComparison.OrdinalIgnoreCase) ||
        key.StartsWith("COREHOST_", StringComparison.OrdinalIgnoreCase) ||
        key.StartsWith("COMPlus_", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"  {key}: {envVar.Value}");
        foundEnvVars = true;
    }
}
if (!foundEnvVars)
{
    Console.WriteLine("  Not set");
}

static string GetOSPlatform()
{
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return "Windows";
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return "Linux";
    if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return "Darwin";
    if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD)) return "FreeBSD";
    return "Unknown";
}

