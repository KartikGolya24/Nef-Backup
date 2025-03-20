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
                url: "https://productsapi.nef.dk/api/CheckAddress" + "?adresseGUID=" + addressId,
                type: "Get",
                success: function (res) {
                    debugger
                    var PackageStatus = 1;
                    var TvPackageStatus = 1;
                    var FiberPackageStatus = 1;

                    if (packageType == "tv") {
                        PackageStatus = res.tvPackageResult;
                    } else {
                        PackageStatus = res.fiberConnectionResult;
                    }

                    var pageUrl = `${origin}${redirectUrl}`;
                    var expires = 86400;//24 hours
                    document.cookie = "flowName=" + flowName + "; path=/;max-age=" + expires;
                    document.cookie = "packageType=" + packageType + "; path=/;max-age=" + expires;
                    document.cookie = "PackageStatus=" + PackageStatus + "; path=/;max-age=" + expires;
                    //document.cookie = "tvPackageStatus=" + TvPackageStatus + "; path=/;max-age=" + expires;
                    //document.cookie = "fiberPackageStatus=" + FiberPackageStatus + "; path=/;max-age=" + expires;
                    document.cookie = "addressValue=" + encodeURIComponent(addressName) + "; path=/;max-age=" + expires;
                    window.location.href = pageUrl;
                    
                },
                error: function () {
                    alert("error")
                }
            })
        } else {
            $(".location-search-button").prop("disabled", false);
        }
    })
})