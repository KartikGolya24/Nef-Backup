
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

    $(document).ready(function () {
        function updateCardStyles(groupName, activeClasses, defaultClasses) {
          // Reset styles for all cards in the group
          $(`input[name="${groupName}"]`).closest('.ordering-card')
            .removeClass(activeClasses)
            .addClass(defaultClasses);
      
          // Apply active styles to the selected card
          const checkedRadio = $(`input[name="${groupName}"]:checked`);
          if (checkedRadio.length) {
            checkedRadio.closest('.ordering-card')
              .addClass(activeClasses)
              .removeClass(defaultClasses);
          }
        }
      
        // Attach change event to all radio groups
        $('input[name="orderElectricityOption"]').on('change', function () {
          updateCardStyles('orderElectricityOption', 'turquoise_bg border_dark_blue', 'border_black-100');
        });
      
        $('input[name="orderTVOption"]').on('change', function () {
          updateCardStyles('orderTVOption', 'light_purple_bg border_dark_purple', 'border_black-100');
        });
      
        $('input[name="orderInternetOption"]').on('change', function () {
          updateCardStyles('orderInternetOption', 'turquoise_bg border_dark_blue h-auto', 'border_black-100 h-auto');
        });
      
        // Initial check on page load for all groups
        updateCardStyles('orderElectricityOption', 'turquoise_bg border_dark_blue', 'border_black-100');
        updateCardStyles('orderTVOption', 'light_purple_bg border_dark_purple', 'border_black-100');
        updateCardStyles('orderInternetOption', 'turquoise_bg border_dark_blue h-auto', 'border_black-100 h-auto');
      });
      
      
      $('#customerTypesButton').on('click', function() {
        $('.electricity-price-slider').toggleClass('d-none');
      });

      $(".customer-card .card-front .btn").on("click", function (e) {
        e.preventDefault();
        $(this).closest(".customer-card").addClass("show-details");
      });
    
      $(".customer-card .card-back .btn").on("click", function (e) {
        e.preventDefault();
        $(this).closest(".customer-card").removeClass("show-details");
      });
    
    
    

    // document.querySelectorAll('.accordian-section .accordion-item').forEach(item => {
    //     const collapse = item.querySelector('.accordion-collapse');
    //     collapse.addEventListener('show.bs.collapse', () => {
    //         item.classList.add('expanded');
    //     });
    //     collapse.addEventListener('hide.bs.collapse', () => {
    //         item.classList.remove('expanded');
    //     });
    // });
    
    
    
});
// document.addEventListener('DOMContentLoaded', () => {
//     const cards = document.querySelectorAll('.ordering-card');
//     const radios = document.querySelectorAll('.ordering-card .form-check-input');
  
//     radios.forEach(radio => {
//       radio.addEventListener('change', () => {
//         // Remove classes from all cards
//         cards.forEach(card => {
//           card.classList.remove('light_purple_bg', 'border_dark_purple');
//           card.classList.add('white-bg', 'border_black-100');
//         });
  
//         // Add classes to the parent card of the checked radio
//         if (radio.checked) {
//           const card = radio.closest('.ordering-card');
//           card.classList.add('light_purple_bg', 'border_dark_purple');
//           card.classList.remove('white-bg', 'border_black-100');
//         }
//       });
//     });
//   });

document.addEventListener('DOMContentLoaded', () => {
    const popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
    popoverTriggerList.forEach(popoverTriggerEl => {
      new bootstrap.Popover(popoverTriggerEl);
    });
});

