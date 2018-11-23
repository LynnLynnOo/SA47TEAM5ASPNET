using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace SA47TEAM5ASPNET
{
    public static class BusinessLogic
    {
        #region Methods for Data Retrieval
        /// <summary>
        /// BASIC DATA RETRIEVAL
        /// </summary>
        /// <param name="BookId"></param>
        /// <returns></returns>
        public static int GetQty(int BookId)
        {
            using (Bookshop context = new Bookshop())
            {
                var query = context.Book.FirstOrDefault(x => x.BookID == BookId);
                return query.Stock;
            }
        }

        public static Book GetBook(string isbn)
        {
            using (Bookshop context = new Bookshop())
            {
                Book book = context.Book.Single(x => x.ISBN == isbn);
                return book;
            }
        }

        public static string GetBookTitle(int bookId)
        {
            using (Bookshop context = new Bookshop())
            {
                var query = context.Book.FirstOrDefault(x => x.BookID == bookId);
                if (query != null)
                {
                    return query.Title;
                }
                else
                {
                    return "Invalid ID";
                }
            }
        }

        //Get book ID given ISBN
        public static int GetBookID(string isbn)
        {
            using (Bookshop context = new Bookshop())
            {
                Book book = context.Book.Single(x => x.ISBN == isbn);
                return book.BookID;
            }
        }

        //*Get CategoryName
        public static string GetCategoryName(string isbn)
        {
            using (Bookshop context = new Bookshop())
            {
                return context.Book.First(x => x.ISBN == isbn).Category.Name;
            }
        }

        //Get Customer Order
        public static List<Invoice> GetCustomerOrder(string customerId)
        {
            List<Invoice> listInvoice = new List<Invoice>();
            using (Bookshop context = new Bookshop())
            {
                listInvoice = context.Invoice.Where(x => x.CustomerID == customerId).ToList();
            }
            return listInvoice;
        }


        public static List<CartPromo> Promos()
        {
            using (Bookshop context = new Bookshop())
            {
                List<CartPromo> promos = new List<CartPromo>();
                promos = context.CartPromo.OrderBy(x => x.ValidStart).ToList();
                return promos;
            }
        }

        public static List<CategoryDiscount> CDiscount()
        {
            using (Bookshop context = new Bookshop())
            {
                List<CategoryDiscount> cDis = new List<CategoryDiscount>();
                cDis = context.CategoryDiscount.OrderBy(x => x.DiscountID).ToList();
                return cDis;
            }
        }

        public static List<Category> Cats()
        {
            using (Bookshop context = new Bookshop())
            {
                List<Category> category = new List<Category>();
                category = context.Category.ToList();
                return category;
            }
        }

        //Display all books
        public static List<Book> ListAllBooks()
        {
            using (Bookshop context = new Bookshop())
            {
                List<Book> bookList = new List<Book>();
                bookList = context.Book.ToList();
                return bookList;
            }
        }

        //Search books using keyword
        public static List<Book> SearchBook(string keyword)
        {
            using (Bookshop context = new Bookshop())
            {
                List<Book> bookList = new List<Book>();
                bookList = context.Book.Where(x => DbFunctions.Like(x.Title, "%" + keyword + "%")).ToList();
                return bookList;
            }
        }

        //Search books using keyword and category
        public static List<Book> SearchCategory(int categoryId, string keyword)
        {
            List<Book> bookList = SearchBook(keyword);
            if (categoryId != 6)
            {
                bookList = bookList.Where(x => x.CategoryID == categoryId).ToList();
            }
            return bookList;
        }

        #endregion

        #region Methods for Business Logic
        /// <summary>
        /// Business logic
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        //Get Normal Price of books
        public static decimal GetPrice(int bookId)
        {
            using (Bookshop context = new Bookshop())
            {
                Book book = context.Book.Single(x => x.BookID == bookId);
                return book.Price;
            }
        }

        //Get discounted price of books
        public static decimal GetDiscountedPrice(int bookId)
        {
            using (Bookshop context = new Bookshop())
            {
                CategoryDiscount discount = new CategoryDiscount();
                Book book = context.Book.Single(x => x.BookID == bookId);
                List<CategoryDiscount> listDiscount = context.CategoryDiscount.Where(x => x.CategoryID == book.CategoryID).ToList();
                foreach (CategoryDiscount dis in listDiscount)
                {
                    if (dis.ValidStart.AddDays(dis.DiscountDuration) >= DateTime.Today)
                    {
                        discount = dis;
                        break;
                    }
                }
                if (discount != null)
                    return book.Price * ((100 - discount.DiscountAmt) / 100m);
                else
                    return book.Price;
            }
        }

        public static void CreateBook(string title, int categoryId, string isbn, string author, int stock, decimal price, string imageUrl)
        {
            using (Bookshop context = new Bookshop())
            {
                Book book = new Book
                {
                    BookID = context.Book.Count() + 1,
                    Title = title,
                    //CategoryID = categoryId,
                    Category = context.Category.First(x => x.CategoryID == categoryId),
                    ISBN = isbn,
                    Author = author,
                    Stock = stock,
                    Price = price,
                    Image = imageUrl
                };
                context.Book.Add(book);
                context.SaveChanges();
            }
        }

        //Update Book entry
        public static bool UpdateBook(int bookId, string title, int categoryId, string isbn, string author, int stock, decimal price, string imageUrl)
        {
            using (Bookshop context = new Bookshop())
            {
                Book book = context.Book.Single(x => x.BookID == bookId);
                if (book != null)
                {
                    book.Title = title;
                    //book.CategoryID = categoryId;
                    book.Category = context.Category.First(x => x.CategoryID == categoryId);
                    book.ISBN = isbn;
                    book.Author = author;
                    book.Stock = stock;
                    book.Price = price;
                    book.Image = imageUrl;
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        //Create promo code
        public static void CreatePromoCode(string promoCode, short discount, DateTime validStart, int promoDuration)
        {
            using (Bookshop context = new Bookshop())
            {
                CartPromo cartPromo = new CartPromo
                {
                    PromoCode = promoCode,
                    Discount = discount,
                    ValidStart = validStart,
                    PromoDuration = promoDuration
                };
                context.CartPromo.Add(cartPromo);
                context.SaveChanges();
            }
        }

        //Update promo code
        public static bool UpdatePromoCode(string promoCode, short discount, DateTime validStart, int promoDuration)
        {
            using (Bookshop context = new Bookshop())
            {
                CartPromo cartPromo = context.CartPromo.Single(x => x.PromoCode == promoCode);
                if (cartPromo != null)
                {
                    //cartPromo.PromoCode = promoCode;
                    cartPromo.Discount = discount;
                    cartPromo.ValidStart = validStart;
                    cartPromo.PromoDuration = promoDuration;
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        //Create discount based on category
        public static void CreateCategoryDiscount(string discountId, short discountAmt, DateTime validStart, int discountDuration, int categoryId)
        {
            using (Bookshop context = new Bookshop())
            {

                CategoryDiscount promoPeriod = new CategoryDiscount
                {
                    DiscountID = discountId,
                    DiscountAmt = discountAmt,
                    ValidStart = validStart,
                    DiscountDuration = discountDuration,
                    //CategoryID = categoryId,
                    Category = context.Category.Single(x => x.CategoryID == categoryId)
                };

                context.CategoryDiscount.Add(promoPeriod);
                context.SaveChanges();
            }
        }

        //Update category discount
        public static bool UpdateCategoryDiscount(string discountId, short discountAmt, DateTime validStart, int discountDuration, int categoryId)
        {
            using (Bookshop context = new Bookshop())
            {
                CategoryDiscount promoPeriod = context.CategoryDiscount.Single(x => x.DiscountID == discountId);
                if (promoPeriod != null)
                {
                    promoPeriod.DiscountAmt = discountAmt;
                    promoPeriod.ValidStart = validStart;
                    promoPeriod.DiscountDuration = discountDuration;
                    promoPeriod.Category = context.Category.Single(x => x.CategoryID == categoryId);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        //Checkout button
        public static bool CheckOut(List<CartItem> listCart, string customerId, string promoCode)
        {
            //List<InvoiceDetails> listInvoiceFromCart = new List<InvoiceDetails>();
            Invoice invoice = new Invoice();
            bool checkOutSuccess = true; //will iterate through all books in cart, if books are not found or insufficient stock it will change to false
            decimal total = 0;
            using (Bookshop context = new Bookshop())
            {
                string invoiceId = string.Format($"INV{(context.Invoice.Count() + 1).ToString().PadLeft(5, '0')}");
                foreach (CartItem item in listCart)
                {
                    bool bookFound = context.Book.Any(x => x.ISBN == item.Isbn);
                    if (bookFound)
                    {
                        bool enoughStock = context.Book.Single(x => x.ISBN == item.Isbn).Stock >= item.Quantity;
                        if (enoughStock)
                        {
                            Book book = context.Book.First(x => x.ISBN == item.Isbn);
                            book.Stock -= 1;
                            InvoiceDetails invoiceDetail = new InvoiceDetails();
                            invoiceDetail.InvoiceID = invoiceId;
                            invoiceDetail.BookID = book.BookID;
                            invoiceDetail.Unit = item.Quantity;
                            invoiceDetail.UnitPrice = GetPrice(book.BookID);
                            invoiceDetail.DiscountAmt = GetPrice(book.BookID) - GetDiscountedPrice(book.BookID);
                            invoice.InvoiceDetails.Add(invoiceDetail);
                            context.InvoiceDetails.Add(invoiceDetail);
                            checkOutSuccess = true;
                        }
                        else
                        {
                            checkOutSuccess = false;
                            break;
                        }
                    }
                    else
                    {
                        checkOutSuccess = false;
                        break;
                    }
                }

                if (checkOutSuccess)
                {

                    invoice.InvoiceID = invoiceId;
                    invoice.InvoiceDate = DateTime.Today.Date;
                    invoice.CustomerID = customerId;
                    total = GetTotalPriceFromCart(listCart);
                    bool validCode = CheckPromoCode(promoCode);
                    if (validCode)
                    {
                        invoice.CartPromo = context.CartPromo.First(x => x.PromoCode == promoCode); //to be checked
                        invoice.PromoCode = promoCode;
                        invoice.PromoAmt = total * GetPromoPercentage(promoCode) / 100;
                        invoice.InvoiceAmt = total * (100 - GetPromoPercentage(promoCode)) / 100;
                    }
                    else
                    {
                        invoice.CartPromo = context.CartPromo.Single(x => x.PromoCode == "None");
                        invoice.PromoCode = "None";
                        invoice.PromoAmt = 0;
                        invoice.InvoiceAmt = total;
                    }

                    invoice.PaymentStatus = "Paid";
                    //context.InvoiceDetails.Add(invoiceDetail);
                    context.Invoice.Add(invoice);
                    context.SaveChanges();
                }
                return checkOutSuccess;
            }
        }

        //Get price of all books after promotion
        public static decimal GetTotalPromoPriceFromCart(List<CartItem> listCart, string promoCode)
        {
            using (Bookshop context = new Bookshop())
            {
                decimal total = GetTotalPriceFromCart(listCart);
                bool validCode = CheckPromoCode(promoCode);
                if (validCode)
                {
                    total = total * (100 - GetPromoPercentage(promoCode)) / 100m;
                }
                return total;
            }
        }

        //Get price of all books before promotion
        public static decimal GetTotalPriceFromCart(List<CartItem> listCart)
        {
            decimal total = 0;
            using (Bookshop context = new Bookshop())
            {
                foreach (CartItem item in listCart)
                {
                    Book book = context.Book.First(x => x.ISBN == item.Isbn);
                    total += GetDiscountedPrice(book.BookID)*item.Quantity;
                }
                return total;
            }
        }

        public static bool CheckPromoCode(string promoCode)
        {
            using (Bookshop context = new Bookshop())
            {
                bool foundCode = context.CartPromo.Any(x => x.PromoCode == promoCode);
                bool promoDateValid = false;
                if (foundCode)
                {
                    CartPromo cartPromo = context.CartPromo.First(x => x.PromoCode == promoCode);
                    promoDateValid = cartPromo.ValidStart.AddDays(cartPromo.PromoDuration) >= DateTime.Today;
                }
                return promoDateValid;
            }
        }

        //Get promo value of promocode
        private static short GetPromoPercentage(string promoCode)
        {
            using (Bookshop context = new Bookshop())
            {
                bool validCode = CheckPromoCode(promoCode);
                if (validCode)
                    return context.CartPromo.Single(x => x.PromoCode == promoCode).Discount;
                return 0;
            }
        }
        #endregion
    }
}
