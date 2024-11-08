using RDP;

Console.WriteLine("Enter a value:");
string input = Console.ReadLine() ?? string.Empty;

Rdp parser = new();
parser.Parse(input);