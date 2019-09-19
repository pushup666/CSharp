using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model
{
    class VersionDO
    {
        public string UID { get; }
        public string BookID { get; }
        public int VersionNo { get; }
        public string Content { get; }
        public string ContentHash { get; }
        public int ContentLength { get; }

        public VersionDO(string bookId, int versionNo, string content, string contentHash, int contentLength)
        {
            UID = Utils.GetUID();
            BookID = bookId;
            VersionNo = versionNo;
            Content = content;
            ContentHash = contentHash;
            ContentLength = contentLength;
        }
    }
}
