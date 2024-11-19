# ChatService

This is a simple real-time chat application project designed to improve my knowledge of **WebSockets**, with a focus on implementing **real-time chats** using **SignalR**. The project allows users to communicate interactively and efficiently in real time. It currently features a basic chat system, and I plan to expand it with additional features such as user login, groups, and a database integration.

## Objective

The primary goal of this project is to learn and understand how to use **WebSockets**, specifically **SignalR**, to create a real-time chat application. The application allows users to send messages to one another in real time, with received messages displayed instantly.

## Current Features

- **Real-time connection**: Users can connect to the server and start exchanging messages in real-time.
- **Send and receive messages**: Users can send messages to all connected clients.
- **Basic chat structure**: Communication occurs through a single connection, where messages are broadcasted to all connected clients.

## Technologies Used

- **.NET 6** or higher
- **SignalR** for real-time communication
- **C#** for server and client implementation
- **Console Application** for the client (CLI)
- **ASP.NET Core** for creating the server and API

## Planned Features

In future versions, I plan to expand the project to include the following features:

1. **User Login**
   - Implement a simple login system where users can create accounts.

2. **Database Integration**
   - Store sent messages in a **database** (e.g., SQL Server or SQLite).
   - Retrieve message history.

3. **Group Chats**
   - Allow users to create and join **chat groups**.
   - Implement private messaging and group messaging features.

## Future Improvements

- **Error Handling**: Improve error handling for connection failures, message sending issues, and other exceptions.

## How to Run

1. Clone the repository to your local machine.
2. Open the solution in **Visual Studio** or your preferred C# IDE.
3. Build and run the **server** (ASP.NET Core project).
4. Open a separate terminal window to run the **client** (Console Application).
5. The client will connect to the server and allow you to send and receive messages.
