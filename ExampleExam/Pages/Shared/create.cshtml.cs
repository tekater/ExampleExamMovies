using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleExam.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;

        [BindProperty]
        public Movie Movie { get; set; }

        public CreateModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _movieRepository.Add(Movie);
            return RedirectToPage("./Index");
        }
    }
}