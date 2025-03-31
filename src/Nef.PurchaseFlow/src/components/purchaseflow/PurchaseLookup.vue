<script setup>
  import { ref, onMounted, computed } from 'vue'
  import PurchaseFlowService from './purchase-flow.service.js'
  import TvPackageItem from './TvPackageItem.vue'
  import FiberPackageItem from './FiberPackageItem.vue'
  import { dawaAutocomplete } from 'dawa-autocomplete2';
  import oxy from '../../helpers/oxylang.js';

  const emit = defineEmits(['change-tab'])

  const props = defineProps({
    addressFormModel: {
      type: Object,
      required: true
    },
    langArea: {
      type: String,
      default: "purchaseLanguage"
    },
    notSuccessIcon: String,
    successIcon: String
  })

  //Data
  var packages = ref([]);

  //Computed properties
  const getStatusTitle = computed(() => {
    switch (props.addressFormModel.packageStatus.value) {
      case 1:
        return lang('addressNotConnected');
      case 2:
        return lang('addressPassed');
      case 3:
        return lang('addressConnected');
      default:
        return '';
    }
  })


  const getStatusDescription = computed(() => {
    switch (props.addressFormModel.packageStatus.value) {
      case 1:
        return lang('addressNotConnectedDesc');
      case 2:
        return lang('addressPassedDesc');
      case 3:
        return props.addressFormModel.flowName === 'Privat' ? lang('addressConnectedDesc') : lang('businessAddressConnectedDesc');
      default:
        return ''
    }
  })

  //Methods
  function checkAddress() {
    if (props.addressFormModel.addressId !== '') {
      PurchaseFlowService.checkAddress(props.addressFormModel.addressId).then((res) => {
        if (props.addressFormModel.packageType == "tv") {
          props.addressFormModel.packageStatus.value = res.data.tvPackageResult;
        } else {
          props.addressFormModel.packageStatus.value = res.data.fiberConnectionResult;
        }
      })
    }
  }

  function lang(key) {
    return oxy.oxylang(props.langArea, key);
  }
  function changeTab(selectedPackage) {
    emit('change-tab', props.addressFormModel.packageType === 'tv' ? 'categories' : 'form',null,selectedPackage)
  }

  function getAvailablePackages() {
    if (props.addressFormModel.packageType === 'tv') {
      PurchaseFlowService.getTvPackages().then(data => {
        packages.value = data;
        setTimeout(function () { truncateText(".text-two-line", 100) },200);
      }).catch(error => {
        console.log(error); 
      })
    } else {
      PurchaseFlowService.getFiberPackages().then(data => {
        packages.value = data;
        setTimeout(function () { truncateText(".text-two-line", 100) }, 200);

      }).catch(error => {
        console.log(error);
      })
    }
  }
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

  //Life-cycle hooks
  onMounted(() => {
    getAvailablePackages();
    var inputElm = document.getElementById('adresse');

    dawaAutocomplete(inputElm, {
      select: function (selected) {
        props.addressFormModel.addressId = selected.data.id
        $(".location-search-button").prop("disabled", false);
      }
    });

  })
</script>



<template>
  <div class="account-action order-nef-internet">
    <div class="search-section">
      <div class="container">
        <h2 class="title"> {{lang('addressFormTitle')}}</h2>
        <div class="form-group autocomplete-container">
          <input type="text" id="adresse" class="form-control " :placeholder="lang('formPlaceholder')" :aria-label="lang('formPlaceholder')" v-model="addressFormModel.address" />
          <button type="button" :class="['btn','location-search-button', addressFormModel.packageType == 'tv' ? 'dark_purple_btn' : 'dark_blue_btn']" @click="checkAddress">{{lang('formButton')}}</button>
        </div>
        <div class="row justify-content-center">
          <div class="col-xl-4">
            <div class="order-complete-Bx">
              <img :src="addressFormModel.packageStatus.value == 3 ?successIcon:notSuccessIcon" />
              
              <h4 class="title">{{getStatusTitle}}</h4>
              <p>{{getStatusDescription}}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div v-if="props.addressFormModel.packageStatus.value !== 1" :class="['pacakge-section', addressFormModel.packageType == 'tv' ? 'private-tv-white' : 'private-internet-white']">
      <div class="container-xl" id="packagesList">
        <div class="section-heading">
          <h2>{{lang('packagesTitle')}}</h2>
        </div>
        <div class="package-list">
          <div class="row">
            <TvPackageItem v-if="addressFormModel.packageType == 'tv'" v-for="pkg in packages" :key="pkg.id" :pkg="pkg" :packages="packages" @change-tab="changeTab"></TvPackageItem>

            <FiberPackageItem v-if="addressFormModel.packageType == 'fiber'" v-for="pkg in packages" :key="pkg.id" :pkg="pkg" :packages="packages" @change-tab="changeTab"></FiberPackageItem> 
            
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
