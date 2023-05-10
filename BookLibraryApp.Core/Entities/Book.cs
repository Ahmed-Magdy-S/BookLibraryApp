using System;

namespace BookLibraryApp.Core.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public uint Quantity { get; set; }
        public Guid LibraryId { get; set; }


    }
}
