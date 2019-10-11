using System;
using System.Data.SQLite;

namespace BookStore
{
    [SQLiteFunction(FuncType = FunctionType.Collation, Name = "PinYin")]
    public class SQLitePinYingSort : SQLiteFunction
    {
        public override int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.CurrentCulture);
        }
    }
}
