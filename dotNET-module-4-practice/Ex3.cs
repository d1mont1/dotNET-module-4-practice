// Задача 3: Класс "Домашняя библиотека"

using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNET_module_4_practice
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }
    }

    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(string title)
        {
            books.RemoveAll(book => book.Title == title);
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books.Where(book => book.Author == author).ToList();
        }

        public List<Book> SearchByYear(int year)
        {
            return books.Where(book => book.Year == year).ToList();
        }

        public List<Book> SortByTitle()
        {
            return books.OrderBy(book => book.Title).ToList();
        }
    }
}