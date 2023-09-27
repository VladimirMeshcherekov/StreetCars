internal class AddNewItemToInventorySignal
{
    public readonly PlayerCarsTypes NewCarType;
    public AddNewItemToInventorySignal(PlayerCarsTypes newCarType)
    {
        NewCarType = newCarType;
    }
}