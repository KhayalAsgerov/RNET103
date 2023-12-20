using System;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
       Book book1 = new Book("Harry Potter", "J.K.Rowling", 300, 100, "123456789");
       Book book2= new Book( "The Lord of the Rings", "J.R.R.Tolkien", 500, 150, "987654321");
         Book book3 = new Book("The Hobbit", "J.R.R.Tolkien", 250, 80, "456789123");
        Book book4 = new Book("The Great Gatsby", "F.Scott Fitzgerald", 200, 70, "789123456");  
        Book book5 = new Book("The Catcher in the Rye", "J.D.Salinger", 150, 60, "321654987");
        Book book6 = new Book("The Da Vinci Code", "Dan Brown", 400, 120, "654987321");
        Book book7 = new Book("The Alchemist", "Paulo Coelho", 350, 110, "987321654");
        Book book8 = new Book("The Little Prince", "Antoine de Saint-Exupery", 100, 50, "321987654");
        Book book9 = new Book("The Picture of Dorian Gray", "Oscar Wilde", 180, 70, "654321987");
        Book book10 = new Book("The Adventures of Sherlock Holmes", "Arthur Conan Doyle", 250, 80, "789456123");
        Library library = new Library(new List<Book>());
        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);
        library.AddBook(book4);
        library.AddBook(book5);
        library.AddBook(book6);
        library.AddBook(book7);
        library.AddBook(book8);
        library.AddBook(book9);
        library.AddBook(book10);
        library.FindAllBooks();
        System.Console.WriteLine("__________________________");
        library.GetBookByCode("123456789");
        System.Console.WriteLine("__________________________");
      //  library.RemoveAllBooks();
       // System.Console.WriteLine("__________________________");
       // library.FindAllBooks();
       Order order = new Order();
       order.OrderBooks = new List<Book>();
       order.OrderBooks.Add(book3);
       order.OrderBooks.Add(book5);
       order.OrderBooks.Add(book7);
       System.Console.WriteLine("Total price is : " + order.TotalPriceCalculation());

    }
    public class Book
    {
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int PageCount { get; set; }
        public int Price { get; set; }
        public string Code { get; set; }
        public Book( string bookName, string bookAuthor, int pageCount, int price, string code)
        {
            BookName = bookName;
            BookAuthor = bookAuthor;
            PageCount = pageCount;
            Price = price;
            Code = code;
        }
          
    }
    public class Library
    {
        public List<Book> Books { get; set; }

        public Library(List<Book> books)
        {
            Books = books;
        }

        public void AddBook( Book book)
       {
       Books.Add(book);
       }
       public void GetBookByCode(string code)
       {
           foreach (var book in Books)
           {
               if (book.Code == code)
               {
                   Console.WriteLine(book.BookName);
               }
           }
       }
       public void FindAllBooks()
         {
              foreach (var book in Books)
              {
                Console.WriteLine(book.BookName);
              }
         }
         public void RemoveAllBooks()
         {
             Books.Clear();
         }
    }
    public class Order
    {
        public int Id { get; set; }
        public  List<Book> OrderBooks { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPriceCalculation()
        {
            foreach (var book in OrderBooks)
            {
                TotalPrice += book.Price;
            }
            return TotalPrice;
        }
    }
}