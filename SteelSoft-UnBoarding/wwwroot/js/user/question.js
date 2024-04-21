//$.ajax({
//    url: "/api/question/",
//    data: {
//        id_question: ""
//    }
//});

$(document).ready(function () {
    $(`body`).on(`click`, `#accept_con`, function () {
        let id = $(`#accept_con`).attr(`id-question`);
        $.ajax({
            url: "/api/TaskQuest/Complite",
            data: {
                id_question: id
            },
            dataType: "JSON",
            type: "GET"
        })
            .done((json) => {
                console.log(json);
            })
    })
});