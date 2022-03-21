namespace MinecraftLibrary.API.Inventory
{
    public interface IMcWindow
    {
        int ID { get; }
        ContainerType ContainerType { get; }

        void ClickSlot(byte slot);


    }
}
