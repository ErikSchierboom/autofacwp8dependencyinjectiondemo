namespace AutofacWP8DependencyInjectionDemo
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// The view model for the movies page. It contains a collection of <see cref="MovieViewModel"/> instances
    /// </summary>
    public class MoviesViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesViewModel"/> class.
        /// </summary>
        public MoviesViewModel()
        {
            // Populate our collection of movies with default values
            this.Movies = new Collection<MovieViewModel>
                             {
                                 new MovieViewModel { Title = "Se7en", Director = "David Fincher" },
                                 new MovieViewModel { Title = "12 Angry Men", Director = "Sidney Lumet" },
                                 new MovieViewModel { Title = "Inception", Director = "Christoper Nolan" },
                                 new MovieViewModel { Title = "The Matrix", Director = "The Wachowski Brothers" },
                                 new MovieViewModel { Title = "Jurassic Park", Director = "Steven Spielberg" },
                                 new MovieViewModel { Title = "Back to the Future", Director = "Robert Zemeckis" }
                             };
        }


        /// <summary>
        /// Gets the movies.
        /// </summary>
        /// <value>
        /// The movies.
        /// </value>
        public ICollection<MovieViewModel> Movies { get; private set; }
    }
}