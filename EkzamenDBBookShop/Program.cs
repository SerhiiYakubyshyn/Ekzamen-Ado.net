using EkzamenDBBookShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkzamenDBBookShop
{
    class Program
    {
        static void Main(string[] args)
        {
            LiberySet liberySet = new LiberySet();
            var autorAdapter = new AutorService(liberySet);
            var bookAdapter = new BookServise(liberySet);
            var operationAdapter = new OperationService(liberySet);
            var liberyShopAdapter = new LiberyShopService(liberySet);
            var storyComing = new StoryComingService(liberySet);
            var storyWriteOff = new StoryWriteOffService(liberySet);
            int Do = 1;
            int Do2;
            while (Do != 0)
            {
                string name, lastName, newName, newLastName;
                string bookName, type, year, note, new_bookName, new_type, new_year, publisheName, new_publisheName;
                int id, countPage, new_countPage, autorId, new_autorId, idLiberyShopId, count, idBook, new_idLiberyShopId, new_count;
                int? PreviousBook, new_PreviousBook;
                decimal costPrice, price;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.Write("(0)Exit\n(1)Operation\n(2))Work whith Libery Shop\n(3)Work whith Autor\n(4)Work whith Book\nSelect-> ");
                Do = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                switch (Do)
                {
                    case 1:
                        Console.Write("(0)Back\n(1)Sell book\n(2)Update information in operation\n(3)Show all operation\n(4)Write off book in libery shop\n(5)Comming new book\nSelect-> ");
                        Do2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        switch (Do2)
                        {
                            case 1:
                                Console.Write("Enter Id Libery shop-> ");
                                idLiberyShopId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter count-> ");
                                count = Convert.ToInt32(Console.ReadLine());
                                operationAdapter.InsertOperation(false,idLiberyShopId, count);
                                break;
                            case 2:
                                Console.Write("Enter Id Operation-> ");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter Id Libery shop-> ");
                                idLiberyShopId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter count-> ");
                                count = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter its coming?(yes-1)(no-0)-> ");
                                bool coming = Convert.ToBoolean(Console.ReadLine());
                                Console.Write("Enter New Id Libery shop-> ");
                                new_idLiberyShopId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter New count-> ");
                                new_count = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter its New coming?(yes-1)(no-0)-> ");
                                bool new_coming = Convert.ToBoolean(Console.ReadLine());
                                operationAdapter.UpdeteOperation(id, coming, idLiberyShopId, count, new_coming, new_idLiberyShopId, new_count);
                                break;
                            case 3:
                                var operations = operationAdapter.GetOperation();
                                foreach (var operation in operations)
                                {
                                    Console.WriteLine($"{operation.Id}|\t{operation.IdLiberyShop}, {operation.Count}");
                                }
                                break;
                             case 4:
                                Console.Write("Enter Id Libery shop-> ");
                                idLiberyShopId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter count-> ");
                                count = Convert.ToInt32(Console.ReadLine());
                                storyWriteOff.InsertStoryWriteOff(idLiberyShopId, count);
                                liberyShopAdapter.DeleteLiberyShop(idLiberyShopId);    
                                var storys = storyWriteOff.GetStoryWriteOff();
                                foreach (var story in storys)
                                {
                                    Console.WriteLine($"{story.id}|\t{story.Count}");
                                }
                                break;
                            case 5:
                                Console.Write("Enter Id book-> ");
                                idBook = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter count-> ");
                                count = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter cost Price-> ");
                                costPrice = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter price-> ");
                                price = Convert.ToDecimal(Console.ReadLine());
                                storyComing.InsertStoryComing(idBook, count, costPrice, price);
                                liberyShopAdapter.InsertLiberyShop(idBook, count, costPrice, price, null);
                                break;
                        }
                        break;
                    case 2:
                        Console.Write("(0)Back\n(1)Insert Libery Shop\n(2)Update Libery Shop\n(3)Delete Libery Shop\n(4)Show all Libery Shop\nSelect-> ");
                        Do2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        switch (Do2)
                        {
                            case 1:
                                Console.Write("Enter Id book-> ");
                                idBook = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter count-> ");
                                count = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter cost Price-> ");
                                costPrice = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter price-> ");
                                price = Convert.ToDecimal(Console.ReadLine());
                                bool isnote;
                                Console.Write("This book have previous book?(yes-1)(no-0)->");
                                isnote = Convert.ToBoolean(Console.ReadLine());
                                if (isnote)
                                {
                                    Console.Write("Enter note->");
                                    note = Console.ReadLine();
                                }
                                else
                                    note = null;
                                liberyShopAdapter.InsertLiberyShop(idBook, count, costPrice, price, note);
                                break;
                            case 2:
                                Console.Write("Enter Libery Shop Id to update-> ");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter Id book-> ");
                                idBook = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter count-> ");
                                count = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter cost Price-> ");
                                costPrice = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter price-> ");
                                price = Convert.ToDecimal(Console.ReadLine());
                                bool isnote2;
                                Console.Write("This book have previous book?(yes-1)(no-0)->");
                                isnote2 = Convert.ToBoolean(Console.ReadLine());
                                if (isnote2)
                                {
                                    Console.Write("Enter note->");
                                    note = Console.ReadLine();
                                }
                                else
                                    note = null;
                                Console.Write("Enter Id book-> ");
                                int new_idBook = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter count-> ");
                                new_count = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter cost Price-> ");
                                decimal new_costPrice = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter price-> ");
                                decimal new_price = Convert.ToDecimal(Console.ReadLine());
                                bool isnote3;
                                Console.Write("This book have previous book?(yes-1)(no-0)->");
                                isnote3 = Convert.ToBoolean(Console.ReadLine());
                                string new_note;
                                if (isnote3)
                                {
                                    Console.Write("Enter note->");
                                    new_note = Console.ReadLine();
                                }
                                else
                                    new_note = null;
                                liberyShopAdapter.UpdeteLiberyShop(id, idBook, count, costPrice, price, note, new_idBook, new_count, new_costPrice, new_price, new_note);
                                break;
                            case 3:
                                Console.Write("Enter Libery Shop Id to delete-> ");
                                id = Convert.ToInt32(Console.ReadLine());
                                liberyShopAdapter.DeleteLiberyShop(id);
                                break;
                            case 4:
                                var shopBooks = liberyShopAdapter.GetLiberyShop();
                                foreach (var book in shopBooks)
                                {
                                    Console.WriteLine($"{book.id}|\t{book.IdBook}, {book.Count}, {book.CostPrice}, {book.Price}, {book.Note}");
                                }
                                break;
                        }
                        break;
                    case 3:
                        Console.Write("(0)Back\n(1)Insert Autor\n(2)Update Autor\n(3)Delete Autor\n(4)Show all autors\nSelect-> ");
                        Do2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        switch (Do2)
                        {
                            case 1:
                                Console.Write("Enter Name-> ");
                                name = Console.ReadLine();
                                Console.Write("Enter Last Name-> ");
                                lastName = Console.ReadLine();
                                autorAdapter.InsertAutor(name, lastName);
                                break;
                            case 2:
                                Console.Write("Enter Autor Id to update-> ");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter Name-> ");
                                name = Console.ReadLine();
                                Console.Write("Enter Last Name-> ");
                                lastName = Console.ReadLine();
                                Console.Write("Enter New Name-> ");
                                newName = Console.ReadLine();
                                Console.Write("Enter New Last Name-> ");
                                newLastName = Console.ReadLine();
                                autorAdapter.UpdeteAutor(id, name, lastName, newName, newLastName);
                                break;
                            case 3:
                                Console.Write("Enter Autor Id to delete-> ");
                                id = Convert.ToInt32(Console.ReadLine());
                                autorAdapter.DeleteAutor(id);
                                break;
                            case 4:
                                var autors = autorAdapter.GetAutor();
                                foreach (var autor in autors)
                                {
                                    Console.WriteLine($"{autor.id}|\t{autor.Name}, {autor.LastName}");
                                }
                                break;
                        }
                        break;

                    case 4:
                        Console.Write("(0)Back\n(1)Insert Book\n(2)Update Book\n(3)Delete Book\n(4)Show all Books\nSelect-> ");
                        Do2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        switch (Do2)
                        {
                            case 1:
                                Console.Write("Enter Book Name-> ");
                                bookName = Console.ReadLine();
                                Console.Write("Enter publishe Name-> ");
                                publisheName = Console.ReadLine();
                                Console.Write("Enter Count Page-> ");
                                countPage = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter Type-> ");
                                type = Console.ReadLine();
                                Console.Write("Enter Year-> ");
                                year = Console.ReadLine();
                                Console.Write("Enter Autor Id-> ");
                                autorId = Convert.ToInt32(Console.ReadLine());
                                int previous = 0;
                                Console.Write("This book have previous book?(yes-1)(no-0)->");
                                previous = Convert.ToInt32(Console.ReadLine());
                                if (previous == 1)
                                {
                                    Console.Write("TEnter Id Previous book->");
                                    PreviousBook = Convert.ToInt32(Console.ReadLine());
                                }
                                else
                                    PreviousBook = null;
                                bookAdapter.InsertBook (bookName, PreviousBook, publisheName, countPage,  type, year, autorId);
                                break;

                            case 2:

                                Console.Write("Enter Book Id to update-> ");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter Book Name-> ");
                                bookName = Console.ReadLine();
                                Console.Write("Enter publishe Name-> ");
                                publisheName = Console.ReadLine();
                                Console.Write("Enter Count Page-> ");
                                countPage = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter Type-> ");
                                type = Console.ReadLine();
                                Console.Write("Enter Year-> ");
                                year = Console.ReadLine();
                                Console.Write("Enter Autor Id-> ");
                                autorId = Convert.ToInt32(Console.ReadLine());
                                int previous2 = 0;
                                Console.Write("This book have previous book?(yes-1)(no-0)->");
                                previous2 = Convert.ToInt32(Console.ReadLine());
                                if (previous2 == 1)
                                {
                                    Console.Write("TEnter Id Previous book->");
                                    PreviousBook = Convert.ToInt32(Console.ReadLine());
                                }
                                else
                                    PreviousBook = null;
                                Console.Write("Enter New Book Name-> ");
                                new_bookName = Console.ReadLine();
                                Console.Write("Enter New publishe Name-> ");
                                new_publisheName = Console.ReadLine();
                                Console.Write("Enter Count Page-> ");
                                new_countPage = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter New Type-> ");
                                new_type = Console.ReadLine();
                                Console.Write("Enter New Year-> ");
                                new_year = Console.ReadLine();
                                Console.Write("Enter New Autor Id-> ");
                                new_autorId = Convert.ToInt32(Console.ReadLine());
                                int previous3 = 0;
                                Console.Write("This book have previous book?(yes-1)(no-0)->");
                                previous3 = Convert.ToInt32(Console.ReadLine());
                                if (previous3 == 1)
                                {
                                    Console.Write("Enter Id Previous book->");
                                    new_PreviousBook = Convert.ToInt32(Console.ReadLine());
                                }
                                else
                                    new_PreviousBook = null;
                                bookAdapter.UpdeteBook(id, bookName, PreviousBook, publisheName, countPage, type, year, autorId, new_bookName, new_PreviousBook, new_publisheName, new_countPage, new_type, new_year, new_autorId);
                                break;
                            case 3:
                                Console.Write("Enter Book Id to delete-> ");
                                id = Convert.ToInt32(Console.ReadLine());
                                bookAdapter.DeleteBook(id);
                                break;
                            case 4:
                                var books = bookAdapter.GetBook();
                                foreach (var book in books)
                                {
                                    Console.WriteLine($"{book.id}|\t{book.BookName}, {book.CountPage}, {book.Type}, {book.Year}, {book.IdAutor}");
                                }
                                break;
                        }
                        break;
                }
            }
            Console.ResetColor();
        }
    }
}
