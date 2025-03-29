$(document).ready(function () {
    $(".electric-flow").on('click', function () {
        var electricityTypeId = $(this).attr("electricity-type-id");
        var flowName = "Privat";
        var packageType = $("#package").val();
        var origin = window.location.origin;
        var redirectUrl = $("#redirecturl").val();
        var pageUrl = `${origin}${redirectUrl}`;
        if ($("#tab_id").hasClass("business-tab")) {
            flowName = "Business";
        }
        var expires = 86400;//24 hours
        document.cookie = "flowName=" + flowName + "; path=/;max-age=" + expires;
        document.cookie = "packageType=" + packageType + "; path=/;max-age=" + expires;
        document.cookie = "electricityTypeId=" + electricityTypeId + "; path=/;max-age=" + expires;
        window.location.href = pageUrl;

    })
})