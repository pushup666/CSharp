using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    class BookStoreBLL
    {
        public static bool isThisHashExist(string hash)
        {
            return BookStoreDAL.isThisHashExist(hash);
        }

        public static bool AddBook(BookDO book)
        {
            return BookStoreDAL.AddBook(book);
        }
    }
}
