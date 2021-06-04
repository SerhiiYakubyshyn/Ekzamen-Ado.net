using EkzamenDBBookShop.LiberySetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EkzamenDBBookShop.LiberySet;

namespace EkzamenDBBookShop.Service
{
    class StoryComingService
    {
        private readonly StoryComingTableAdapter _storyComingTableAdapter;
        public StoryComingService(LiberySet liberySet)
        {
            _storyComingTableAdapter = new StoryComingTableAdapter();
            _storyComingTableAdapter.Fill(liberySet.StoryComing);
        }
        public void InsertStoryComing(int idBook, int count, decimal costPrice, decimal price )
        {
            _storyComingTableAdapter.Insert(idBook, count, costPrice, price);
        }
        public void UpdeteStoryComing(int id, int idBook, int count, decimal costPrice, decimal price, int new_idBook, int new_count, decimal new_costPrice, decimal new_price)
        {
            _storyComingTableAdapter.Update(new_idBook, new_count, new_costPrice, new_price, id, idBook, count, costPrice, price);
        }
        //public void DeleteStoryComing(int id)//Історію видаляти не можна
        public StoryComingDataTable GetStoryComing()
        {
            return _storyComingTableAdapter.GetData();
        }
    }
}
