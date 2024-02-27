$(function () {
    $(".deleteButtonClass").on('click', function (event) {
        const recipeEncodedTitle = $(this).data('encodedTitle');
        $.ajax(
            {
                url: `Recipe/${recipeEncodedTitle}/Delete`,
                type: 'delete',
                success: function () {
                   
                    toastr["success"]("Pomyślnie usunięto przepis");
                    setTimeout(function () {
                        window.location.href = '/Recipe';
                    }, 1000);
                },
                error: function () {
                    toastr["error"]("Wystąpił błąd podczas usuwania przepisu");
                }
            }
        )
    });

});