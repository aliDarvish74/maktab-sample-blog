// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
$(document).ready(function () {
    let errorToast = document.getElementById('error-toast');
    if(!!errorToast){
        let toastBlock = new bootstrap.Toast(errorToast);
        toastBlock.show();
    }
    
    let successToast = document.getElementById('success-toast');
    if(!!successToast){
        let toastBlock = new bootstrap.Toast(successToast);
        toastBlock.show();
    }
})
