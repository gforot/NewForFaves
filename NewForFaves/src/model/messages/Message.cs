namespace NewForFaves.Model.Messages
{
    public class Message
    {
        public const string InitMainViewModel = "initMainVM";

        public string Key { get; private set; }
        public Message(string key)
        {
            Key = key;
        }
    }
}
