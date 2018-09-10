
User = {};

var authenticate = () => {
    var username = $("#username").val();
    var password = $("#password").val();

    User.UserName = username;
    User.Password = password;

    ajaxCall(User);
};

var appendData = (response) => {
    $("#showResponse").append("<p>" + response.Id + "</p>")
}

var ajaxCall = (User) => {

    $.ajax({
        url: "/api/authenticate",
        data: JSON.stringify(User),
        type: 'POST',
        contentType: 'application/json',
        //crossDomain: true,
        dataType: 'json',        
        success: function (result) {
            if (result.UserType === 0) {
                console.log("Admin done");
                console.log(result);
                window.location.href = "AdminView.html";
            }
            else{
                console.log("client Login done");
                console.log(result);
                window.location.href = "UserView.html";
            }
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => { appendData(response) });
};