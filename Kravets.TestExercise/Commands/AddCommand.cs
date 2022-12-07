namespace Kravets.TestExercise.Commands;

public class AddCommand : StoreItemCommand
{
    private readonly int _count;

    public AddCommand(StoreItem storeItem, int count) : base(storeItem)
    {
        _count = count;
    }

    public override void Undo()
    {
        StoreItem.Remove(_count);
    }
}
