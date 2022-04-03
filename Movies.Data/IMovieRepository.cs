using Movies.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
    public interface IMovieRepository
    {
        Task AddAsync(Movie entity);
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetAsync(params object[] key);
        Task RemoveAsync(Movie entity);
        Task RemoveAsync(params object[] Key);
        Task UpdateAsync(Movie entity);
        Task Book(Booking entity);
        Task Purchase(Purchase entity);
        Task DeleteBooking(Booking entity);
        Task DeletePurchase(Purchase entity);
        Task<List<Movie>> GetAllFullAsync();
    }
}
