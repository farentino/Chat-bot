using System;

string userName = "User";

Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
Console.Write("Enter your name: ");

userName = Console.ReadLine();

if (string.IsNullOrWhiteSpace(userName))
{
    userName = "User";
}

Console.WriteLine($"Hello, {userName}!");
Console.WriteLine("You can ask me about passwords, phishing, scams, privacy, or safe browsing.");
Console.WriteLine("Type 'exit' to close the chatbot.");

while (true)
{
    Console.Write("\nYou: ");

    string input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Bot: Please type something.");
        continue;
    }

    input = input.ToLower();

    if (input == "exit")
    {
        Console.WriteLine($"Bot: Goodbye, {userName}! Stay safe online.");
        break;
    }

    if (input.Contains("password"))
    {
        Console.WriteLine("Bot: Use strong, unique passwords for every account. Avoid using your name or birthday.");
    }
    else if (input.Contains("phishing"))
    {
        Console.WriteLine("Bot: Be careful of fake emails and suspicious links. Always check the sender.");
    }
    else if (input.Contains("scam"))
    {
        Console.WriteLine("Bot: Scammers often create urgency. Always verify before sharing information.");
    }
    else if (input.Contains("privacy"))
    {
        Console.WriteLine("Bot: Keep your accounts private and avoid sharing personal information online.");
    }
    else if (input.Contains("safe browsing"))
    {
        Console.WriteLine("Bot: Use secure websites with HTTPS and avoid suspicious downloads.");
    }
    else if (input.Contains("how are you"))
    {
        Console.WriteLine("Bot: I'm doing great! I'm here to help you stay safe online.");
    }
    else if (input.Contains("purpose"))
    {
        Console.WriteLine("Bot: My purpose is to teach you about cybersecurity awareness.");
    }
    else if (input.Contains("what can i ask"))
    {
        Console.WriteLine("Bot: You can ask about passwords, phishing, scams, privacy, and safe browsing.");
    }
    else
    {
        Console.WriteLine("Bot: I didn’t understand. Ask me about passwords, phishing, scams, privacy, or safe browsing.");
    }
}