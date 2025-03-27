<script setup>
  import { ref, onMounted, computed, reactive } from 'vue'
  import oxy from '../../helpers/oxylang.js';
  import PurchaseLookup from './PurchaseLookup.vue'
  import PurchaseCategories from './PurchaseCategories.vue'
  import PurchaseForm from './PurchaseForm.vue'

  const props = defineProps({
    addressFormModel: {
      type: Object,
      required: true,
      validator(value) {
        return (
          typeof value.flowName === 'string' &&
          typeof value.packageType === 'string' &&
          typeof value.packageStatus === 'number' &&
          typeof value.address === 'string'&&
          typeof value.addressId === 'string'
        );
      }
    },
    langArea: {
      type: String,
      default: "purchaseLanguage"
    },
    categoriesHeading: {
      type: String
    },
    categories: {
      type: Object
    },
    notSuccessIcon: String,
    successIcon: String,
    billingTypes: {
      type: Array
    },
    wirelessInternetHeading: String,
    wirelessInternetUnit: String,
    wirelessInternetCost: Number,
    wirelessInternetNote: String,

  })
  props.addressFormModel.packageStatus = ref(props.addressFormModel.packageStatus)

  // Data
  const navigationList = [
    'lookup',
    'categories',
    'form'
  ]
  var activeTab = ref(navigationList[0])
  const components = {
    'purchase-lookup': PurchaseLookup,
    'purchase-categories': PurchaseCategories,
    'purchase-form': PurchaseForm
  }
  var selectedCategory = {}
  var selectedPackage = {}

  //Computed Properties
  const componentProps = computed(() => {
    if (activeTab.value === 'lookup')
      return {
        'addressFormModel': props.addressFormModel,
        'success-icon': props.successIcon,
        'not-success-icon': props.notSuccessIcon
      }
    if (activeTab.value === 'categories')
      return {
        'categories-heading': props.categoriesHeading,
        'categories': props.categories
      }
    if (activeTab.value === 'form')
      return {
        'selectedCategory': selectedCategory,
        'selectedPackage': selectedPackage,
        'addressFormModel': props.addressFormModel,
        'billingTypes': props.billingTypes,
        'wirelessInternetHeading': props.wirelessInternetHeading,
        'wirelessInternetUnit': props.wirelessInternetUnit,
        'wirelessInternetCost': props.wirelessInternetCost,
        'wirelessInternetNote': props.wirelessInternetNote,
      }
  })

  //Methods
  function changeTab(key, category, pkg) {
    selectedCategory = category;
    if (pkg)
      selectedPackage = pkg;
    activeTab.value = key;
  }
  function lang(key) {
    return oxy.oxylang(props.langArea, key);
  }

  onMounted(() => {
  })

</script>



<template>
  <div>
    <input type="hidden" id="flowName" :value="addressFormModel.flowName" />
    <input type="hidden" id="packageType" :value="addressFormModel.packageType" />
    <input type="hidden" id="packageStatus" :value="addressFormModel.tvPackageStatus" />

    <component :is="components['purchase-'+activeTab]" @change-tab="changeTab" v-bind="componentProps"></component>
  </div>
</template>
