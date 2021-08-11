function Login() {
    var Username = $("#UserName").val();
    var Password = $("#Password").val();
    if (Username == "tfladmin" && Password == "Tfl@Vsl2021#1") {
        location.href = "../ReportUpload/ReportUpload";
        return false;
    }
    else if (Username=="") {
        swal("Incorrect Username");
        return false;
    }
    else if (Password == "") {
        swal("Incorrect Password");
        return false;
    }
    else {
        swal("Incorrect Username and Password");
        $("#UserName").val("");
        $("#Password").val("");
        return false;
    }

    
}