
    $(document).ready(function () {
        $("#searchInput").on("keyup", function () {
            var value = $(this).val().toLowerCase();
            $.ajax({
                url: "/Books/SearchBooks",
                type: "GET",
                data: { searchString: value },
                success: function (result) {
                    $("tbody").empty();
                    $.each(result, function (i, book) {
                        $("tbody").append("<tr id='" + book.id + "' onclick='highlightRow(this)'><td>" + book.id + "</td><td>" + book.title + "</td><td>" + book.description + "</td><td>" + book.publicationDate + "</td><td>" + book.pageCount + "</td></tr>");
                    });
                },
                error: function () {
                    alert("Error occurred while searching for books.");
                }
            });
        })});
