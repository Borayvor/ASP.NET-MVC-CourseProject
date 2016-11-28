$(function () {

    tinymce.init({
        mode: "textareas",
        theme: 'modern',
        height: 150,
        plugins: [
          'advlist autolink link lists charmap hr anchor pagebreak spellchecker',
          'searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime nonbreaking',
          'save table contextmenu directionality emoticons template paste textcolor'
        ],
        toolbar: 'undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link | forecolor backcolor emoticons'
    });

    // votes
    function postVote(self, voteMethod) {
        var voteValue = self.attr("data-vote-value");
        var authorId = self.attr("data-authorId");
        var forumModelId = self.attr("data-forum-model-id");
        var form = $("#hiddenAjaxPostForm");
        var verificationToken = $('input[name="__RequestVerificationToken"]', form).val();

        var error = "Invalid vote data !";

        $.ajax({
            type: 'POST',
            url: "Votes/" + voteMethod,
            data: {
                __RequestVerificationToken: verificationToken,
                Value: voteValue,
                AuthorId: authorId,
                ModelId: forumModelId
            }
        }).done(function (data) {
            var newVoteValue = data.VotesValue;
            var element = $('[data-id="' + forumModelId + '"] .es-forum-votes');

            element.html(newVoteValue);
        }).error(error);
    }

    $(".forum-post-vote-detail-up").click(function () {
        var self = $(this);
        postVote(self, "PostVote");
    });

    $(".forum-post-vote-detail-down").click(function () {
        var self = $(this);
        postVote(self, "PostVote");
    });

    $(".forum-comment-vote-detail-up").click(function () {
        var self = $(this);
        postVote(self, "CommentVote");
    });

    $(".forum-comment-vote-detail-down").click(function () {
        var self = $(this);
        postVote(self, "CommentVote");
    });

    // comments
    $(".es-forum-comment-add-link").click(function (e) {
        e.preventDefault();
        var self = $(this);
        var targetId = "#es-forum-comment-add";
        tinymce.get("es-forum-comment-add-texarea").setContent('');
        $(targetId).collapse('show');
    });

    $(".es-forum-comment-add-close").click(function (e) {
        e.preventDefault();
        var self = $(this);
        var targetId = "#es-forum-comment-add";

        $(targetId).collapse('hide');
    });

    $(".es-forum-comment-add-save").click(function (e) {
        var self = $(this);
        var targetId = "#es-forum-comment-add";
                
        $(targetId).collapse('hide');        
    });
});