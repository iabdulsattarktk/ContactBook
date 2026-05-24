# ContactBook

A full-stack Contact Book web application that performs complete CRUD operations using ASP.NET Core backend, MongoDB database, and HTML/CSS/JS frontend connected via REST API.

## Tech Stack

- **Frontend:** HTML, CSS, JavaScript
- **Backend:** ASP.NET Core (C#)
- **Database:** MongoDB
- **API:** REST API

## Features

- Add new contacts (Name, Phone, Email)
- View all contacts in a table
- Edit existing contacts
- Delete contacts
- Form validation before submission

## Project Structure

```
ContactBook/
├── Controllers/
│   └── ContactsController.cs
├── Models/
│   └── Contact.cs
├── Services/
│   └── ContactService.cs
├── wwwroot/
│   ├── index.html
│   ├── style.css
│   └── app.js
├── appsettings.json
└── Program.cs
```

## Setup Instructions

1. Install [.NET SDK](https://dotnet.microsoft.com/download)
2. Install [MongoDB](https://www.mongodb.com/try/download/community)
3. Clone this repository
4. Open terminal in project folder
5. Run the following command:

```bash
dotnet run
```

6. Open browser and go to:

```
http://localhost:5244/index.html
```

## Screenshots

![ContactBook Screenshot](wwwroot/screenshot.png)
