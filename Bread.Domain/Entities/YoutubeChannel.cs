using System;
using System.Collections.Generic;

namespace Bread.Domain.Entities
{
    public class PlayItem
    {
        public string Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string VideoId { get; internal set; }
    }

    public class PlayList
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string PublishedAt { get; set; }
        public List<PlayItem> List { get; set; }
        public string ThumbnailUrl { get; internal set; }
    }

    public class Channel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public List<PlayList> PlayLists { get; set; }
    }

}
