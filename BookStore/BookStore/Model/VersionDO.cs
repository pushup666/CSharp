﻿namespace BookStore.Model
{
    class VersionDO
    {
        public string UID { get; }
        public string BookID { get; }
        public int VersionNo { get; set; }
        public string Content { get; }
        public string ContentHash { get; }
        public int ContentLength { get; }
        public int DeleteFlag { get; }

        public VersionDO(string bookId, string content, string contentHash, int contentLength)
        {
            UID = Utils.GetUID();
            BookID = bookId;
            Content = content;
            ContentHash = contentHash;
            ContentLength = contentLength;
        }

        public VersionDO(string uid, string bookId, int versionNo, string content, string contentHash, int contentLength)
        {
            UID = uid;
            BookID = bookId;
            VersionNo = versionNo;
            Content = content;
            ContentHash = contentHash;
            ContentLength = contentLength;
        }
    }
}
