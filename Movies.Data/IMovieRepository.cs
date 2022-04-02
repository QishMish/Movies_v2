using Movies.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
    public interface IMovieRepository
    {
        //Task Book(int userId, int movieId);
        //Task Purchase(int userId, int movieId);
        public Task AddAsync(Movie entity);
        public Task<List<Movie>> GetAllAsync();

        public Task<Movie> GetAsync(params object[] key);

        public Task RemoveAsync(Movie entity);

        public Task RemoveAsync(params object[] Key);

        public Task UpdateAsync(Movie entity);
        public Task Book(Booking entity);
        public Task Purchase(Purchase entity);
        public Task DeleteBooking(Booking entity);
        public Task DeletePurchase(Purchase entity);
    }
}
