# Chat Application Backend

##Project Overview:
This project implements a chat application backend, featuring user authentication via JWT tokens, real-time messaging using SignalR, and a database using Entity Framework Core with SQL Server.

##Technologies Used:
ASP.NET Core: For building the API backend.
Entity Framework Core: For database interaction (SQL Server).
ASP.NET Core Identity: For user authentication and management.
JWT: For secure authentication with tokens.
SignalR: For real-time chat functionality.
Swagger: For API documentation and testing.
Newtonsoft.Json: For handling JSON serialization/deserialization.
SQL Server: For the database.


##Features:
User Authentication & Authorization: Users can register and log in using their email and password. JWT tokens are used for authentication.
Real-Time Chat: Users can send and receive messages in real-time using SignalR.
Conversations & Messages: Users can create and participate in conversations and send messages within those conversations.
CRUD Operations: Create, read, and delete operations for conversations and messages.
User Management: Manage user profiles and their participation in conversations.
Swagger API Documentation: Interactive API testing via Swagger.

##Installation and Setup
Prerequisites

    .NET SDK (v8.0.8)
    SQL Server

    Step-by-Step Setup :
    1. Clone the Repository: git clone https://github.com/Tamzid-Ahammad/BSSTASK.git
    2. Database Setup: Ensure your database connection string is correctly set in appsettings.json:
 "ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ChatAppsDB;Trusted_Connection=True;Trust Server Certificate=True"
}
3. Migrate Database: Run the following commands to apply migrations and set up the database:
Go TO => Tools>NuGet Package Manager > Package Manager Console and type
 Add-Migration Initial press enter & after type Update-Database and press enter

4. Configure JWT Secret: Update the ApplicationSettings:JWT_Secret value in appsettings.json for your project:
   "ApplicationSettings": {
  "JWT_Secret": "1234567890123456123456789012345612345678901234561234567890123456",
  "Client_URL": "http://localhost:4200/"
}
5. Run the Application: From Visual Studio2022 click https to run the project
6. Access the Swagger UI: Once the app is running, navigate to https://localhost:7104/swagger/index.html to view the API documentation and test the endpoints.

##API Endpoints
Authentication & User Management:
    POST /api/account/register: Register a new user.
    POST /api/account/login: Authenticate an existing user.
Conversations:
    GET /api/chat/getConversation/{myUserId}/{targetUserId}: Retrieve or create a conversation between two users.
Messages:
    GET /api/chat/conversation/{conversationId}/messages: Retrieve all messages for a conversation.
    POST /api/chat/conversation/{conversationId}/send: Send a new message in a conversation.

##Authentication
This application uses JWT (JSON Web Token) for secure communication. After logging in, the client receives a JWT token that should be included in the Authorization header of each request.

## Real-Time Chat
This project integrates SignalR for real-time chat functionality. The SignalR hub is exposed at /chathub, allowing clients to connect and receive real-time messages.

##Swagger
Swagger has been integrated to document and interact with the API. It provides a user-friendly interface for testing all endpoints without needing a separate client.
    Access it via: https://localhost:7104/swagger/index.html

##Development Notes

    CORS Configuration: The application allows requests from http://localhost:4200 (or any configured client URL that you are set in  your ApplicationSettings).
    SignalR Events:
        OnConnectedAsync and OnDisconnectedAsync handle user connection and disconnection events.
        SignalR events broadcast messages to specific users.



#
