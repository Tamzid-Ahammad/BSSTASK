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



# Chat Application Frontend


##Project Overview:
This Angular-based project provides a user authentication and messaging functionality with JWT-based token handling and SignalR integration for real-time chat.

##Technologies Used:
Standalone Typescript Angular Project Templates
Node.js
Angular Material UI component library
Bootstrap

##Key Components:
1. Login Component (login.component.ts):

    Handles user login.
    On successful login, the JWT token and user details are stored in localStorage.
    If a user is already logged in (token exists), they are redirected to the home 
    page.
2. Registration Component (registration.component.ts):

    Manages new user registration.
    On successful registration, the user details are posted to the backend.
    Toastr is used to notify about success or errors (duplicate username, invalid 
    email, etc.).
3. User Service (user.service.ts):

    Provides methods to handle user-related tasks such as registration, login, and fetching all users.
    Sends HTTP requests to the backend API for authentication and user management.
4. Message Service (message.service.ts):

    Manages message sending and conversation retrieval.
    Allows sending messages to a specific conversation and retrieving chat history.
5. Authentication Interceptor (auth.interceptor.ts):

    Intercepts HTTP requests to add the JWT token in the Authorization header.
    Handles unauthorized (401) and forbidden (403) errors, redirecting to login or access denied pages.
6. Auth Guard (auth.guard.ts):

    Protects routes from unauthorized access. If a user is not logged in (no token in localStorage), they are redirected to the login page.
7. Home Component (home.component.ts):

    Manages real-time messaging using SignalR and displays users and messages.
    Once logged in, users can select another user to start chatting.
    Message history is displayed, and new messages are sent in real-time through SignalR.
8. Routing (app-routing.module.ts):

    Defines routes for the login, registration, home, and access-denied pages.
    Protects the home page with the authGuard.
9. Main Application Module (app.module.ts):

    Imports necessary Angular modules, such as FormsModule, ReactiveFormsModule, ToastrModule, etc.
    Configures HTTP interceptors for authentication.

##	Prerequisites
To install angular in the local system you need the following.

	Node.js
Angular requires a current, active LTS, or maintenance LTS version of Node.js.  Please 
visit https://nodejs.org/en/   to download and install node in your environment.
	npm package manager
Angular, the Angular CLI, and Angular applications depend on npm packages for many features and functions. To download and install npm packages, you need an npm package manager. npm package manger is installed with Node.js by default. To check that you have the npm client installed, run npm -v in a terminal window.
•	Install Angular CLI
Angular CLI helps you to create projects, generate application and library code, and perform a variety of ongoing development tasks such as testing, bundling, and deployment.

To install the Angular CLI, open a terminal window and run the following command:
npm install -g @angular/cli
•	Run the Application
	Unzip file
	Navigate to the workspace folder, such as ChatAppUserInterface.
![Screenshot (21)](https://github.com/user-attachments/assets/090b9970-0fef-4a6b-a812-3b2fb01a0dea)
	Open CMD window 
	Run npm install to install all packages used in application
	Write ng serve -o to run the application. And browse http://localhost:4200 to view the chat app.![Screenshot (15)](https://github.com/user-attachments/assets/5361be7f-c64a-4d49-a221-d1d7c64bbe67)
  
If you aren't an registered user then go to click signup for going registration page![Screenshot (22)](https://github.com/user-attachments/assets/d4527db2-5d51-4d87-ae76-7c8d7459071b)
How to register as a user to the chatapp ,i give you a demo picture 
![Screenshot (16)](https://github.com/user-attachments/assets/6e523abd-5ab4-419c-9519-4940ac376b3e)

How to login to the chatapp i give you a demo picture 
![Screenshot (17)](https://github.com/user-attachments/assets/c83d6315-008f-4ded-8ab5-ce1d5377f424)
After login You will be sent to Home page where in the left side you can found all the other user's that using this application . Now select one of those users and start your chat
![Screenshot (18)](https://github.com/user-attachments/assets/d0cf06a5-11eb-421a-aadc-70d32ca52285)
![Screenshot (19)](https://github.com/user-attachments/assets/7451fb34-7c27-446a-92fe-4dd6436bf4e3)
![Screenshot (20)](https://github.com/user-attachments/assets/38fcc855-7ca3-4fb1-a8d7-5f9d87033a32)
## SignalR Real-Time Chat:

    The HomeComponent establishes a SignalR connection using the user's JWT token.
    New messages are handled in real-time, and users' online status is displayed.

Now this is how I make this ChatApplication.
