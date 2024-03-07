$(document).ready(function() {
    $("#Inicio").mask("99/99/9999 ?99:99");
    $("#Fim").mask("99/99/9999 ?99:99");
    
    $(".numeric-only input").keypress(function (evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 44 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }

        if (charCode == 44 && $(this).val().indexOf(',') > -1) {
            return false;
        }

        return true;
    });

});

