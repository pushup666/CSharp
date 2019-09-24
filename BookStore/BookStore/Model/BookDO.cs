namespace BookStore.Model
{
    class BookDO
    {
        public string UID { get; }
        public string Title { get; }
        public string Alias { get; }
        public string Author { get; }
        public string Note { get; }
        public int Rate { get; }
        public int DeleteFlag { get; }

        public BookDO(string uid, string title, string alias, string author, string note, int rate)
        {
            UID = uid;
            Title = title;
            Alias = alias;
            Author = author;
            Note = note;
            Rate = rate;
        }
        public BookDO(string title, string alias, string author, string note)
        {
            UID = Utils.GetUID();
            Title = title;
            Alias = alias;
            Author = author;
            Note = note;
        }
    }
}
