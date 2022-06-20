using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore.API.IRepository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
    }
}
