function SendEmail() {
    var name = $('#name').val();
    var email = $('#email').val();
    var subject = $('#subject').val();
    var Message = $('#message').val();

    var Status;
    $.ajax({
        type: "POST",
        url: "/Transwarranty/SendMail",
        data: { Name: name, Email: email, Subject: subject, Message: Message },
        success: function (response) {
            swal({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Message as been send successfully',
                        showConfirmButton: false,
                        timer: 1500
                    })
        },
        error: function (response) {
            alert(JSON.stringify(response));
        }
    });
}