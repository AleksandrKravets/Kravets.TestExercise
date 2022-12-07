namespace Kravets.TestExercise.Commands;

public class RemoveCommand : StoreItemCommand
{
    private readonly int _count;

    public RemoveCommand(StoreItem storeItem, int count) : base(storeItem)
    {
        _count = count;
    }

    public override void Undo()
    {
        StoreItem.Add(_count);
    }
}