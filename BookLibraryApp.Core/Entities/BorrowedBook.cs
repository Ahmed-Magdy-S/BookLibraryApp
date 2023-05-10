using System;

namespace BookLibraryApp.Core.Entities
{
    public class BorrowedBook
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid BorrowerId { get; set; }
    }
}
