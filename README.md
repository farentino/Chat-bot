# Cybersecurity Awareness Bot

<img width="1874" height="1472" alt="Screenshot 2026-05-26 at 15 55 19" src="https://github.com/user-attachments/assets/dc204fd6-6b75-45e3-b621-c52ca2b3c81f" />
<img width="2061" height="1620" alt="Screenshot 2026-05-26 at 15 55 00" src="https://github.com/user-attachments/assets/43bb34f2-4eef-49b0-9ec3-ace15d20c0b7" />
<img width="1866" height="1479" alt="Screenshot 2026-05-26 at 15 53 56" src="https://github.com/user-attachments/assets/2d7326d7-d2a3-4684-bc10-fe9d7c9a636e" />


## Overview

The Cybersecurity Awareness Bot is a desktop chatbot application developed in C# using Avalonia UI. The purpose of the chatbot is to educate users about important cybersecurity topics such as password safety, phishing, scams, malware, privacy, and safe browsing.

The chatbot provides interactive conversations, remembers user information, detects sentiment, and gives cybersecurity advice in a user-friendly way.

---

# Features

## User Interaction
- Greets the user when the application opens
- Asks for the user’s name
- Remembers the user’s name during the conversation
- Provides a conversational chatbot experience

## Cybersecurity Topics
The chatbot can provide advice about:
- Password safety
- Phishing attacks
- Online scams
- Privacy protection
- Malware
- Safe browsing

## Keyword Recognition
The chatbot recognises cybersecurity-related keywords in user input and responds with relevant cybersecurity guidance.

## Random Responses
The chatbot stores multiple responses for each cybersecurity topic and randomly selects a response to make conversations more natural and less repetitive.

## Conversation Flow
The chatbot remembers the current conversation topic and can continue the discussion when the user says:
- “Tell me more”
- “Another tip”
- “Explain more”

## Memory and Recall
The chatbot remembers:
- The user’s name
- The user’s favourite cybersecurity topic

The user can ask:
- “What is my name?”
- “What is my favourite topic?”

## Sentiment Detection
The chatbot detects simple emotions such as:
- Worried
- Confused
- Curious
- Frustrated

It adjusts its responses to provide supportive and empathetic replies.

## Activity History
The chatbot stores a history of:
- User interactions
- Detected topics
- Sentiment detections
- Remembered information

Users can type:
- “Show history”

to view the chatbot activity log.

---

# Technologies Used

- C#
- .NET
- Avalonia UI
- Visual Studio Code

---

# Why Avalonia UI Was Used

Avalonia UI was used because it supports cross-platform desktop applications on:
- Windows
- macOS
- Linux

WPF and WinForms are Windows-only technologies and do not run natively on macOS. Avalonia provides a modern graphical user interface framework similar to WPF while supporting macOS development.

---

# How to Run the Project

## Requirements
- .NET SDK installed
- Visual Studio Code
- Avalonia templates installed

## Install Avalonia Templates

```bash
dotnet new install Avalonia.Templates
