# Minimalapi

# Minimal Social Network Backend

This is a minimal social network backend built using .NET, the MediatR pattern, and MongoDB database. It allows users to create posts and manage their profiles in a secure environment.

## Features

- **User Management**: Users can register, login, and manage their profiles.
- **Post Creation**: Users can create posts and view posts created by others.
- **Secure Password Storage**: Passwords are securely stored using bcrypt hashing algorithm.
- **Minimalistic Design**: Simple and lightweight design focused on essential social networking functionalities.

## Technologies Used

- **.NET**: Backend framework for building robust and scalable applications.
- **MediatR Pattern**: Simplifies the communication between different components of the application.
- **MongoDB**: A NoSQL database for storing user data and posts.
- **Bcrypt**: Cryptographic hashing algorithm used for secure password storage.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/)

### Installation

1. Clone the repository:

```bash
git clone https://github.com/poolboyinc/Minimalapi.git
```

2. Navigate to the project directory:

```bash
cd your-repository
```

3. Install dependencies:

```bash
dotnet restore
```

4. Configure MongoDB connection string in `appsettings.json`:

```json
  "DbConfig": {
    "ConnectionString" : "your-mongodb-connection-string"
  }
```

5. Run the application:

```bash
dotnet run
```

## Contributing

Contributions are welcome! If you have any ideas for improvements or new features, feel free to open an issue or submit a pull request.

## Future Updates

This project is a work in progress. I will be continuously updating it with new features and improvements.


