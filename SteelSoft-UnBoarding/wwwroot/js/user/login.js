$(document).ready(function () {
    $(`body`).on(`click`, `#send`, function () {
        let login = $(`#login`).val();
        let password = $(`#password`).val();
        if (login.length == 0) {
            alert("¬ведите логин и пароль");
        }
        $.ajax({
            url: "/api/UserLogin/login",
            type: "GET",
            dataType: "JSON",
            data: {
                login: login,
                password: password
            }
        })
            .done((json) => {
                if (json.status != "ERROR") {
                    window.location.reload();
                } else {
                    alert(json.msg);
                }
            })
            .fail((ex) => {
                console.log(ex);
            });
    })
})