using Movies.Data;
using Movies.Domain.Poco;
using Movies.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Implementations
{
    public class MoviesService : IMoviesService
    {
        private IMovieRepository _repo;

        public MoviesService(IMovieRepository repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(Movie entity)
        {
            await _repo.AddAsync(entity);
        }
        public async Task<List<Movie>> GetAllAsync()
        {
           return await _repo.GetAllAsync();

        }
        public async Task<Movie> GetAsync(params object[] key)
        {
            return await _repo.GetAsync(key);
        }
        public async Task Purchase(Purchase entity)
        {
            await _repo.Purchase(entity);
        }
        public async Task Book(Booking entity)
        {
            await _repo.Book(entity);
        }
        public async Task RemoveAsync(Movie entity)
        {
            await _repo.RemoveAsync(entity);
        }
        public async Task RemoveAsync(params object[] Key)
        {
            await _repo.RemoveAsync(Key);
        }
        public async Task UpdateAsync(Movie entity)
        {
            await _repo.UpdateAsync(entity);

        }
        public async Task DeleteBooking(Booking entity)
        {
            await _repo.DeleteBooking(entity);
        }
        public async Task DeletePurchase(Purchase entity)
        {
            await _repo.DeletePurchase(entity);

        }

        public async Task<List<Movie>> GetAllFullAsync()
        {
            return await _repo.GetAllFullAsync();
        }

        public Task<bool> IsBooked(Booking entity)
        {
            return _repo.IsBooked(entity.User_id, entity.Movie_id);
        }

        public Task<bool> IsPurchased(Purchase entity)
        {
            return _repo.IsPurchased(entity.User_id, entity.Movie_id);

        }
    }
}
