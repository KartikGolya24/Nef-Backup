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
});

// document.addEventListener("DOMContentLoaded", () => {
//   const popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
//   popoverTriggerList.forEach((popoverTriggerEl) => {
//     new bootstrap.Popover(popoverTriggerEl);
//   });
// });

// $(document).on("click", function (event) {
//   if (!$(event.target).closest('[data-bs-toggle="popover"]').length) {
//     $(".popover ").hide();
//   }
// });


