var addressId = "";
var addressName = "";

dawaAutocomplete.dawaAutocomplete(document.getElementById("adresse"), {
    select: function (selected) {
        addressId = selected.data.id
        addressName = selected.tekst;

        $(".location-search-button").prop("disabled", false);

    }
});

$(document).ready(function () {
    $("#adresse").on('keyup', function () {
        $(".location-search-button").prop("disabled", true);
    })

    $(".location-search-button").on('click', function () {
        var flowName = "Privat";
        var packageType = $("#package").val();
        var origin = window.location.origin;
        var redirectUrl = $("#redirecturl").val();
        if ($("#tab_id").hasClass("business-tab")) {
            flowName = "Business";
        }

        if (addressId && addressId != "") {
            $.ajax({
                url: "/purchase-flow/check-address?adresseGUID=" + addressId,
                type: "Get",
                success: function (res) {
                    if (res != null && res.isSucceeded == true && res.data != null) {

                        var PackageStatus = 1;

                        if (packageType == "tv") {
                            PackageStatus = res.data.tvPackageResult;
                        } else {
                            PackageStatus = res.data.fiberConnectionResult;
                        }

                        var pageUrl = `${origin}${redirectUrl}`;
                        var expires = 86400;//24 hours
                        document.cookie = "flowName=" + flowName + "; path=/;max-age=" + expires;
                        document.cookie = "packageType=" + packageType + "; path=/;max-age=" + expires;
                        document.cookie = "PackageStatus=" + PackageStatus + "; path=/;max-age=" + expires;
                        document.cookie = "addressValue=" + encodeURIComponent(addressName) + "; path=/;max-age=" + expires;
                        document.cookie = "addressId=" + addressId + "; path=/;max-age=" + expires;
                        window.location.href = pageUrl;
                    } else {
                        console.log(res.error);
                    }

                },
                error: function (error) {
                    console.log("error : " + error);
                }
            })
        } else {
            $(".location-search-button").prop("disabled", false);
        }
    })
})