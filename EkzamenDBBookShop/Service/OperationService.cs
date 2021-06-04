using EkzamenDBBookShop.LiberySetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EkzamenDBBookShop.LiberySet;

namespace EkzamenDBBookShop.Service
{
    class OperationService
    {
        private readonly OperationTableAdapter _operationTableAdapter;
        public OperationService(LiberySet liberySet)
        {
            _operationTableAdapter = new OperationTableAdapter();
            _operationTableAdapter.Fill(liberySet.Operation);
        }
        public void InsertOperation(bool coming, int idLiberyShop, int count)
        {
            _operationTableAdapter.Insert(coming, idLiberyShop, count);
        }
        public void UpdeteOperation(int id, bool coming, int idLiberyShop, int count, bool new_coming, int new_idLiberyShop, int new_count)
        {
            _operationTableAdapter.Update(new_coming, new_idLiberyShop, new_count, id, coming, idLiberyShop, count);
        }
        //public void DeleteOperation(int id)//Операцію видаляти не можна
        public OperationDataTable GetOperation()
        {
            return _operationTableAdapter.GetData();
        }
    }
}
