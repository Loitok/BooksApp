
    $(document).ready(function () {
        $("#saveBook").on("click", function () {
            var bookId = $("#bookId").val();
            var bookName = $("#bookName").val();
            var bookDate = $("#bookDate").val();
            var bookPages = $("#bookPages").val();
            var bookDescription = $("#bookDescription").val();

            var book = {
                "Id": bookId,
                "Title": bookName,
                "PublicationDate": bookDate,
                "PageCount": bookPages,
                "Description": bookDescription
            };

            console.log(book);

            $.ajax({
                type: "POST",
                url: "/Books/PostBook",
                data: book,
                contentType: "application/x-www-form-urlencoded",
                success: function (data) {
                    $("#bookModal").modal("hide");

                    $("#bookTable").load("/Books/GetBooks #bookTable");
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                }
            });
        });
    });
