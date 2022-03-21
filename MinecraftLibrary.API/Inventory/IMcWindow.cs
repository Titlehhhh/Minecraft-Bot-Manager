namespace MinecraftLibrary.API.Inventory
{
    public interface IMcWindow
    {
        int ID { get; }
        WindowType ContainerType { get; }

        void ClickSlot(byte slot);


    }
}
