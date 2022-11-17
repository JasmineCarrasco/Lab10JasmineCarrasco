List<string> StartingTasks = new List<string>();
List<string> CompleteTasks = new List<string>();
List<string> TasksToday = new List<string>();
string[] CompTasks = File.ReadAllLines("CompletedTasks.csv");
string[] ToDoTasks = File.ReadAllLines("ToDoTasks.csv");
string[] TodayTasks = File.ReadAllLines("Stats.csv");
Random r = new Random();
int random = r.Next(0, 9);
string[] Greetings = File.ReadAllLines("Greetings.csv");
int TasksCreatedToDay = 0;
string greeting = Greetings[random];
Console.WriteLine(greeting);
DateTime StartTime = new DateTime();
DateTime CompletionTime = new DateTime();
DateTime Today = new DateTime();
Today = DateTime.Today;
Console.WriteLine(Today);

foreach (string items in ToDoTasks)
{
    StartingTasks.Add(items);
}
foreach (string items in CompTasks)
{
    CompleteTasks.Add(items);
}
foreach (string items in TodayTasks)
{
    TasksToday.Add(items);
}

void ToDoItems()
{
    Console.WriteLine("The following are, incomplete tasks");
    for (int x = 0; x < StartingTasks.Count; x++)
    {
        Console.WriteLine($"   {x + 1}: {StartingTasks[x]}");
    }
    if (StartingTasks.Count == 0)
        Console.WriteLine("No tasks are available");
    Console.ReadLine();
    TaskMenu();
}

void CompletedTasks()
{
    Console.WriteLine("The followung are your completed tasks");
    for (int x = 0; x < CompleteTasks.Count; x++)
    {
        Console.WriteLine($" {x + 1}: {CompleteTasks[x]}");
    }
    if (CompleteTasks.Count == 0)
        Console.WriteLine("No tasks are available");
    Console.ReadLine();
    TaskMenu();
}

void RemoveTasks()
{
    if (StartingTasks.Count <= 0)
    {
        Console.WriteLine("No tasks are available, do you want to create a task to remove?");
        TaskMenu();
    }
    else
    {
        Console.WriteLine("What task do you want removed?");

        for (int x = 0; x < StartingTasks.Count; x++)
        {
            Console.WriteLine($" {x + 1}: {StartingTasks[x]}");
        }
        Console.WriteLine("enter a number");
        int NumComp = int.Parse(Console.ReadLine()) - 1;
        if (NumComp > StartingTasks.Count)
        {
            Console.WriteLine("Try again, eneter a valid number.");
            Console.ReadLine();
            TaskMenu();
        }
        Console.WriteLine($"Is this the Task that you want to Remove {StartingTasks[NumComp]}\n<y or n>");
        string? response = Console.ReadLine();
        if (response == "y")
        {
            Console.WriteLine("Noted, item removed.");
            StartingTasks.Remove(StartingTasks[NumComp]);
            TaskMenu();
        }
        if (response == "n")
        {
            Console.WriteLine("noted.");
            TaskMenu();
        }
        Console.ReadLine();
        TaskMenu();
    }
}

void CompletingTasks()
{
    if(StartingTasks.Count <= 0){
        Console.WriteLine("You have no tasks to complete, please add a task to complete it.");
    }
    else{
    Console.WriteLine("Which Task would you like to complete?");
    for (int x = 0; x < StartingTasks.Count; x++)
    {
        Console.WriteLine($" {x + 1}: {StartingTasks[x]}");
    }
    Console.WriteLine("enter a number");
    int NumComp = int.Parse(Console.ReadLine()) - 1;
    if (NumComp > StartingTasks.Count)
    {
        Console.WriteLine("Invalid Input");
        TaskMenu();
    }
    Console.WriteLine($"Is this the Task that you want to Complete {StartingTasks[NumComp]}\n<y or n>");
    string? response = Console.ReadLine();
    if (response == "y")
    {
        Console.WriteLine("Noted. Task is Completed");
        CompletionTime = DateTime.Now;
        string TaskCompleted = $"{StartingTasks[NumComp]} End Time: {CompletionTime}";
        StartingTasks.Remove(StartingTasks[NumComp]);
        CompleteTasks.Add(TaskCompleted);
        TaskMenu();
    }
    if (response == "n")
    {
        Console.WriteLine("noted.");
        TaskMenu();
    }
    }

    TaskMenu();
}

void Stats()
{
    int CurrentToDo = StartingTasks.Count;
    int CurrentComplete = CompleteTasks.Count;
    int TotalTasks = CurrentToDo + CurrentComplete;
    Console.WriteLine("These are yout stats.");
    Console.WriteLine($"Current Tasks: {CurrentToDo} \nTasks Completed: {CurrentComplete} \nTotal Tasks: {TotalTasks}");
    Console.WriteLine("Tasks Per day");
    for(int x = 0; x < TasksToday.Count; x++){
        Console.WriteLine($"{TasksToday[x]}");
    }
    Console.ReadLine();
    TaskMenu();
}

void AddingItems()
{
    Console.WriteLine("Which task would you like to add?");
    string? response = Console.ReadLine();
    string? Task = response;
    Console.WriteLine($"Here is the name of the task: {Task}");
    Console.WriteLine("Add a description for your task.");
    response = Console.ReadLine();
    string Description = response;
    Console.WriteLine($"Here is the task: {Task}: {Description}");
    Console.WriteLine("Is this correct?\n<y or n>");
    response = Console.ReadLine();
    if (response == "y")
    {
        Console.WriteLine("Noted, Item Added");
        StartTime = DateTime.Now;
        string TaskToBeDone = ($"{Task}:  {Description}    Start Time: {StartTime}     ");
        StartingTasks.Add(TaskToBeDone);
        TasksCreated2Day++;
        TaskMenu();
    }
    if (response == "n")
    {
        Console.WriteLine("noted.");
        TaskMenu();
    }
}

void TaskMenu()
{
    Console.WriteLine("Hello welcome or welcome back, what would you like to get done?");
    Console.WriteLine("1) View tasks to be done\n2) View Completed Tasks\n3) Add tasks\n4) Remove Tasks\n5) Mark tasks as Complete \n6) View Stats\n7) Exit");
    string? response = Console.ReadLine();
    if (response == "1")
        ToDoItems();
    if (response == "2")
        CompletedTasks();
    if (response == "3")
        AddingItems();
    if (response == "4")
        RemoveTasks();
    if (response == "5")
        CompletingTasks();
    if (response == "6")
        Stats();
    if (response == "7")
    {
         Console.Write("Come back soon!");
        File.WriteAllLines("ToDoTasks.csv", StartingTasks);
        File.WriteAllLines("CompletedTasks.csv", CompleteTasks);
        TasksToday.Add($"{TasksCreatedToDay} Tasks Created on {Today}");
        File.WriteAllLines("Stats.csv", TasksToday);
        System.Environment.Exit(0);
       
    }
    else
    {
        TaskMenu();
    }
}

TaskMenu();


