$(document).ready(function () {
    $(".school").click(function () {
        console.log($(this).attr("schoolID"));
        $.ajax({
            data: {
                schoolID: $(this).attr("schoolID")
            },
            url: '/Schools/SchoolCourses',
            type: 'POST',
            dataType: 'html'
        }).done(function (result) {
            $("#bg-wrap").css("display", "block");
            $("#school-courses").css("display", "block");
            $("#school-courses").html(result);
        })
    });

    $("#bg-wrap").click(function () {
        $("#school-courses").css("display", "none");
        $(this).css("display", "none");
    });
});