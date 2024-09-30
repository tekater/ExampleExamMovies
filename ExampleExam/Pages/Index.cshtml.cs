using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleExam.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Collections.Generic;

    namespace ExampleExam.Pages
    {
        public class IndexModel : PageModel
        {
            private readonly IMovieRepository _movieRepository;

            public IList<Movie> Movies { get; private set; }

            public IndexModel(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public void OnGet()
            {
                Movies = _movieRepository.GetAll().ToList();
            }
        }
}
}
