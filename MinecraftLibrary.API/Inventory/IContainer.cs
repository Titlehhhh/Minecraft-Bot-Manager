namespace MinecraftLibrary.API.Inventory
{
    public interface IContainer
    {
        int ID { get; }
        ContainerType ContainerType { get; }

    }
}
