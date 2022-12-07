namespace Kravets.TestExercise.Commands;

public abstract class StoreItemCommand
{
    protected readonly StoreItem StoreItem;

    protected StoreItemCommand(StoreItem storeItem)
    {
        StoreItem = storeItem;
    }
    
    public abstract void Undo();
}