
namespace DisneyAPI.Helpers
{
    public class CharactersResourceParameters
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
        /// Filter by age
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Filter by Weight
        /// </summary>
        public float? Weight { get; set; }

        /// <summary>
        /// Filter by Movies or Series
        /// </summary>
        public string? MoviesOrSeries { get; set; }


        /// <summary>
        /// Search by name
        /// </summary>
        public string? Name { get; set; }

        //public string OrderBy { get; set; } = "Name";
    }
}
