function disableTooltip(controlName) {
    $('[tooltipcontent][id*=' + controlName + ']').tooltip("destroy");
    $('[tooltipcontent][id*=' + controlName + ']').removeClass("validationError");
    $('[tooltipcontent][id*=' + controlName + ']').removeAttr("tooltipcontent");

    /*
    var controlValidation = $.cookie("controlValidation");
    if (typeof controlValidation != 'undefined') {
        if (!controlValidation.includes(controlName)) {
            $.cookie("controlValidation", controlValidation + ";" + controlName, { path: '/' });
        }
    }
    else {
        $.cookie("controlValidation", controlName, { path: '/' });
    }
    */
}

$(function () {
    EnableToolTip();
});

/*
function EnableToolTipPostBack() {

    var controlValidation = $.cookie("controlValidation");
    if (typeof controlValidation != 'undefined') {
        var myarray = controlValidation.split(';');
        for (var i = 0; i < myarray.length; i++) {

            $('[tooltipcontent][id*=' + myarray[i] + ']').removeClass("validationError");
            $('[tooltipcontent][id*=' + myarray[i] + ']').removeAttr("tooltipcontent");
        }
    }

    var controles = $("[tooltipcontent]");
    var documentbody = document.documentElement.clientHeight ? document.documentElement : document.body;

    for (index = 0; index < controles.length; ++index) {
        var controle = controles[index];
        $("#" + controle.id).tooltip({
            position: {
                my: "left top",
                at: "left+5 bottom+5",
                using: function (position, feedback) {
                    $(this).css(position);
                    $("<div>").addClass("arrowcontrolevalidation").addClass(feedback.vertical).addClass(feedback.horizontal).appendTo(this);
                }
            },
            content: $("#" + controle.id).attr("tooltipcontent"),
            items: "input,textarea,select,table,span",
        });
    }

    //Todo Add controls events stored in cookies if controls have a tooltipcontent's attribute
}
*/


function EnableToolTip() {

    var controles = $("[tooltipcontent]");
    var openfirst = 0;
    var documentbody = document.documentElement.clientHeight ? document.documentElement : document.body;

    for (index = 0; index < controles.length; ++index) {
        var controle = controles[index];
        $("#" + controle.id).tooltip({
            position: {
                my: "left top",
                at: "left+5 bottom+5",
                using: function (position, feedback) {
                    $(this).css(position);
                    $("<div>").addClass("arrowcontrolevalidation").addClass(feedback.vertical).addClass(feedback.horizontal).appendTo(this);
                }
            },
            content: $("#" + controle.id).attr("tooltipcontent"),
            items: "input,textarea,select,table,span",
        });
        if (openfirst == 0 && $("#" + controle.id).attr("tooltipcontent") != "") {
            openfirst = 1;
            $("#" + controle.id).tooltip("open");
            $("html, body").animate({ scrollTop: $("#" + controle.id).offset().top - 50 }, 500, 'easeInOutCubic');
        }
    }
}




