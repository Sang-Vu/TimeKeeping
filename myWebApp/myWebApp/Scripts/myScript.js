//for login form
$('#userID').focus(function () {
    $("#alertForLogin").hide();
}); 
$('#pass').focus(function () {
    $("#alertForLogin").hide();
}); 

/*for dialog box*/
$('#pass').keyup(function () {
    $('#modal').show();
    //document.getElementById('content').innerHTML = "heelo";
    $('#content').text('hellosasdf');
});
$('#button_hide_modal').click(function () {
    $('#modal').hide();
});

