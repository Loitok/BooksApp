<script>
    $(document).ready(function () {
        $("#saveBook").on("click", function () {
            var bookId = $("#bookId").val();
            var bookName = $("#bookName").val();
            var bookDate = $("#bookDate").val();
            var bookPages = $("#bookPages").val();
            var bookDescription = $("#bookDescription").val();
            var action = $("#bookModal").data("action");

            var book = {
                "Id": bookId,
                "Name": bookName,
                "PublicationDate": bookDate,
                "PageCount": bookPages,
                "Description": bookDescription
            };

            $.ajax({
                type: "POST",
                url: action === "add" ? "/Books/Add" : "/Books/Edit",
                data: JSON.stringify(book),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    // Close the modal dialog
                    $("#bookModal").modal("hide");

                    // Refresh the table with the updated list of books
                    $("#bookTable").load("/Books/Index #bookTable");
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                }
            });
        });
    });
</script>