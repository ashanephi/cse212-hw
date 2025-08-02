    public class FeatureCollection
    {
        public string type { get; set; }
        public Metadata metadata { get; set; }
        public Feature[] features { get; set; }
        public double[] bbox { get; set; }
    }

    public class Metadata
    {
        public long generated { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string api { get; set; }
        public int count { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
        public string id { get; set; }
    }

    public class Properties
    {
        public double mag { get; set; }
        public string place { get; set; }
        public long time { get; set; }
        public long updated { get; set; }
        public int tz { get; set; }
        public string url { get; set; }
        public string detail { get; set; }
        public int felt { get; set; }
        public double cdi { get; set; }
        // ... (other properties not needed for the problem can be ignored or included)
    }

    public class Geometry
    {
        public string type { get; set; }
        public double[] coordinates { get; set; }
    }
