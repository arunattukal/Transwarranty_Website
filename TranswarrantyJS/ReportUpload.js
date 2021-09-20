function noBack() {
    window.history.forward();
}
function Logout() {
    location.href = "../Transwarranty/Admin";
    return false;
}

function FileUpload() {
    var fileName = $('input[type=file]').val().split('\\').pop();
    $(".input-file__info").text(fileName);
}
function ReportType() {
    var ReportType = $("#RptType").val();
    var Sub_cat = $("#SharePattern").val();
    if (ReportType == "financial") {
        $("#div_SharePattern").hide();
        $("#div_FinPattern").show();
        $("#div_Year").show();
        $("#div_RptCaption").show();
        $("#div_Period").show();
        $("#div_Annual").hide();
        $("#div_RptName").hide();
    }
    else if (ReportType == "annual") {
        $("#div_SharePattern").hide();
        $("#div_FinPattern").hide();
        $("#div_Year").show();
        $("#div_RptCaption").show();
        $("#div_Period").hide();
        $("#div_Annual").show();
        $("#div_RptName").hide();
    }
    else if (ReportType == "AgmAndEgm") {
        $("#div_SharePattern").hide();
        $("#div_FinPattern").hide();
        $("#div_Year").show();
        $("#div_RptCaption").show();
        $("#div_Period").hide();
        $("#div_Annual").hide();
        $("#div_RptName").show();
    }
    else if (ReportType == "shareholder") {
        if (Sub_cat == "corporategovernance") {
            $("#div_SharePattern").show();
            $("#div_FinPattern").hide();
            $("#div_Year").show();
            $("#div_RptCaption").show();
            $("#div_Period").show();
            $("#div_Annual").hide();
        }
        else if (Sub_cat == "investorcomplaints") {
            $("#div_SharePattern").show();
            $("#div_FinPattern").hide();
            $("#div_Year").show();
            $("#div_RptCaption").show();
            $("#div_Period").show();
            $("#div_Annual").hide();
        }
        else if (Sub_cat == "boardmeeting") {
            $("#div_SharePattern").show();
            $("#div_FinPattern").hide();
            $("#div_Year").show();
            $("#div_RptCaption").show();
            $("#div_Period").hide();
            $("#div_Annual").hide();
            $("#div_RptName").show();
        }
    }
    else if (ReportType == "stockexchange") {
        $("#div_SharePattern").hide();
        $("#div_FinPattern").hide();
        $("#div_Year").show();
        $("#div_RptCaption").show();
        $("#div_Period").hide();
        $("#div_Annual").hide();
        $("#div_RptName").show();
    }
    else if (ReportType == "materialevents") {
        $("#div_SharePattern").hide();
        $("#div_FinPattern").hide();
        $("#div_Year").show();
        $("#div_RptCaption").show();
        $("#div_Period").hide();
        $("#div_Annual").hide();
        $("#div_RptName").show();
    }
    else if (ReportType == "unclaimeddividend") {
        $("#div_SharePattern").hide();
        $("#div_FinPattern").hide();
        $("#div_Year").hide();
        $("#div_RptCaption").show();
        $("#div_Period").hide();
        $("#div_Annual").hide();
        $("#div_RptName").show();
    }
    else if (ReportType == "policies") {
        $("#div_SharePattern").hide();
        $("#div_FinPattern").hide();
        $("#div_Year").hide();
        $("#div_RptCaption").show();
        $("#div_Period").hide();
        $("#div_Annual").hide();
        $("#div_RptName").show();
    }
    else if (ReportType == "grievances") {
        $("#div_SharePattern").hide();
        $("#div_FinPattern").hide();
        $("#div_Year").hide();
        $("#div_RptCaption").show();
        $("#div_Period").hide();
        $("#div_Annual").hide();
        $("#div_RptName").show();
    }
    else if (ReportType == "newspaperadvertisment") {
        $("#div_SharePattern").hide();
        $("#div_FinPattern").hide();
        $("#div_Year").show();
        $("#div_RptCaption").show();
        $("#div_Period").hide();
        $("#div_Annual").hide();
        $("#div_RptName").show();
    }
}

function Upload() {
    var ReportType = $("#RptType").val();
    var Year = $("#Year").val();
    var Quarter = $("#Quarter").val();
    var File = $("#file").prop('files')[0];
    if (File == "") {
        swal("Please choose the file");
        return false;
    }
    var Subtype = $("#SharePattern").val();
    var Subfin = $("#FinancialPattern").val();
    var SubAnnu = $("#AnnualPattern").val();
    var ReportName = $("#ReportName").val();
    if (ReportName == "") {
        swal("Report Name Cannot be blank");
        return false;
    }
    if (ReportType == "annual") {
        Quarter = "annual";
    }
    if (File != undefined) {
        var ext = File.name.split('.')[1];
        if (ext != "pdf") {
            swal("File Type not valid.Only accepts PDF Files");
            $("#SpanNo").text('No file chosen');
        }
        else {
            var reader = new FileReader();
            reader.readAsBinaryString(File);
            reader.onload = function () {

                var data = btoa(reader.result);
                if (data.length > 0) {
                    var formData = new FormData();
                    formData.append("filecontent", data);
                    formData.append("ReportType", ReportType);
                    formData.append("Year", Year);
                    formData.append("Quarter", Quarter);
                    formData.append("ShareHolding_Sub", Subtype);
                    formData.append("Financial_Sub", Subfin);
                    formData.append("Annual_Sub", SubAnnu);
                    formData.append("Report_Name", ReportName);
                    $.ajax({
                        type: "POST",
                        url: "/ReportUpload/DocumentUpload",
                        data: formData,
                        contentType: false,
                        processData: false,
                        datatype: "json",
                        success: function (data) {
                            var result = data;
                            if (result == "success") {
                                swal("Uploaded!", "File Uploaded Successfully!", "success");
                                $('#file').val('');
                                $("#SpanNo").text('No file chosen');
                                uploadedReports();
                            }
                            else {
                                swal("Failed!", "File is already exist", "error");
                            }
                        },
                        error: function (response) {
                            swal(JSON.stringify(data));
                        }
                    })
                }
            }
        }

    }
}
$('#Year').change(function () {
    uploadedReports();
});
function uploadedReports() {
    $('#tbl_reports').find('tbody').empty();
    var ReportType = $("#RptType").val();
    var Sub_cat = $("#SharePattern").val();
    var Fin_cat = $("#FinancialPattern").val();
    var Annu_cat = $("#AnnualPattern").val();
    var Year = $("#Year").val();
    $.ajax({
        type: "POST",
        url: "/ReportUpload/uploadedReports",
        data: { type: ReportType, subOption: Sub_cat, Fincaty: Fin_cat, Annucaty: Annu_cat, year: Year },
        success: function (response) {
            if (response.data.length != 0) {
                var i = 1;
                var row = "";
                $.each(response.data, function (index, value) {
                    row += '<tr>';
                    row += '<td style="text-align:left">' + i + '</td>';
                    row += '<td style="text-align:left" class="report_td" id="' + value.Value + '">' + value.Value + '</td>';
                    row += '<td style="text-align:center"><a onclick="RemoveUpload(' + i + ');" style="color:blue; cursor:pointer;" id="' + value.Value + '">X</a></td>';
                    row += '</tr>';
                    $("#tbl_reports tbody").html(row);
                    i = i + 1;
                });
            }
        },
        error: function (response) {
            swal(JSON.stringify(response));
        }
    });
}

function RemoveUpload(index) {
    if (confirm('Are you sure to delete the file?')) {
        //var td = $(this).closest('tr').find('td');
        //var result = td.get(1).innerText;
        var result = $("#tbl_reports").find('tr:eq(' + index + ')').find('td:eq(1)').text();
        var ReportType = $("#RptType").val();
        var Sub_cat = $("#SharePattern").val();
        var Fin_cat = $("#FinancialPattern").val();
        var Annu_cat = $("#AnnualPattern").val();
        var Year = $("#Year").val();
        $.ajax({
            type: "POST",
            url: "/ReportUpload/RemoveUploadedReports",
            dataType: "json",
            data: { reportId: result, type: ReportType, subOption: Sub_cat, Fincaty: Fin_cat, Annucaty: Annu_cat, year: Year},
            success: function (response) {
                if (response.Result === "success") {
                    swal('File Removed Successfully');
                    uploadedReports();
                }
            }, error: function (response) {
                swal(JSON.stringify(response));
            }
        });
    }
}