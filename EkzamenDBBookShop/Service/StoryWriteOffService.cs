using EkzamenDBBookShop.LiberySetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EkzamenDBBookShop.LiberySet;

namespace EkzamenDBBookShop.Service
{
    class StoryWriteOffService
    {
        private readonly StoryWriteOffTableAdapter _storyWriteOffTableAdapter;
        public StoryWriteOffService(LiberySet liberySet)
        {
            _storyWriteOffTableAdapter = new StoryWriteOffTableAdapter();
            _storyWriteOffTableAdapter.Fill(liberySet.StoryWriteOff);
        }
        public void InsertStoryWriteOff(int idLiberyShop, int count)
        {
            _storyWriteOffTableAdapter.Insert(idLiberyShop, count);
        }
        public void UpdeteStoryWriteOff(int id, int idLiberyShop, int count, int new_idLiberyShop, int new_count)
        {
            _storyWriteOffTableAdapter.Update(new_idLiberyShop, new_count, new_count, id, idLiberyShop, count);
        }
        //public void DeleteStoryWriteOff(int id)//Історію видаляти не можна
        public StoryWriteOffDataTable GetStoryWriteOff()
        {
            return _storyWriteOffTableAdapter.GetData();
        }
    }
}
