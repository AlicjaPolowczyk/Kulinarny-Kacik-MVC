const RenderSteps = function (div, steps) {
    div.empty();
    let i = 1;
    for (const step of steps) {
        div.append(
            `<div class="step shadow p-3 mb-5 rounded">
                <div class="title-step">
                    <p style="font-size:2rem;font-weight: bold">Krok ${i}</p>
                    <img src="/steps/${step.imagePath}">
                </div>
                <div class="description-step"">
                    <div class="text">${step.description}</div>
                </div>
            </div>`
       
        )
        i = i + 1;
    }
}


const LoadSteps = () => {
    const div = $('#steps');
    const recipeEncodedTitle = div.data('recipe-encoded-title');
    $.ajax(
        {
            url: `/Recipe/${recipeEncodedTitle}/Steps`,
            type: 'get',
            success: function (steps) {
                if (!steps.length) {
                    div.html("Brak instrukcji");
                }
                else {
                    RenderSteps(div, steps);
                };
                
            },
            error: function () {
                toastr["error"]("Wystąpił bład podczas załadowania sekcji kroków");
            }
        }
    )

}
const RenderComments = function (div, comments) {
    div.empty();

    for (const comment of comments) {
        div.append(
            `<div class="comment ">
                <div class="user">
                    <div>${comment.userName}</div>
                </div>
                <div class="opinion" style="word-wrap: break-word;">
                    <div class="text">${comment.description}</div>
                </div>
            </div>`
        )
    }
}
const LoadComments = () => {
    const div = $('#allComments');
    const recipeEncodedTitle = div.data('recipe-encoded-title');
    $.ajax(
        {
            url: `/Recipe/${recipeEncodedTitle}/Comments`,
            type: 'get',
            success: function (comments) {
                if (!comments.length) {
                    div.html("Brak komentarzy");
                }
                else {
                    RenderComments(div, comments);
                };

            },
            error: function () {
                toastr["error"]("Wystąpił bład podczas załadowania sekcji komentarzy");
            }
        }
    )
}

