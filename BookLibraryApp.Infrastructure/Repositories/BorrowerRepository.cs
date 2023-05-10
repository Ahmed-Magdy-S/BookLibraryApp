using BookLibraryApp.Core.Entities;
using BookLibraryApp.Core.IdentityEntities;
using BookLibraryApp.Core.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Infrastructure.Repositories
{
    public class BorrowerRepository : IBorrowerRepository
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<BorrowerRepository> _logger;

        public BorrowerRepository(ApplicationDbContext dbContext, ILogger<BorrowerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IReadOnlyList<AppUser>> GetAllBorrowersByBookId(Guid bookId)
        {
            //The same book type so that we can know who borrows it
            List<BorrowedBook> borrowedBooks = await _dbContext.BorrowedBooks.Where(x => x.BookId == bookId).ToListAsync();
            List<AppUser> borrowers = new();
            foreach (var borrowedBook in borrowedBooks)
            {
                //Send query to get each user for each borrowedBook
                borrowers.Add(await _dbContext.Users.FindAsync(borrowedBook.Id));
            }
            return borrowers;

        }


        public async Task<string> BorrowBookFromLibrary(Guid bookId, Guid borrowerId)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                Book book = await _dbContext.Books.FindAsync(bookId);
                if (book == null)
                {
                    _logger.LogError($"From Repository -- Book Id: {bookId}");
                    throw new InvalidOperationException("Book not found");
                }

                var isBorrowedBefore = await _dbContext.BorrowedBooks.FirstOrDefaultAsync(x=>x.BookId == bookId);
                _logger.LogInformation($"isBorrowedBefore != null {isBorrowedBefore != null}");
                if (isBorrowedBefore != null) throw new InvalidOperationException("You have already borrowed this book");


                BorrowedBook borrowedBook = new(){BookId = bookId, BorrowerId = borrowerId};

                //update book quantity
                if (book.Quantity > 0) book.Quantity--;
                else throw new InvalidOperationException("There is no enough book quantity");
                

                //Add book to borrowed book
                await _dbContext.BorrowedBooks.AddAsync(borrowedBook);

                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return "The borrowing process is done successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> ReturnBookToLibrary(Guid bookId, Guid borrowerId)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                var book = await _dbContext.Books.FindAsync(bookId);
                if (book == null) throw new InvalidOperationException("The book is not belong to this library");

                var borrowedBook = await _dbContext.BorrowedBooks.FirstOrDefaultAsync(x=>x.BookId == bookId && x.BorrowerId == borrowerId);
                if (borrowedBook == null) throw new InvalidOperationException("Borrowed book not found, you didn't borrow this book");
                
                //Remove book to borrowed book
                _dbContext.BorrowedBooks.Remove(borrowedBook);

                //Update book quantity
                book.Quantity++;

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return "you have returned back the book successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
    }
}
