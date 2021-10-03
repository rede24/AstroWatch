using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Metadata
    {
        public int total_hits { get; set; }
    }

    public class Link
    {
        public string prompt { get; set; }
        public string rel { get; set; }
        public string href { get; set; }
        public string render { get; set; }
    }

    public class Datum
    {
        public DateTime date_created { get; set; }
        public List<string> keywords { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string center { get; set; }
        public string nasa_id { get; set; }
        public string media_type { get; set; }
        public string secondary_creator { get; set; }
        public string description_508 { get; set; }
        public string location { get; set; }
        public List<string> album { get; set; }
    }

    public class Item
    {
        public List<Datum> data { get; set; }
        public List<Link> links { get; set; }
        public string href { get; set; }
    }

    public class Collection
    {
        public Metadata metadata { get; set; }
        public List<Link> links { get; set; }
        public string version { get; set; }
        public string href { get; set; }
        public List<Item> items { get; set; }
    }

    public class SearchResult
    {
        public Collection collection { get; set; }
    }
}
