using CSharpFunctionalExtensions;
using Kravets.TestExercise.Commands;
using Kravets.TestExercise.Errors;

namespace Kravets.TestExercise;

public class StoreItem
{
    private readonly Stack<StoreItemCommand> _commands;

    public StoreItem(int itemsCount, Stack<StoreItemCommand> commands)
    {
        ItemsCount = itemsCount;
        _commands = commands;
    }
    
    public int ItemsCount { get; private set; }

    public void Add(int count)
    {
        ItemsCount += count;
        var command = new AddCommand(this, count);
        _commands.Push(command);
    }

    public void Remove(int count)
    {
        ItemsCount -= count;
        var command = new RemoveCommand(this, count);
        _commands.Push(command);
    }

    /*
     * Я специально не удалял последнюю команду со стека.
     * В таком случае у нас всегда будет полная история действий.
     */
    public Maybe<ValidationError> UndoLastCommand()
    {
        if (!_commands.TryPeek(out var command))
        {
            return new ValidationError("Can't undo last action. The item is in its initial state.");
        }

        command.Undo();
        return Maybe.None;
    }

    /*
     * Я различаю логику создания и инстанцирования.
     * Для инстанцирования используется конструктор, который не содержит логики валидации.
     * Инстанцирование может быть необходимым в случае получения объекта с БД.
     * Для создания используется фабричный метод. Подразумевается, что объект создается только один
     * раз и в дальнейшем только инстанцируется, а его состояние всегда валидное.
     */
    public static Result<StoreItem, ValidationError> Create(int itemsCount)
    {
        if (itemsCount < 0)
        {
            return new ValidationError($"Items count should be greater than {itemsCount}.");
        }

        return new StoreItem(itemsCount, new Stack<StoreItemCommand>());
    }
}