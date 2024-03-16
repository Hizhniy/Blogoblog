using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Blogoblog.DAL.Models;
using Blogoblog.DAL.Repositories;


namespace Blogoblog.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly IRepository<Article> _repo;
        private readonly IRepository<Tag> _tagRepo;
        private readonly IRepository<User> _userRepo;
        private readonly ILogger<ArticlesController> _logger;

        public ArticlesController(IRepository<Article> repo, IRepository<Tag> tag_repo, IRepository<User> user_repo, ILogger<ArticlesController> logger)
        {
            _repo = repo;
            _tagRepo = tag_repo;
            _userRepo = user_repo;
            _logger = logger;
            _logger.LogDebug(1, "NLog подключен к ArtController");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await _repo.GetAll();
            _logger.LogInformation("ArticlesController - Index");
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> AddArticle()
        {
            var tags = await _tagRepo.GetAll();
            _logger.LogInformation("ArticlesController - Add");
            return View(new AddArticleViewModel() { Tags = tags.ToList() });
        }

        //[HttpPost]
        //public async Task<IActionResult> AddArticle(Article newArticle)
        //{
        //    // Получаем логин текущего пользователя из контекста сессии
        //    string? currentUserLogin = User?.Identity?.Name;
        //    var user = _userRepo.GetByLogin(currentUserLogin);
        //    newArticle.User_Id = user.Id;
        //    newArticle.User = user;
        //    newArticle.Article_Date = DateTimeOffset.UtcNow;
        //    await _repo.Add(newArticle);
        //    _logger.LogInformation("ArticlesController - Add - complete");
        //    return View(newArticle);
        //}

        [HttpPost]
        public async Task<IActionResult> AddArticle(AddArticleViewModel model)
        {
            // Получаем логин текущего пользователя из контекста сессии
            string? currentUserLogin = User?.Identity?.Name;
            var user = _userRepo.GetByLogin(currentUserLogin);

            var article = new Article
            {
                User_Id = user.Id,
                User = user,
                Article_Date = DateTimeOffset.UtcNow,
                Title = model.Title,
                Content = model.Content,
                Tags = model.Tags
            };

            await _repo.Add(article);
            _logger.LogInformation("ArticlesController - Add - complete");
            return View(article);
        }

        [HttpGet]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _repo.Get(id);
            _logger.LogInformation("ArticlesController - GetArticleById");
            return View(article);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            _logger.LogInformation("ArticlesController - Delete");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await _repo.Get(id);
            await _repo.Delete(article);
            _logger.LogInformation("ArticlesController - Delete - complete");
            return RedirectToAction("Index", "Articles");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var article = await _repo.Get(id);
            _logger.LogInformation("ArticlesController - Update");
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmUpdating(Article article)
        {
            string? currentUserLogin = User?.Identity?.Name;
            var user = _userRepo.GetByLogin(currentUserLogin);

            article.User_Id = user.Id;
            article.User = user;
            await _repo.Update(article);
            _logger.LogInformation("ArticlesController - Update - complete");
            return RedirectToAction("Index", "Articles");
        }
    }
}
