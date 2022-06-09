// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function fillFormWithGRN(url, str) {
    $.ajax({
        url: url,
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: { 'GRN_Number': str },
        success: function (data) {
            console.log(data);
            $('#dispatchnumber').val(data.dispatchNumber);
            $('#datepicker3').val(data.arrivalDate);
            $('#truckplate').val(data.truckPlateNumber);
            $('#samplername').val(data.samplerName);
            $('#graderesult').val(data.qualityGradeResult);
            $('#numberofbags').val(data.totalNumberofBags);
            $('#samplinginspector').val(data.samplingInspectorName);
        }
    });

}

function validateFile(fileName) {
    var Extensions = ['png', 'jpeg', 'jpg', 'gif', 'docx', 'doc', 'xlsx', 'xls', 'txt', 'pdf', 'rar', 'zip'];
    var fn = fileName.split("\\").pop();
    var ext = fn.substring(fn.lastIndexOf('.') + 1).toLowerCase();
    if (!Extensions.includes(ext)) {
        $('#msg').text("File is NOT Supported");
        document.getElementById('file').value = "";
        return false;
    } else {
        $('#msg').text("");
        return true;
    }
}