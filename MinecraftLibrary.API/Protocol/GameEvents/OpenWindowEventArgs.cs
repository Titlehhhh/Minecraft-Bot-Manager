namespace MinecraftLibrary.API.Protocol
{
    public class OpenWindowEventArgs : EventArgs
    {
        public WindowType WinType { get; private set; }
        public int ID { get; private set; }
        public string Name { get; private set; }

        public OpenWindowEventArgs(WindowType winType, int iD, string name)
        {
            WinType = winType;
            ID = iD;
            Name = name;
        }
    }
}
