using Kravets.TestExercise;

var itemResult = StoreItem.Create(100);

if (itemResult.IsFailure)
{
    Console.WriteLine(itemResult.Error.Message);
    return;
}

var item = itemResult.Value;
item.Add(10);
item.Add(5);
item.Remove(10);
var error = item.UndoLastCommand();

if (error.HasValue)
{
    Console.WriteLine(error.Value.Message);
    return;
}

Console.WriteLine($"Done! Items count: {item.ItemsCount}");
