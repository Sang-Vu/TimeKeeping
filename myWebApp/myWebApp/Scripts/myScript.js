//for login form
/*
$('#userID').focus(function () {
    $("#alertForLogin").hide();
}); 
$('#pass').focus(function () {
    $("#alertForLogin").hide();
}); 
*/
/*for dialog box*
$('#pass').keyup(function () {
    $('#modal').show();
    //document.getElementById('content').innerHTML = "heelo";
    $('#content').text('hellosasdf');
});
$('#button_hide_modal').click(function () {
    $('#modal').hide();
});
*/

/*for show name in add new admin in grantAdmin*/
$('#adminID-grantAdmin').keyup(function () {
    var userID = $('#adminID-grantAdmin').val();
    if (userID.length < 4 || userID.length > 4) { $('#name-grantAdmin').val(''); return; }
    $.ajax({
        type: 'GET',
        url: '/Member/GetDetailsByUserId/' + userID,
        contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        processData: false,
        cache: false,
        //data: JSON.stringify({ id: userID }),
        success: function (respone) {
            var res = JSON.parse(JSON.stringify(respone));
            $('#name-grantAdmin').val(res.name);
        },
        error: function (xhr) {
            $('#name-grantAdmin').val('');
        }
    });
});

/*hidden alert when focus ID input*/
$('#adminID-grantAdmin').focus(function () {
    $('#alertSpan').hide();
});

/*for add user to admin list*/
$('#addUser-grantAdmin').click(function () {
    var userName = $('#name-grantAdmin').val();
    if (userName == '') { $('#alertSpan').show(); return; }
    var userID = $('#adminID-grantAdmin').val();
    $.ajax({
        type: 'POST',
        url: '/Member/AddUserToAdmin',
        contentType: 'application/json; charset=utf-8',
        datatype: 'json',
        processData: false,
        cache: false,
        data: JSON.stringify({ id: userID}),
        success: function (respone) {
            var res = JSON.parse(JSON.stringify(respone));
            if (res.Code == 1) { alert('Can not add user to Admin'); return; }
            window.location.href = '/Member/GrantAdmin';
        },
        error: function (xhr) {
            alert('Error');
        }
    });
});

/*delete user from admin list*/
$('#delUser-grantAdmin').click(function () {
    var userID = $('#delUser-grantAdmin').val();
    alert(userID);
});
