using EkzamenDBBookShop.LiberySetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EkzamenDBBookShop.LiberySet;

namespace EkzamenDBBookShop
{
    class LiberyShopService
    {
        private readonly LiberyShopTableAdapter _liberyShopTableAdapter;
        public LiberyShopService(LiberySet liberySet)
        {
            _liberyShopTableAdapter = new LiberyShopTableAdapter();
            _liberyShopTableAdapter.Fill(liberySet.LiberyShop);
        }
        public void InsertLiberyShop(int idBook, int count, decimal costPrice, decimal price, string note)
        {
            _liberyShopTableAdapter.Insert(idBook, count, costPrice, price, note);
        }
        public void UpdeteLiberyShop(int id, int idBook, int count, decimal costPrice, decimal price, string note, int new_idBook, int new_count, decimal new_costPrice, decimal new_price, string new_note)
        {
            _liberyShopTableAdapter.Update(new_idBook, new_count, new_costPrice, new_price, new_note, id, idBook, count, costPrice, price, note);
        }
        public void DeleteLiberyShop(int id)
        {
            _liberyShopTableAdapter.Delete(id);
        }
        public LiberyShopDataTable GetLiberyShop()
        {
            return _liberyShopTableAdapter.GetData();
        }
    }
}
