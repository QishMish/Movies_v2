using Movies.Data;
using Movies.Domain.Poco;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.EF.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private IBaseRepository<Movie> _repository;

        public MovieRepository(IBaseRepository<Movie> repository)
        {
            _repository = repository;
        }


        public async Task AddAsync(Movie movie)
        {
            await _repository.AddAsync(movie);
        }

        public async Task deleteAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task editAsync(Movie movie)
        {
            await _repository.UpdateAsync(movie);
        }

        public async Task getAllAsync(Movie movie)
        {
            await _repository.GetAllAsync();
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

        public Task RemoveAsync(params object[] Key)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Movie entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
