namespace BookStore.Model
{
    class VersionDO
    {
        public string ID { get; }
        public string BookID { get; }
        public int VersionNo { get; set; }
        public string Content { get; }
        public string ContentHash { get; }
        public int ContentLength { get; }

        public VersionDO(string id, string bookID, int versionNo, string content, string contentHash, int contentLength)
        {
            ID = id;
            BookID = bookID;
            VersionNo = versionNo;
            Content = content;
            ContentHash = contentHash;
            ContentLength = contentLength;
        }

        public VersionDO(string bookID, string content, string contentHash, int contentLength)
        {
            ID = Utils.GetID();
            BookID = bookID;
            Content = content;
            ContentHash = contentHash;
            ContentLength = contentLength;
        }
    }
}
