<script setup>
  import { ref, onMounted, reactive } from "vue"
  import oxy from "../../helpers/oxylang";
  import TvForm from './TvForm.vue'
  import FiberForm from './FiberForm.vue'
  import ElectricityForm from './ElectricityForm.vue'
  const emit = defineEmits(['change-tab'])

  const props = defineProps({
    selectedCategory: Object,
    addressFormModel: {
      type: Object
    },
    selectedPackage: {
      type: Object
    },
    billingTypes: {
      type: Array
    },
    wirelessInternetHeading: String,
    wirelessInternetUnit: String,
    wirelessInternetCost: Number,
    wirelessInternetNote: String,
    successPage: Object
  })

  //Data
  var currentStep = ref(2);

  //Methods
  function lang(key) {
    return oxy.oxylang(props.langArea, key);
  }

  function changeTab(key) {
    emit('change-tab', key);
  }

  function continueOrder() {
    if (currentStep.value !== 3)
      currentStep.value++;
  }

  function submit() {

  }

  function getAvailableDates() {

  }

  onMounted(() => {
    
  })
</script>

<template>
  <TvForm v-if="props.addressFormModel.packageType==='tv'"
          :selectedCategory="selectedCategory"
          :addressFormModel="addressFormModel"
          @change-tab="changeTab"
          :selectedPackage="selectedPackage"
          :successPage="successPage" />
  <FiberForm v-else-if="props.addressFormModel.packageType==='fiber'"
             :addressFormModel="addressFormModel"
             @change-tab="changeTab"
             :selectedPackage="selectedPackage"
             :billingTypes="billingTypes"
             :wireless-internet-heading="wirelessInternetHeading"
             :wirelessInternetUnit="wirelessInternetUnit"
             :wirelessInternetCost="wirelessInternetCost"
             :wirelessInternetNote="wirelessInternetNote"
             :successPage="successPage" />
  <ElectricityForm v-else
                   :addressFormModel="addressFormModel"
                   @change-tab="changeTab"
                   :selectedPackage="selectedPackage"
                   :successPage="successPage" />


</template>
