namespace MinecraftBotManager.Models
{
    public class SearchItem
    {
        public bool IsLoaded { get; set; }
        public string Text { get; private set; }
        public SearchItem(string text)
        {
            Text = text;
            IsLoaded = false;
        }
        public SearchItem()
        {
            IsLoaded = true;
            Text = "";
        }
    }
}
