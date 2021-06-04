using EkzamenDBBookShop.LiberySetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EkzamenDBBookShop.LiberySet;

namespace EkzamenDBBookShop
{
    class BookServise
    {
        private readonly BookTableAdapter _bookTableAdapter;
        public BookServise(LiberySet liberySet)
        {
            _bookTableAdapter = new BookTableAdapter();
            _bookTableAdapter.Fill(liberySet.Book);
        }
        public void InsertBook(string bookName, int? PreviousBook, string publisheName, int countPage, string type, string year, int autorId)
        {
            _bookTableAdapter.Insert(bookName, PreviousBook, publisheName, countPage, type, year, autorId);
        }
        public void UpdeteBook(int id, string bookName, int? PreviousBook, string publisheName, int countPage, string type, string year, int autorId, string new_bookName, int? new_PreviousBook, string new_publisheName, int new_countPage, string new_type, string new_year, int new_autorId)
        {
            _bookTableAdapter.Update(new_bookName, new_PreviousBook, new_publisheName, new_countPage, new_type, new_year, new_autorId, id, bookName, PreviousBook, publisheName, countPage, type, year, autorId);
        }
        public void DeleteBook(int id)
        {
            _bookTableAdapter.Delete(id);
        }
        public BookDataTable GetBook()
        {
            return _bookTableAdapter.GetData();
        }
    }
}
