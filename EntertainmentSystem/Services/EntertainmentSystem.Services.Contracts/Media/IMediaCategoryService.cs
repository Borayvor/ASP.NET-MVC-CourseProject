namespace EntertainmentSystem.Services.Contracts.Media
{
    using System.Linq;
    using EntertainmentSystem.Data.Models.Media;

    public interface IMediaCategoryService
    {
        /// <summary>
        /// Get all categories. Without ordinary deleted.
        /// </summary>
        /// <returns>Categories as queryable.</returns>
        IQueryable<MediaCategory> GetAll();

        /// <summary>
        /// Gets the category by id.
        /// </summary>
        /// <param name="id">The id of the category to get.</param>
        /// <returns>Category as class.</returns>
        MediaCategory GetById(int id);

        /// <summary>
        /// Gets the category by name.
        /// </summary>
        /// <param name="name">The name of the category to get.</param>
        /// <returns>Category as class.</returns>
        MediaCategory GetByName(string name);

        /// <summary>
        /// Create new category.
        /// </summary>
        /// <param name="category">Category to be created.</param>
        void Create(MediaCategory category);

        /// <summary>
        /// Update category.
        /// </summary>
        /// <param name="category">Category to be updated.</param>
        void Update(MediaCategory category);

        /// <summary>
        /// Delete category. Not permanent.
        /// </summary>
        /// <param name="category">Category to be deleted.</param>
        void Delete(MediaCategory category);
    }
}
