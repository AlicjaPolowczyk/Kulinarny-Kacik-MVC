$(function () {
    LoadSteps();
    $("#createStepModal form").on('submit', function (event) {
        event.preventDefault();
        const formData = new FormData(this);
        
        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: formData,
            contentType: false,
            processData: false,
            success: function () {
                LoadSteps();
                toastr["success"]("Pomyślnie utworzono krok");
            },
            error: function () {
                toastr["error"]("Wystąpił błąd podczas tworzenia kroku");
            }
        });
    });
});
