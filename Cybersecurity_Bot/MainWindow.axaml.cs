using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;
using System;
using System.Collections.Generic;

namespace Cybersecurity_Bot;

public partial class MainWindow : Window
{
    private string userName = "User";
    private string favouriteTopic = "";
    private string currentTopic = "";
    private bool waitingForName = true;

    private readonly Random random = new Random();
    private readonly List<string> history = new List<string>();

    private readonly Dictionary<string, List<string>> topicTips = new Dictionary<string, List<string>>
    {
        ["password"] = new List<string>
        {
            "Use strong, unique passwords for every account. A strong password should include uppercase letters, lowercase letters, numbers, and symbols. Avoid using your name, birthday, pet name, or school name.",
            "Never reuse the same password on different websites. If one account gets hacked, criminals may try the same password on your email, banking, or social media accounts.",
            "Use a password manager to store complex passwords safely. This helps you create strong passwords without needing to remember all of them yourself."
        },

        ["phishing"] = new List<string>
        {
            "Phishing is when attackers pretend to be trusted people or companies to steal your information. Always check the sender’s email address before clicking links.",
            "Be careful of messages that create fear or urgency, such as 'your account will be closed today'. Scammers use pressure to make you act quickly without thinking.",
            "Do not open unexpected attachments or links. If a message claims to be from your bank or school, go directly to the official website instead of clicking the link."
        },

        ["scam"] = new List<string>
        {
            "Scammers often promise prizes, jobs, investments, or urgent help to trick people. If something sounds too good to be true, it probably is.",
            "Never share your ID number, banking details, passwords, or one-time PINs with anyone. Real companies will not ask for your password or OTP.",
            "Always verify before sending money or personal information. Contact the company using official contact details, not the number or link in the suspicious message."
        },

        ["privacy"] = new List<string>
        {
            "Protect your privacy by limiting what personal information you share online. Avoid posting your address, phone number, ID number, school location, or daily routine.",
            "Review your social media privacy settings regularly. Make sure only trusted people can see your posts, photos, and personal details.",
            "Check app permissions on your phone. Remove access to your camera, microphone, contacts, or location if the app does not really need it."
        },

        ["malware"] = new List<string>
        {
            "Malware is harmful software that can steal information, damage files, or control your device. Avoid downloading files from unknown websites.",
            "Keep your operating system, browser, and antivirus software updated. Updates often fix security weaknesses that attackers try to use.",
            "Do not install cracked software or unknown apps. These often contain viruses, spyware, or ransomware."
        },

        ["safe browsing"] = new List<string>
        {
            "Use websites that start with HTTPS when entering passwords or personal information. HTTPS helps protect data sent between your browser and the website.",
            "Avoid clicking suspicious pop-ups, adverts, or download buttons. Some fake buttons are designed to install malware or take you to scam websites.",
            "Be careful when using public Wi-Fi. Avoid logging into banking or important accounts on public networks unless you use a trusted VPN."
        }
    };

    public MainWindow()
    {
        InitializeComponent();

        ChatDisplay.Text =
@"   _____                 _                 _       
  / ____|               | |               | |      
 | |     _   _ _ __ ___ | |__   ___   ___ | | ___  
 | |    | | | | '_ ` _ \| '_ \ / _ \ / _ \| |/ _ \ 
 | |____| |_| | | | | | | |_) | (_) | (_) | |  __/ 
  \_____|\__,_|_| |_| |_|_.__/ \___/ \___/|_|\___| 

        CYBERSECURITY AWARENESS BOT
==================================================

Bot: Hello! What is your name?
";

        AddHistory("Application opened and asked for user's name.");

        SendButton.Click += SendButton_Click;
        ClearButton.Click += ClearButton_Click;
        UserInput.KeyDown += UserInput_KeyDown;
    }

    private void SendButton_Click(object? sender, RoutedEventArgs e)
    {
        ProcessInput();
    }

    private void UserInput_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            ProcessInput();
        }
    }

    private void ClearButton_Click(object? sender, RoutedEventArgs e)
    {
        ChatDisplay.Text = "";
        AddHistory("Chat display cleared.");
    }

    private void ProcessInput()
    {
        string input = UserInput.Text ?? "";

        if (string.IsNullOrWhiteSpace(input))
        {
            ChatDisplay.Text += "\nBot: Please enter something.\n";
            AddHistory("User entered empty input.");
            return;
        }

        ChatDisplay.Text += $"\nYou: {input}\n";
        AddHistory("User typed: " + input);

        UserInput.Text = "";

        if (waitingForName)
        {
            userName = input.Trim();
            waitingForName = false;

            AddHistory("Remembered user's name: " + userName);

            ChatDisplay.Text += $"\nBot: Nice to meet you, {userName}!\n";
            ChatDisplay.Text += "Bot: I am your Cybersecurity Awareness Bot.\n";
            ChatDisplay.Text += "Bot: I can help you learn about passwords, phishing, scams, privacy, malware, and safe browsing.\n";
            ChatDisplay.Text += "Bot: What is your favourite cybersecurity topic?\n";
            ChatDisplay.Text += "Bot: You can say something like: My favourite topic is privacy.\n";

            return;
        }

        string lowerInput = input.ToLower();

        if (lowerInput.Contains("show history") ||
            lowerInput.Contains("activity log") ||
            lowerInput.Contains("what have you done"))
        {
            ShowHistory();
            return;
        }

        if (lowerInput.Contains("what is my name"))
        {
            ChatDisplay.Text += $"\nBot: Your name is {userName}.\n";
            AddHistory("User asked for remembered name.");
            return;
        }

        if (lowerInput.Contains("what is my favourite topic") ||
            lowerInput.Contains("what is my favorite topic") ||
            lowerInput.Contains("what topic do i like"))
        {
            if (string.IsNullOrWhiteSpace(favouriteTopic))
            {
                ChatDisplay.Text += "\nBot: You have not told me your favourite cybersecurity topic yet.\n";
            }
            else
            {
                ChatDisplay.Text += $"\nBot: Your favourite cybersecurity topic is {favouriteTopic}.\n";
            }

            AddHistory("User asked for remembered favourite topic.");
            return;
        }

        if (lowerInput.Contains("favourite topic is") ||
            lowerInput.Contains("favorite topic is") ||
            lowerInput.Contains("interested in"))
        {
            string detectedFavourite = DetectTopic(lowerInput);

            if (string.IsNullOrWhiteSpace(detectedFavourite))
            {
                ChatDisplay.Text += "\nBot: Please choose one of these topics: password, phishing, scam, privacy, malware, or safe browsing.\n";
                return;
            }

            favouriteTopic = detectedFavourite;
            currentTopic = detectedFavourite;

            AddHistory("Remembered favourite topic: " + favouriteTopic);

            ChatDisplay.Text += $"\nBot: Great, {userName}! I will remember that your favourite topic is {favouriteTopic}.\n";
            ChatDisplay.Text += $"Bot: Here is a detailed tip about {favouriteTopic}: {GetRandomTip(favouriteTopic)}\n";
            return;
        }

        if (lowerInput.Contains("another tip") ||
            lowerInput.Contains("tell me more") ||
            lowerInput.Contains("explain more"))
        {
            if (!string.IsNullOrWhiteSpace(currentTopic))
            {
                ChatDisplay.Text += $"\nBot: Here is another detailed tip about {currentTopic}: {GetRandomTip(currentTopic)}\n";
                AddHistory("Gave another tip about: " + currentTopic);
                return;
            }

            if (!string.IsNullOrWhiteSpace(favouriteTopic))
            {
                currentTopic = favouriteTopic;
                ChatDisplay.Text += $"\nBot: Since your favourite topic is {favouriteTopic}, here is another tip: {GetRandomTip(favouriteTopic)}\n";
                AddHistory("Gave another tip about favourite topic.");
                return;
            }

            ChatDisplay.Text += "\nBot: Please ask about a cybersecurity topic first, such as password, phishing, scam, privacy, malware, or safe browsing.\n";
            return;
        }

        string sentiment = DetectSentiment(lowerInput);
        string topic = DetectTopic(lowerInput);

        if (!string.IsNullOrWhiteSpace(topic))
        {
            currentTopic = topic;

            ChatDisplay.Text += $"\nBot: {sentiment}{GetRandomTip(topic)}\n";

            if (!string.IsNullOrWhiteSpace(favouriteTopic) && topic == favouriteTopic)
            {
                ChatDisplay.Text += $"Bot: Since {topic} is your favourite topic, this is especially useful for you, {userName}.\n";
            }

            AddHistory("Detected topic and gave tip: " + topic);
            return;
        }

        if (lowerInput.Contains("what can i ask"))
        {
            ChatDisplay.Text += "\nBot: You can ask me about passwords, phishing, scams, privacy, malware, and safe browsing.\n";
            AddHistory("Explained supported topics.");
            return;
        }

        if (lowerInput.Contains("exit"))
        {
            ChatDisplay.Text += $"\nBot: Goodbye, {userName}! Stay safe online.\n";
            AddHistory("User exited conversation.");
            return;
        }

        ChatDisplay.Text += $"\nBot: Sorry {userName}, I didn’t understand that. Ask me about passwords, phishing, scams, privacy, malware, or safe browsing.\n";
        AddHistory("Bot gave default response.");
    }

    private string DetectTopic(string input)
    {
        if (input.Contains("password") || input.Contains("passcode"))
            return "password";

        if (input.Contains("phishing") || input.Contains("email") || input.Contains("fake link"))
            return "phishing";

        if (input.Contains("scam") || input.Contains("fraud") || input.Contains("fake prize"))
            return "scam";

        if (input.Contains("privacy") || input.Contains("personal information") || input.Contains("personal info"))
            return "privacy";

        if (input.Contains("malware") || input.Contains("virus"))
            return "malware";

        if (input.Contains("safe browsing") || input.Contains("browser") || input.Contains("https") || input.Contains("website"))
            return "safe browsing";

        return "";
    }

    private string DetectSentiment(string input)
    {
        if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid"))
        {
            AddHistory("Detected worried sentiment.");
            return "It is understandable to feel worried. ";
        }

        if (input.Contains("confused") || input.Contains("lost") || input.Contains("don't understand"))
        {
            AddHistory("Detected confused sentiment.");
            return "No problem, I will explain it clearly. ";
        }

        if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("annoyed"))
        {
            AddHistory("Detected frustrated sentiment.");
            return "I understand this can feel frustrating. ";
        }

        if (input.Contains("curious") || input.Contains("interested"))
        {
            AddHistory("Detected curious sentiment.");
            return "It is great that you are curious. ";
        }

        return "";
    }

    private string GetRandomTip(string topic)
    {
        List<string> tips = topicTips[topic];
        return tips[random.Next(tips.Count)];
    }

    private void AddHistory(string action)
    {
        history.Add(DateTime.Now.ToString("HH:mm:ss") + " - " + action);
    }

    private void ShowHistory()
    {
        ChatDisplay.Text += "\nBot: Here is the history of what happened:\n";

        if (history.Count == 0)
        {
            ChatDisplay.Text += "No history yet.\n";
            return;
        }

        for (int i = 0; i < history.Count; i++)
        {
            ChatDisplay.Text += $"{i + 1}. {history[i]}\n";
        }

        AddHistory("Displayed full history.");
    }
}