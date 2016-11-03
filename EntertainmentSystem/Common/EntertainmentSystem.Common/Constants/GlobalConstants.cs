namespace EntertainmentSystem.Common.Constants
{
    public class GlobalConstants
    {
        public const string StringEmpty = "";

        public const string AdministratorRoleName = "Administrator";
        public const string AdministratorAreaName = "Administration";

        public const string ModeratorRoleName = "Moderator";
        public const string ModeratorAreaName = "Moderators";

        public const string ForumAreaName = "Forum";

        public const string MediaAreaName = "Media";

        public const int PasswordMinLength = 3;

        public const int HomeLastContentCount = 3;

        public const int CacheMediaHomeDuration = 60 * 5; // 5 min.

        public const int UserFirstNameMinLength = 2;
        public const int UserFirstNameMaxLength = 100;
        public const int UserLastNameMinLength = 2;
        public const int UserLastNameMaxLength = 100;
        public const int UserUsernameMinLength = 2;
        public const int UserUsernameMaxLength = 256;
        public const int UserAvatarImageUrlMaxLength = 1024;
        public const int UserEmailMaxLength = 256;

        public const int MediaCategoryNameMinLength = 1;
        public const int MediaCategoryNameMaxLength = 512;

        public const int MediaCollectionNameMinLength = 1;
        public const int MediaCollectionNameMaxLength = 512;

        public const int MediaContentTitleMinLength = 1;
        public const int MediaContentTitleMaxLength = 256;
        public const int MediaContentDescriptionMaxLength = 2000;
        public const int MediaContentContentUrlMinLength = 1;
        public const int MediaContentContentUrlMaxLength = 1024;
        public const int MediaContentCoverImageUrlMaxLength = 1024;

        public const int PostTitleMinLength = 2;
        public const int PostTitleMaxLength = 256;
        public const int PostContentMinLength = 2;
        public const int PostContentMaxLength = 2000;

        public const int PostCategoryNameMinLength = 1;
        public const int PostCategoryNameMaxLength = 512;

        public const int PostCommentContentMinLength = 2;
        public const int PostCommentContentMaxLength = 2000;

        public const int PostTagNameMinLength = 2;
        public const int PostTagNameMaxLength = 50;
    }
}
