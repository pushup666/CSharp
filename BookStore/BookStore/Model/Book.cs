using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model
{
    class Book
    {
        public string UID { get; }
        public string Title { get; }
        public string Alias { get; }
        public string Author { get; }
        public string Note { get; }
        public int Rate { get; }
        public int DeleteFlag { get; }

        public Book(string title, string alias, string author, string note)
        {
            UID = Utils.GetUID();
            Title = title;
            Alias = alias;
            Author = author;
            Note = note;
            Rate = 0;
            DeleteFlag = 0;
        }
    }
}
