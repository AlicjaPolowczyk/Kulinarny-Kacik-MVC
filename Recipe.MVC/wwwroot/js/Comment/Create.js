$(function () {
    $("#createComment form").on('submit', function (event) {
        event.preventDefault();
        var form = $(this);
        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function () {
                LoadComments();
                form.trigger('reset');
                toastr["success"]("Pomyślnie utworzono komentarz");
                
            },
            error: function () {
                toastr["error"]("Wystąpił błąd podczas tworzenia komentarza");
            }
        });
    });
});

