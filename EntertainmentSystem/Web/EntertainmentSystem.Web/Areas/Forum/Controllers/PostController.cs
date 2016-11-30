namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Common.Constants;
    using Common.Enums;
    using Data.Models.Forum;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Contracts.Forum;
    using ViewModels;
    using Web.Controllers;

    public class PostController : BaseController
    {
        private const string Separator = ", ";

        private readonly IForumPostService postService;
        private readonly IForumCommentService commentService;
        private readonly IForumCategoryService categoryService;
        private readonly IForumTagService tagService;

        public PostController(
            IForumPostService postService,
            IForumCommentService commentService,
            IForumCategoryService categoryService,
            IForumTagService tagService)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.categoryService = categoryService;
            this.tagService = tagService;
        }

        [HttpGet]
        public ActionResult Index(Guid postId, int page = GlobalConstants.ForumStartPage)
        {
            var result = this.ConditionalActionResult(
                () => this.GetPostWithCommentsPage(postId, page),
                (content) => this.View(content));

            return result;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            this.TagsAndPostCategorieViewBag();

            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.TagsAndPostCategorieViewBag();

                return this.View();
            }

            ICollection<Tag> tags = new Collection<Tag>();

            if (!string.IsNullOrEmpty(model.Tags))
            {
                var modelTags = model.Tags.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var tagName in modelTags)
                {
                    tags.Add(this.tagService.GetByName(tagName));
                }
            }

            var newPost = new Post
            {
                AuthorId = this.User.Identity.GetUserId(),
                Title = model.Title,
                Content = model.Content,
                PostCategoryId = model.CategoryId,
                Tags = tags
            };

            this.postService.Create(newPost);

            return this.RedirectToAction<AllPostsController>(c => c.Index(
                GlobalConstants.ForumStartPage,
                GlobalConstants.StringEmpty));
        }

        private PostCommentsPageViewModel GetPostWithCommentsPage(
            Guid postId,
            int page)
        {
            var post = this.Mapper.Map<PostViewModel>(this.postService.GetById(postId));

            int pagesToSkip = (page - 1) * GlobalConstants.ForumCommentsPerPage;

            int totalpages = (int)Math.Ceiling(post.Comments.Count() / (decimal)GlobalConstants.ForumCommentsPerPage);

            // TODO: refactor -> use commentService
            var result = post.Comments
                .OrderByDescending(c => c.CreatedOn)
                .Skip(pagesToSkip)
                .Take(GlobalConstants.ForumCommentsPerPage)
                .ToList();

            post.Comments = result;

            var newViewModel = new PostCommentsPageViewModel
            {
                Post = post,
                CurrentPage = page,
                TotalPages = totalpages
            };

            return newViewModel;
        }

        private void TagsAndPostCategorieViewBag()
        {
            var categories = this.categoryService
                .GetAll(EntityOrderBy.NameProperty)
                .To<PostCategoryViewModel>()
                .ToList();

            var tags = this.tagService
               .GetAll(EntityOrderBy.NameProperty)
               .Select(x => x.Name)
               .ToArray();

            this.ViewBag.Categories = new SelectList(categories, "Id", "Name");
            this.ViewBag.Tags = tags;
        }
    }
}
