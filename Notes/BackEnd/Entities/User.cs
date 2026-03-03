using System;

namespace Notes.BackEnd.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string Username { get; private set; }

    public string PasswordHash { get; private set; }

    protected User() { }

    public User(string username, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new Exception("Username cannot be empty.");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new Exception("Password cannot be empty.");

        Id = Guid.NewGuid();
        Username = username;
        PasswordHash = passwordHash;
    }
}