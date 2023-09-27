// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

AssignSerialNumber(1);

document.onload(){
    var number = 0;
    function AssignSerialNumber(number) {
        return number + 1;
        number++;
        console.log(number);
        document.getElementsByClassName('#SerialNumber').InnerHTML = number;

    }
}
