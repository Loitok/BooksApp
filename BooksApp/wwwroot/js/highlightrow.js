<script>
    $(document).ready(function () {
        function highlightRow(row) {
            var current = document.getElementsByClassName("active");
            if (current.length > 0) {
                current[0].className = current[0].className.replace(" active", "");
            }
            row.className += " active";
        }
    }
</script>
