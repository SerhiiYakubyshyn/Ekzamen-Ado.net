using EkzamenDBBookShop.LiberySetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EkzamenDBBookShop.LiberySet;

namespace EkzamenDBBookShop
{
    class AutorService
    {
        private readonly AutorTableAdapter _autorTableAdapter;
        public AutorService(LiberySet liberySet)
        {
            _autorTableAdapter = new AutorTableAdapter();
            _autorTableAdapter.Fill(liberySet.Autor);
        }
        public void InsertAutor(string name, string lastName)
        {
            _autorTableAdapter.Insert(lastName, name);
        }
        public void UpdeteAutor(int id, string name, string lastName, string newName, string newLastName)
        {
            _autorTableAdapter.Update(newLastName, newName, id, lastName, name);
        }
        public void DeleteAutor(int id)
        {
            _autorTableAdapter.Delete(id);
        }
        public AutorDataTable GetAutor()
        {
            return _autorTableAdapter.GetData();
        }
    }
}
