
$(document).ready(function () {
    $("#search").focusin(function () {
        $(this).animate({
            width: '160px',
            height: '40px',
        }, "slow")
        $('#searchback').animate({
            width: '160px',
            height: '50px'
        }, "slow")
    });
    $("#search").focusout(function () {
        $(this).animate({
            width: '60px',
            height: '40px'
        }, "slow")
        $('#searchback').animate({
            width: '80px',
            height: '50px'
        }, "slow")
    });
    $("#btnComment").click(function () {
        var id = "ABC";
        var booksDiv = $("#bodySection");
        $.ajax({
            cache: false,
            type: "POST",
            url: "Base/Comment",
            data: { "comment": id },
            success: function (data) {
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve books.');
            }
        });
    });
});

$('#search').keypress(function (e) {
    if (e.keyCode == '13') {
        var name = $(this).val();
        var div = document.getElementsByClassName("home-post")

        $(document).find(".home-post").hide();
        for (var i = 0; i < div.length; i++) {
            var para = div[i].getElementsByClassName("home-post-heading");
            var index = para[0].innerText.toLowerCase().indexOf(name);
            if (index != '-1') {
                $(document).find(div[i]).show();
            }
        }
    }
});