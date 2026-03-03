using System;

namespace Notes.BackEnd.Entities;

public class TaskItem
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }
    public string Description { get; private set; }

    public TaskStatus Status { get; private set; }

    public Guid OwnerId { get; private set; }

    protected TaskItem() { }

    public TaskItem(string name, string description, Guid ownerId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Name cannot be empty.");

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        OwnerId = ownerId;
        Status = TaskStatus.New;
    }

    public void ChangeDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
            throw new Exception("Description cannot be empty.");

        Description = newDescription;
    }

    public void ChangeStatus(TaskStatus newStatus)
    {
        Status = newStatus;
    }
}

public enum TaskStatus
{
    New,
    InProgress,
    Done
}