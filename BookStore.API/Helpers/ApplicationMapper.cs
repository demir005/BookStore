using AutoMapper;
using BookStore.API.Models;

namespace BookStore.API.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BooksModel>().ReverseMap();
        }
    }
}
