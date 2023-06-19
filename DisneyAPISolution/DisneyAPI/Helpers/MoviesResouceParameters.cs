using System.ComponentModel.DataAnnotations;

namespace DisneyAPI.Helpers
{
    public class MoviesResouceParameters
    {
        const int maxPageSize = 20;

        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;

            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

 

        /// <summary>
        /// Filter by Genre
        /// </summary>
        public string? Genre { get; set; }


        /// <summary>
        /// Search by name
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// OrderBy CreationDate
        /// </summary>
        public string CreationDate { get; set; } = "ASC";
    }
}
