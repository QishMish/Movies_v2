using Movies.Data;
using Movies.Domain.Poco;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movies.EF.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private IBaseRepository<Movie> _repository;
        private IBaseRepository<Booking> _repositoryBooking;
        private IBaseRepository<Purchase> _repositoryPurchase;

        public MovieRepository(IBaseRepository<Movie> repository, IBaseRepository<Booking> repositoryBooking, IBaseRepository<Purchase> repositoryPurchase)
        {
            _repository = repository;
            _repositoryBooking = repositoryBooking;
            _repositoryPurchase = repositoryPurchase;
        }

        public async Task AddAsync(Movie movie)
        {
            await _repository.AddAsync(movie);
        }
        public async Task Book(Booking entity)
        {
            await _repositoryBooking.AddAsync(entity);
        }
        public async Task Purchase(Purchase entity)
        {
            await _repositoryPurchase.AddAsync(entity);
        }
        public async Task<List<Movie>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Movie> GetAsync(params object[] key)
        {
            var movie = await _repository.GetAsync(key);
            return movie;
        }
        public async Task getSpecificAsync(int id)
        {
            await _repository.GetAsync(id);

        }
        public async Task RemoveAsync(Movie entity)
        {
            await _repository.RemoveAsync(entity);
        }
        public async Task RemoveAsync(params object[] Key)
        {
            await _repository.RemoveAsync(Key);
        }
        public async Task UpdateAsync(Movie entity)
        {
            await _repository.UpdateAsync(entity);
        }
        public async Task DeleteBooking(Booking entity)
        {
            await _repositoryBooking.RemoveAsync(entity);
        }
        public async Task DeletePurchase(Purchase entity)
        {
            await _repositoryPurchase.RemoveAsync(entity);
        }
        public async Task<List<Movie>> GetAllFullAsync()
        {
            return await _repository.Table.Include(x => x.User).ThenInclude(x => x.Booking).ToListAsync();

        }
        //public async Task deleteAsync(int id)
        //{
        //    await _repository.RemoveAsync(id);
        //}
        //public async Task editAsync(Movie movie)
        //{
        //    await _repository.UpdateAsync(movie);
        //}
        //public async Task getAllAsync(Movie movie)
        //{
        //    await _repository.GetAllAsync();
        //}
        //public async Task RemoveAsync(Booking entity)
        //{
        //    await _repository.RemoveAsync(entity);

        //}
        //public async Task RemoveAsync(Purchase entity)
        //{
        //    await _repository.RemoveAsync(entity);

        //}
    }
}
