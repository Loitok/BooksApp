
    $(document).ready(function () {
        $("tr").click(function () {
            $("tr.active").removeClass("active");
            $(this).addClass("active");
        });
    });
