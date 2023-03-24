<script>
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
                        $("tbody").append("<tr id='" + book.Id + "' onclick='highlightRow(this)'><td>" + book.Name + "</td><td>" + book.PublicationDate + "</td><td>" + book.PageCount + "</td></tr>");
                    });
                },
                error: function () {
                    alert("Error occurred while searching for books.");
                }
            });
        })});
</script>