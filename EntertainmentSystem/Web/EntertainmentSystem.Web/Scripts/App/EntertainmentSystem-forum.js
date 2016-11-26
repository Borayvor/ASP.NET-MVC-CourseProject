$(function () {
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
});