// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#EmployeeList").change(function () {
    var selectedEmployeeId = $(this).children("option:selected").val();
    $("#CelebratorId").val(selectedEmployeeId);
});


