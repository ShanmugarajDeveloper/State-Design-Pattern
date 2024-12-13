public interface IVendingMachineState
{
    void InsertCoin(VendingMachine machine);
    void PressButton(VendingMachine machine);
    void DispenseItem(VendingMachine machine);
}
public class IdleState : IVendingMachineState
{
    public void InsertCoin(VendingMachine machine)
    {
        Console.WriteLine("Coin inserted.");
        machine.SetState(new HasCoinState());
    }

    public void PressButton(VendingMachine machine)
    {
        Console.WriteLine("Insert coin first.");
    }

    public void DispenseItem(VendingMachine machine)
    {
        Console.WriteLine("No coin inserted.");
    }
}

public class HasCoinState : IVendingMachineState
{
    public void InsertCoin(VendingMachine machine)
    {
        Console.WriteLine("Coin already inserted.");
    }

    public void PressButton(VendingMachine machine)
    {
        Console.WriteLine("Button pressed. Dispensing item...");
        machine.SetState(new DispenseState());
    }

    public void DispenseItem(VendingMachine machine)
    {
        Console.WriteLine("Press button to dispense.");
    }
}

public class DispenseState : IVendingMachineState
{
    public void InsertCoin(VendingMachine machine)
    {
        Console.WriteLine("Cannot insert coin while dispensing.");
    }

    public void PressButton(VendingMachine machine)
    {
        Console.WriteLine("Already dispensing.");
    }

    public void DispenseItem(VendingMachine machine)
    {
        Console.WriteLine("Item dispensed.");
        machine.SetState(new IdleState());
    }
}
public class VendingMachine
{
    private IVendingMachineState _state;

    public VendingMachine()
    {
        _state = new IdleState();
    }

    public void SetState(IVendingMachineState state)
    {
        _state = state;
    }

    public void InsertCoin()
    {
        _state.InsertCoin(this);
    }

    public void PressButton()
    {
        _state.PressButton(this);
    }

    public void DispenseItem()
    {
        _state.DispenseItem(this);
    }
}
class Program
{
    static void Main(string[] args)
    {
        VendingMachine machine = new VendingMachine();

        machine.InsertCoin();   // Output: Coin inserted.
        machine.PressButton();  // Output: Button pressed. Dispensing item...
        machine.DispenseItem(); // Output: Item dispensed.

        machine.PressButton();  // Output: Insert coin first.
    }
}
