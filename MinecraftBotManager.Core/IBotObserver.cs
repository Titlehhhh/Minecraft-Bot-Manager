namespace MinecraftBotManager.Core
{
    public interface IBotObserver
    {
        void OnError(Exception e);

        void OnCompleted();

        void OnConnecting();
        void OnConnected();

        void OnDisconnected();
        void OnFindQuickProxy();
        void OnProxyConnecting();
        void OnProxyConnected();
        void SrvFinding();
        void SrvFinded(string address);

        void OnAuthentification();


    }
}
