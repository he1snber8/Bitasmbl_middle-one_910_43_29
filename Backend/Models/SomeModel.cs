public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public List<Objective> Objectives { get; set; }
}

public class Objective
{
    public int Name { get; set; }
    public string Assignee { get; set; }
}
public enum Status
{
    Vacant,
    Draft,
    Active,
    Completed
}
public enum Priority
{
    Meh,
    Low,
    Medium,

    High
}