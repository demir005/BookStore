using BookStore.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class BookStoreContex : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContex(DbContextOptions<BookStoreContex> options)
            : base(options)
        {

        }
        public DbSet<Books> Books { get; set; }

    }
}
