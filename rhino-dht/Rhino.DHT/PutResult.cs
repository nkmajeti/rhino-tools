namespace Rhino.DHT
{
    public class PutResult
    {
        public ValueVersion Version { get; set; }
        public bool ConflictExists { get; set; }
    }
}