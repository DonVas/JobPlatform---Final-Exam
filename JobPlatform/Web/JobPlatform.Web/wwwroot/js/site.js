// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById("filePicture").onchange = function() {
    document.getElementById("formPicture").submit();
}

function changeRole(userId, roleId, onOff) {
    var token = $("#userForm input[name=__RequestVerificationToken]").val();
    var json = { userId: userId, roleId: roleId, onOff: onOff };

    $.ajax({
        url: "/api/role",
        type: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: $.ready.then.call(reresh())

    });

    function reresh() {
        setTimeout(function () {// wait for 5 secs(2)
            location.reload(); // then reload the page.(3)
        }, 1000);
    }
}
