
namespace NewForFaves.Model
{
    public class Message
    {
        public const string ArtistSelected = "artistSelected";
        public const string InitNews = "initNews";

        public string Key { get; private set; }
        public object AdditionalInfo { get; private set; }

        public Message(string key, object additionalInfo)
            : this(key)
        {
            AdditionalInfo = additionalInfo;
        }

        public Message(string key)
        {
            Key = key;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}
