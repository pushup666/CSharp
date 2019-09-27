namespace BookStore.Model
{
    class BookDO
    {
        public string ID { get; }
        public string Title { get; }
        public string Alias { get; }
        public string Author { get; }
        public string Note { get; }
        public int Rate { get; }

        public BookDO(string id, string title, string alias, string author, string note, int rate)
        {
            ID = id;
            Title = title;
            Alias = alias;
            Author = author;
            Note = note;
            Rate = rate;
        }
        public BookDO(string title, string alias, string author, string note)
        {
            ID = Utils.GetUID();
            Title = title;
            Alias = alias;
            Author = author;
            Note = note;
        }
    }
}
