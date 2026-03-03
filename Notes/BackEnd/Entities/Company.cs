using System;
using System.Collections.Generic;
using System.Linq;

namespace Notes.BackEnd.Entities;

public class Company
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    private readonly List<User> _members = new();
    private readonly List<TaskItem> _tasks = new();

    public IReadOnlyCollection<User> Members => _members;
    public IReadOnlyCollection<TaskItem> Tasks => _tasks;

    protected Company() { }

    public Company(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Company name cannot be empty.");

        Id = Guid.NewGuid();
        Name = name;
    }

    public void AddMember(User user)
    {
        if (_members.Any(u => u.Id == user.Id))
            throw new Exception("User already in company.");

        _members.Add(user);
    }

    public void AddTask(TaskItem task)
    {
        _tasks.Add(task);
    }
}