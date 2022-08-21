using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookKeeping.Models;

namespace BookKeeping.Data
{
    public class BookKeepingContext : DbContext
    {
        public BookKeepingContext (DbContextOptions<BookKeepingContext> options)
            : base(options)
        {
        }

        public DbSet<BookKeeping.Models.BookModel> BookModel { get; set; } = default!;
    }
}
