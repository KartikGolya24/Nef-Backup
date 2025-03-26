$(document).ready(function () {
    $("#menu-toggle-icon").click(function (event) {
        event.stopPropagation();
        $(this).toggleClass("active");
        $(".mobile-menu").toggleClass("active");
        $(".mobile-header-nav").toggleClass("menu-visible");
        $("body").toggleClass("overflow-hidden");
    });

    $("body").on("click", function (event) {
        if (!$(event.target).closest(".header, .top-header").length) {
            $(".mobile-menu").removeClass("active");
            $(".mobile-header-nav").removeClass("menu-visible");
            $("#menu-toggle-icon").removeClass("active");
        }
    });

    $(".search").click(function (event) {
        event.stopPropagation();
        $(this).siblings(".searched-list").addClass("active");
    });

    $(document).click(function (event) {
        if (!$(event.target).closest(".searched-list, .search").length) {
            $(".searched-list").removeClass("active");
        }
    });

    function updateCardStyles(groupName, activeClasses, defaultClasses) {
        // Reset styles for all cards in the group
        $(`input[name="${groupName}"]`).closest(".ordering-card").removeClass(activeClasses).addClass(defaultClasses);

        // Apply active styles to the selected card
        const checkedRadio = $(`input[name="${groupName}"]:checked`);
        if (checkedRadio.length) {
            checkedRadio.closest(".ordering-card").addClass(activeClasses).removeClass(defaultClasses);
        }
    }

    // Attach change event to all radio groups
    $('input[name="orderElectricityOption"]').on("change", function () {
        updateCardStyles("orderElectricityOption", "turquoise_bg border_dark_blue", "border_black-100");
    });

    $('input[name="orderTVOption"]').on("change", function () {
        updateCardStyles("orderTVOption", "light_purple_bg border_dark_purple", "border_black-100");
    });

    $('input[name="orderInternetOption"]').on("change", function () {
        updateCardStyles("orderInternetOption", "turquoise_bg border_dark_blue h-auto", "border_black-100 h-auto");
    });

    // Click event on the whole card to select the radio button
    $(".ordering-card").click(function () {
        const radio = $(this).find('input[type="radio"]');
        if (!radio.prop("checked")) {
            radio.prop("checked", true).trigger("change");
        }
    });

    // Initial check on page load for all groups
    updateCardStyles("orderElectricityOption", "turquoise_bg border_dark_blue", "border_black-100");
    updateCardStyles("orderTVOption", "light_purple_bg border_dark_purple", "border_black-100");
    updateCardStyles("orderInternetOption", "turquoise_bg border_dark_blue h-auto", "border_black-100 h-auto");

    $("#customerTypesButton").on("click", function () {
        $(".electricity-price-slider").toggleClass("d-none");
    });

    $(".customer-card .card-front .btn").on("click", function (e) {
        e.preventDefault();
        $(this).closest(".customer-card").addClass("show-details");
    });

    $(".customer-card .card-back .btn").on("click", function (e) {
        e.preventDefault();
        $(this).closest(".customer-card").removeClass("show-details");
    });

    // candidate cards
    $(".candidate-card-list .col-lg-3").hide().slice(0, 4).show();

    // On click, show all hidden cards
    $(".candidates-section .bottom-arrow").click(function () {
        $(".candidate-card-list .col-lg-3:hidden").fadeIn();
        $(this).hide(); // Hide the button after clicking
    });

    $(".search-btn").click(function (event) {
        event.stopPropagation(); // Prevent immediate closing
        $(".search-input").toggleClass("active");
    });

    $(document).on("click", function (event) {
        if (!$(event.target).closest(".search-btn, .search-input").length) {
            $(".search-input").removeClass("active");
        }
    });

    // Initialize popovers manually
    $('[data-bs-toggle="popover"]').each(function () {
        $(this).popover({ trigger: "manual" });
    });

    // Toggle popover on button click
    $(document).on("click", '[data-bs-toggle="popover"]', function (event) {
        event.stopPropagation(); // Prevent document click from closing it immediately
        let $this = $(this);

        // Get popover instance
        if ($this.attr("aria-describedby")) {
            $this.popover("hide");
        } else {
            // Hide all other popovers first
            $('[data-bs-toggle="popover"]').popover("hide");
            $this.popover("show");
        }
    });

    // Close popover when clicking outside
    $(document).on("click", function (event) {
        if (!$(event.target).closest('[data-bs-toggle="popover"], .popover').length) {
            $('[data-bs-toggle="popover"]').popover("hide");
        }
    });

    // search function
    $(".search-trigger").on("click", function (event) {
        event.stopPropagation();

        // Toggle only the dropdown related to the clicked element
        var dropdown = $(this).next(".search-dropdown");
        $(".search-dropdown").not(dropdown).slideUp(); // Close other dropdowns
        dropdown.stop(true, true).slideToggle();
    });

    // Prevent dropdown from closing when interacting inside it
    $(".search-dropdown").on("click", function (event) {
        event.stopPropagation();
    });

    // Click outside to close all dropdowns
    $(document).on("click", function () {
        $(".search-dropdown").slideUp();
    });

    // Auto height update for cards
    function equalizeHeights(selector) {
        var maxHeight = -1;
        var $elements = $(selector);

        // Reset heights before recalculating
        $elements.css("height", "auto");

        // Find max height
        $elements.each(function () {
            maxHeight = Math.max(maxHeight, $(this).outerHeight());
        });

        // Apply max height
        $elements.css("height", maxHeight + "px");
    }

    function updateAllEqualHeights() {
        equalizeHeights(".package-card .card-heading");
        equalizeHeights(".package-list .package-card");
        equalizeHeights(".service-card .card-outer");
    }

    // Two-line package data truncation
    function truncateText(selector, maxLength) {
        $(selector).each(function () {
            let $textContainer = $(this);
            let fullText = $textContainer.html().trim();

            if (fullText.length > maxLength) {
                let learnMoreText = "L\u00E6s mere";  // Læs mere
                let learnLessText = "L\u00E6s mindre"; // Læs mindre
                let truncatedText = fullText.substring(0, maxLength) + "...";
                let $toggleSpan = $("<span>")
                    .text(learnMoreText)
                    .addClass("read-toggle")

                // Store full and truncated text in attributes
                $textContainer.data({
                    "full-text": fullText,
                    "truncated-text": truncatedText,
                    expanded: false,
                });

                // Initially set truncated text
                $textContainer.html(truncatedText).append($toggleSpan);

                // Click event to toggle full/truncated text
                $textContainer.on("click", ".read-toggle", function () {
                    let isExpanded = $textContainer.data("expanded");

                    if (isExpanded) {
                        $textContainer.html($textContainer.data("truncated-text")).append($toggleSpan);
                        $textContainer.data("expanded", false);
                        $toggleSpan.text(learnMoreText);
                    } else {
                        $textContainer.html($textContainer.data("full-text")).append($toggleSpan);
                        $textContainer.data("expanded", true);
                        $toggleSpan.text(learnLessText);
                    }

                    // Recalculate heights after toggling
                    updateAllEqualHeights();
                });
            }
        });
    }

    // Run functions on page load
    truncateText(".text-two-line", 100);
    updateAllEqualHeights();

    // Run on window resize (with debounce)
    var resizeTimeout;
    $(window).on("resize", function () {
        clearTimeout(resizeTimeout);
        resizeTimeout = setTimeout(updateAllEqualHeights, 100);
    });
});
