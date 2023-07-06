using CarWashAlt.Context;
using CarWashAlt.Interfaces;
using CarWashAlt.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashAlt.Repositories
{
    public class RatingRepository : IRating
    {
        private CarWashAltDbContext _rating;
        public RatingRepository(CarWashAltDbContext rating)
        {
            _rating = rating;
        }
        #region Adding Rating  
        public async Task<int> AddRating(Rating rating)
        {
            try
            {
                int id = 0;
                if (rating == null)
                {
                    return id;
                }
                if (rating != null)
                {
                    var ratingnew = await _rating.Ratings.FirstOrDefaultAsync(u => u.OrderId == rating.OrderId);
                    if (ratingnew != null)
                    {
                        ratingnew.RatingsOfWasher = rating.RatingsOfWasher;
                        _rating.Ratings.Update(ratingnew);
                        await _rating.SaveChangesAsync();
                        id = ratingnew.Id;
                    }
                    else
                    {
                        await _rating.Ratings.AddAsync(rating);
                        await _rating.SaveChangesAsync();
                        id = rating.Id;
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Adding Rating


        #region Delete Rating
        public async Task<bool> DeleteRating(int id)
        {
            try
            {
                var rating = await _rating.Ratings.FindAsync(id);
                if (rating == null)
                    return false;
                _rating.Ratings.Remove(rating);
                await _rating.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Delete Rating

        #region GetAll Rating
        public async Task<double> GetAverageRating(int id)
        {
            try
            {
                double ans = 0;
                double count = 0;
                var rating = await _rating.Ratings.Where(r => r.WasherId == id).ToListAsync();
                foreach (var item in rating)
                {
                    count += item.RatingsOfWasher;
                }
                ans = count / (5 * (rating.Count));
                return ans;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion GetAll Rating



        #region Update Rating
        public async Task<bool> UpdateRating(Rating rating)
        {
            try
            {
                var rate = await _rating.Ratings.AsNoTracking().FirstOrDefaultAsync(u => u.Id == rating.Id);
                if (rate == null)
                    return false;
                _rating.Ratings.Update(rating);
                await _rating.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Update Rating

    }
}
