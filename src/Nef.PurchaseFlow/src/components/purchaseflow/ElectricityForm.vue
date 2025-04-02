<script setup>
  import { ref, onMounted, reactive, computed, watch } from "vue"
  import oxy from "../../helpers/oxylang";
  import flatPickr from 'vue-flatpickr-component';
  import 'flatpickr/dist/flatpickr.css';
  import { Danish } from "flatpickr/dist/l10n/da.js"
  import PurchaseFlowService from "./purchase-flow.service";
  import moment from 'moment'
  import 'moment/locale/da';
  const emit = defineEmits(['change-tab'])

  const props = defineProps({
    addressFormModel: {
      type: Object
    },
    selectedPackage: Object,
    billingTypes: {
      type: Array
    },
    successPage: Object,
    electricityType: Object,
    postpaidPaymentDesc: String,
    prepaidPaymentDesc: String,
    addressTypes: Array,
    purchaseButtonText: String,
    purchaseButtonIconUrl: String
  })

  //Data
  var currentStep = ref('information');
  var dateModel = ref({});
  const config = ref({
    wrap: true, // set wrap to true only when using 'input-group'
    altFormat: 'j F, Y',
    altInput: true,
    dateFormat: 'Y-m-d',
    minDate: '',
    maxDate: '',
    enable: [],
    locale: Danish
  });
  const form = reactive({
    "orderType": "",
    "packageId": "",
    "packageName": props.electricityType.Heading,
    "tvCategory": "",
    "deliveryAddress": "",
    "fullName": "",
    "cprNumber": "",
    "email": "",
    "telephoneNumber": "",
    "deliveryDate": "",
    "totalPrice": 0.00,
    "isExtraPerson": false,
    "extraPersonFullName": "",
    "extraPersonCPRNumber": "",
    "addressType": "",
    "billingType": "",
    "hasOtherBillingAddress": false,
    "otherBillingAddress": "",
    "isWirelessInternetAccess": false,
  });
  var selectedBillingType = ref(props.billingTypes[0])

  //Computed properties
  const validateEmail = computed(() => {
    if (!form.email) return true;
    const email = form.email;
    const emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return emailPattern.test(email.toLowerCase());
  })
  const validateSecondStep = computed(() => {
    if (!form.fullName) {
      return false;
    }
    if (!form.cprNumber) {
      return false;
    }
    if (!form.email || !validateEmail.value) {
      return false;
    }
    if (!form.telephoneNumber) {
      return false;
    }
    if (dateModel.value.showCalendar) {
      if (!form.deliveryDate) {
        return false;
      }
    }
    if (form.isExtraPerson) {
      if (!form.extraPersonFullName) return false;
      if (!form.extraPersonCPRNumber) return false;
    }
    if (!form.addressType) {
      return false;
    }

    return true;
  })

  //Methods
  function lang(key) {
    return oxy.oxylang(props.langArea, key);
  }

  function back() {
    window.scrollTo(0, 0);
    if (currentStep.value === 'order')
      currentStep.value = 'information';
    else if (currentStep.value === 'reviewOrder')
      currentStep.value = 'order';
    else {
      history.back();
    }
  }

  function submit() {
    form.billingType = selectedBillingType.value.Title;
    form.totalPrice = (parseFloat(props.electricityType.Price) || 0) + (parseFloat(props.electricityType.CertificatePrice) || 0) + (parseFloat(selectedBillingType.Price) || 0)
    PurchaseFlowService.submitForm(form).then(res => {
      console.log(res);
      currentStep.value = 'success';
      window.scrollTo(0, 0);
    }).catch(err => {
      currentStep.value = 'success';
      window.scrollTo(0, 0);
    })
  }

  function getAvailableDates(typeValue) {
    let index = props.addressTypes.findIndex(type => type === typeValue);
    PurchaseFlowService.availableDates(index + 1, props.addressFormModel.addressId).then((res) => {
      dateModel.value = res.data;
      config.value.enable = dateModel.value.dates;
      config.value.minDate = dateModel.value.startDate;
      config.value.maxDate = dateModel.value.endDate;
    }).catch(error => console.error(error))
  }

  function formatDate(date) {
    // Set the locale to Danish (da)
    moment.locale('da');
    return moment(date).format('DD MMMM, YYYY'); // Format as "16 February, 2025"
  }

  function changeOrderStep(stepName) {
    currentStep.value = stepName;
    window.scrollTo(0, 0);
  }

  onMounted(() => {
    window.scrollTo(0, 0)
  })

  watch(
    () => form.addressType,
    (newAddressType, oldAddressType) => {
      form.orderType = `Electricity(${newAddressType})`;
      if (newAddressType) {
        getAvailableDates(newAddressType);
      }

    }
  );

</script>

<template>
  <section class="account-action order-nef-internet" v-if="currentStep==='order' || currentStep==='information'">
    <div class="container">
      <h2 class="action-title">{{lang('D_FormTitle')}}</h2>
      <div class="steps-action">
        <div class="step">
          <div class="step-head">
            <div class="left">
              <div class="step-number">1</div>
              <h4 class="step-name">{{lang('D_FirstStep')}}</h4>
            </div>
            <div class="right">
              <p class="para">{{lang('firstStepHeading')}}</p>
              <p class="para"><strong>{{electricityType.Heading}}</strong></p>
              <div class="checkmark">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                  <g clip-path="url(#clip0_518_17461)">
                    <path fill-rule="evenodd" clip-rule="evenodd"
                          d="M12 24C18.6274 24 24 18.6274 24 12C24 5.37259 18.6274 0 12 0C5.37259 0 0 5.37259 0 12C0 18.6274 5.37259 24 12 24ZM18.0048 8.94603C18.4483 8.39155 18.3585 7.58247 17.8039 7.13889C17.2495 6.6953 16.4404 6.78519 15.9968 7.33968L9.91812 14.938L7.48647 13.1143C6.91841 12.6882 6.11253 12.8034 5.68647 13.3714C5.26044 13.9395 5.37555 14.7454 5.94362 15.1714L9.37219 17.7429C9.92775 18.1596 10.7138 18.0597 11.1476 17.5174L18.0048 8.94603Z"
                          fill="#37B4B4" />
                  </g>
                  <defs>
                    <clipPath id="clip0_518_17461">
                      <rect width="24" height="24" fill="white" />
                    </clipPath>
                  </defs>
                </svg>
              </div>
            </div>
          </div>
        </div>
        <div class="step">
          <div class="step-head">
            <div class="left">
              <div class="step-number">2</div>
              <h4 class="step-name">{{lang('D_SecondStep')}}</h4>
            </div>
            <div class="right" v-if="currentStep !=='information'">
              <p class="para">{{lang('secondStepHeading')}}</p>
              <p class="para"><strong>{{form.deliveryAddress}}</strong></p>
              <div class="checkmark">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
                  <g clip-path="url(#clip0_518_17461)">
                    <path fill-rule="evenodd" clip-rule="evenodd"
                          d="M12 24C18.6274 24 24 18.6274 24 12C24 5.37259 18.6274 0 12 0C5.37259 0 0 5.37259 0 12C0 18.6274 5.37259 24 12 24ZM18.0048 8.94603C18.4483 8.39155 18.3585 7.58247 17.8039 7.13889C17.2495 6.6953 16.4404 6.78519 15.9968 7.33968L9.91812 14.938L7.48647 13.1143C6.91841 12.6882 6.11253 12.8034 5.68647 13.3714C5.26044 13.9395 5.37555 14.7454 5.94362 15.1714L9.37219 17.7429C9.92775 18.1596 10.7138 18.0597 11.1476 17.5174L18.0048 8.94603Z"
                          fill="#37B4B4" />
                  </g>
                  <defs>
                    <clipPath id="clip0_518_17461">
                      <rect width="24" height="24" fill="white" />
                    </clipPath>
                  </defs>
                </svg>
              </div>
            </div>
          </div>
          <div class="step-inside" v-if="currentStep ==='information'">
            <form action="">
              <div class="form-block">
                <div class="row">
                  <div class="col-lg-4 col-md-6">
                    <div class="form-group">
                      <label for="" class="label">{{lang('D_DeliveryAddress')}}<span class="required">*</span></label>
                      <input type="text" class="form-control" placeholder="Leveringsadresse" v-model="form.deliveryAddress">
                    </div>
                  </div>
                  <div class="col-lg-4 col-md-6">
                    <div class="form-group">
                      <label for="" class="label">{{lang('D_FullName')}}<span class="required">*</span></label>
                      <input type="text" class="form-control" :placeholder="lang('D_FullName_P')" v-model="form.fullName">
                    </div>
                  </div>
                  <div class="col-lg-4 col-md-6">
                    <div class="form-group">
                      <label for="" class="label">{{lang('D_CPRNumber')}}<span class="required">*</span></label>
                      <input type="text" class="form-control" :placeholder="lang('D_CPRNumber_P')" v-model="form.cprNumber">
                    </div>
                  </div>
                  <div class="col-lg-4 col-md-6">
                    <div class="form-group">
                      <label for="" class="label">{{lang('D_Email')}}<span class="required">*</span></label>
                      <input type="text" class="form-control" :placeholder="lang('D_Email_P')" v-model="form.email">
                      <p v-if="!validateEmail" class="error-text">
                        {{lang('invalidEmailError')}}
                      </p>
                    </div>
                  </div>
                  <div class="col-lg-4 col-md-6">
                    <div class="form-group">
                      <label for="" class="label">{{lang('D_Phone')}}<span class="required">*</span></label>
                      <input type="text" maxlength="11" class="form-control" :placeholder="lang('D_Phone_P')" v-model="form.telephoneNumber">
                    </div>
                  </div>
                </div>
              </div>
              <div class="form-block">
                <div class="row">
                  <div class="col-lg-12">
                    <div class="form-group radio-group">
                      <label for="" class="label">{{lang('extraPersonText')}}<span class="required">*</span></label>
                      <div class="form-check form-check-inline radio-black">
                        <input class="form-check-input" type="radio" name="extra_person" id="extra_person1" :value="true" v-model="form.isExtraPerson">
                        <label class="form-check-label" for="inlineRadio1">Ja</label>
                      </div>
                      <div class="form-check form-check-inline radio-black">
                        <input class="form-check-input" type="radio" name="extra_person" id="extra_person2" :value="false" v-model="form.isExtraPerson">
                        <label class="form-check-label" for="inlineRadio2">Nej</label>
                      </div>
                    </div>
                  </div>
                  <div class="col-lg-4 col-md-6" v-if="form.isExtraPerson">
                    <div class="form-group">
                      <label for="" class="label">{{lang('D_FullName')}}<span class="required">*</span></label>
                      <input type="text" class="form-control" :placeholder="lang('D_FullName')" v-model="form.extraPersonFullName">
                    </div>
                  </div>
                  <div class="col-lg-4 col-md-6" v-if="form.isExtraPerson">
                    <div class="form-group">
                      <label for="" class="label">{{lang('D_CPRNumber_P')}}<span class="required">*</span></label>
                      <input type="text" class="form-control" :placeholder="lang('D_CPRNumber_P')" v-model="form.extraPersonCPRNumber">
                    </div>
                  </div>
                </div>
              </div>

              <div class="form-block">
                <div class="row">
                  <div class="col-lg-4 col-md-6">
                    <div class="form-group">
                      <label for="" class="label">Jeg ønsker at…<span class="required">*</span></label>
                      <select class="form-select" aria-label="Default select example" v-model="form.addressType">
                        <option value="" selected>Vælg venligst…</option>
                        <option v-for="(option, index) in addressTypes" :key="index" :value="option">
                          {{ option }}
                        </option>
                      </select>
                    </div>
                  </div>
                </div>
              </div>
              <div class="form-block" v-if="form.addressType!=='' && dateModel.showCalendar">
                <div class="row">
                  <div class="col-lg-4 col-md-6">
                    <div class="form-group">
                      <div class="date form-group mb-0">
                        <label for="" class="label">{{dateModel.calendarTitle}}</label>
                        <flat-pickr :config="config" class="form-control" :placeholder="lang('D_DeliveryDate_P')" v-model="form.deliveryDate" />
                        <img src="assets/img/icons/Calendar-black.svg" alt="" class="position-icon">
                      </div>
                      <p class="mt-2" v-if="dateModel.calendarHelperText">{{dateModel.calendarHelperText}}</p>
                    </div>
                  </div>
                </div>
              </div>

              <div class="multiple-buttons">
                <a href="javascript:void(0)" type="button" class="btn white_bg_btn" @click="back">
                  Tilbage
                </a>
                <a href="javascript:void(0)" type="button" :class="['btn', 'dark_blue_btn',!validateSecondStep?'disabled':'']" @click="changeOrderStep('order')">
                  Fortsæt til bestilling
                </a>
              </div>
            </form>
          </div>
        </div>

        <div :class="['step',currentStep === 'information'?'disabled':'']">
          <div class="step-head">
            <div class="left">
              <div class="step-number">3</div>
              <h4 class="step-name">{{lang('D_ThirdStep')}}</h4>
            </div>
          </div>
          <div class="step-inside order-description" v-if="currentStep === 'order'">
            <!--@click="form.billingType=billingType.Title"-->
            <div class="row">
              <div class="col-lg-4 col-md-6 mb-32 mb-md-0" v-for="billingType in billingTypes">
                <div :class="['ordering-card',selectedBillingType.Title===billingType.Title ? 'turquoise_bg border_dark_blue':'border_black-100']" @click="selectedBillingType=billingType">
                  <div class="card-head">
                    <div class="form-check radio-light-blue">
                      <input class="form-check-input" type="radio" name="orderElectricityOption" id="orderElectricityOption" :value="billingType" v-model="selectedBillingType">
                    </div>
                    <div class="tag" v-if="billingType.IsTagVisible">{{billingType.Tag}}</div>
                  </div>
                  <div class="card-content">
                    <h4 class="card-title">{{billingType.Title}}</h4>
                    <div v-html="billingType.Description">
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="row justify-content-between mt-32">
              <div class="col-lg-4 col-md-6">
                <div class="order-summery-text" v-html="prepaidPaymentDesc">
                </div>
              </div>
              <div class="col-lg-4 col-md-6">
                <div class="order-summery-text" v-html="postpaidPaymentDesc">
                </div>
              </div>
            </div>

          </div>
        </div>
      </div>

      <div class="multiple-buttons" v-if="currentStep !=='information'">
        <a href="javascript:void(0)" type="button" class="btn white_bg_btn" @click="back"> Tilbage </a>
        <a href="javascript:void(0)" type="button" class="btn dark_blue_btn" @click="changeOrderStep('reviewOrder')" v-if="currentStep === 'order'">
          Gennemgå bestilling
        </a>

      </div>
    </div>
  </section>

  <section class="account-action order-nef-tv" v-if="currentStep==='reviewOrder'">
    <div class="container">
      <h2 class="action-title">{{lang('D_ReviewPageHeading')}}</h2>
      <div class="info-correct">
        <div class="row">
          <div class="col-lg-6">
            <div class="billing-box">
              <h4 class="info-box-title">{{lang('reviewStepProductSectionTitle')}}</h4>
              <ul class="info-list">
                <li>
                  <p class="para">{{electricityType.Heading}}</p>
                  <ul>
                    <li v-for="(textLine, index) in electricityType.TextList" :key="index">
                      {{textLine}}
                    </li>
                  </ul>
                </li>

                <li v-if="electricityType.Price">
                  <p class="para">Abonnement</p>
                  <p class="price">{{electricityType.Price}},-{{electricityType.PriceUnit}}</p>
                </li>
                <li v-if="electricityType.CertificatePrice">
                  <p class="para">{{electricityType.Heading}} - tillæg</p>
                  <p class="price">{{electricityType.CertificatePrice}},-{{electricityType.CertificatePriceUnit}}</p>
                </li>
                <li>
                  <p class="para">Afregningsmetode</p>
                  <p class="price">{{selectedBillingType.Price}},-{{selectedBillingType.PriceUnit}}</p>
                  <!--{{form.billingType}}-->
                  <ul>
                    <li>
                      {{selectedBillingType.Title}}
                    </li>
                  </ul>
                </li>

                <li>
                  <p class="para">Total</p>
                  <h4 class="total-price">{{ (parseFloat(electricityType.Price) || 0) + ( parseFloat(electricityType.CertificatePrice)||0) + (parseFloat(selectedBillingType.Price)||0)}},-{{electricityType.PriceUnit}}</h4>
                </li>
                <li>
                  <p class="para">Tillæg til timeprisen</p>
                  <p class="price">{{selectedBillingType.SupplementPrice}},-{{selectedBillingType.SupplementPriceUnit}}</p>
                </li>
              </ul>


            </div>
            <div class="info-box">
              <h4 class="info-box-title">{{lang('D_SecondStep')}}</h4>
              <ul class="info-list">
                <li>
                  <p class="para">{{lang('D_DeliveryAddress')}}:</p>
                  <span>{{form.deliveryAddress}}</span>
                </li>
                <li>
                  <p class="para">{{lang('D_FullName')}}:</p>
                  <span>{{form.fullName}}</span>
                </li>
                <li>
                  <p class="para">{{lang('D_Email')}}:</p>
                  <span>{{form.email}}</span>
                </li>
                <li>
                  <p class="para">{{lang('D_Phone')}}:</p>
                  <span>{{form.telephoneNumber}}</span>
                </li>
                <li>
                  <p class="para">{{lang('D_CPRNumber')}}:</p>
                  <span>{{form.cprNumber}}</span>
                </li>
                <li v-if="dateModel.showCalendar">
                  <p class="para">{{lang('D_DeliveryDate')}}:</p>
                  <span>{{ formatDate(form.deliveryDate) }}</span>
                </li>

              </ul>
            </div>
          </div>
          <div class="col-lg-6">
            <div class="info-box" v-if="form.isExtraPerson">
              <h4 class="info-box-title">Ekstra person</h4>
              <ul class="info-list">
                <li>
                  <p class="para">{{lang('D_FullName')}}:</p>
                  <span>{{form.extraPersonFullName}}</span>
                </li>
                <li>
                  <p class="para">{{lang('D_CPRNumber')}}:</p>
                  <span>{{form.extraPersonCPRNumber}}</span>
                </li>
              </ul>
            </div>
            <div class="info-box">
              <h4 class="info-box-title">Andet</h4>
              <ul class="info-list">
                <li>
                  <p class="para">{{form.addressType}}</p>
                </li>
              </ul>
            </div>
            <div class="info-box">
              <h4 class="info-box-title">{{lang('D_ThirdStep')}}</h4>
              <ul class="info-list">
                <li>
                  <p class="para">Afregningsmetode</p>
                  <span>{{selectedBillingType.Title}}</span>
                </li>
              </ul>
            </div>
          </div>
          <div class="col-md-12">
            <div class="multiple-buttons">
              <a href="javascript:void(0)" type="button" class="btn white_bg_btn" @click="back">
                Tilbage
              </a>
              <a href="javascript:void(0)" type="button" class="btn dark_blue_btn" @click="submit">
                <!--<svg xmlns="http://www.w3.org/2000/svg" width="25" height="24" viewBox="0 0 25 24" fill="none">
                  <path d="M22.0503 3.24316H2.94451C2.50485 3.24316 2.14844 3.59958 2.14844 4.03924V15.9804C2.14844 16.42 2.50485 16.7764 2.94451 16.7764H22.0503C22.4899 16.7764 22.8464 16.42 22.8464 15.9804V4.03924C22.8464 3.59958 22.4899 3.24316 22.0503 3.24316Z" stroke="white" stroke-width="1.71001" stroke-linecap="round" stroke-linejoin="round"></path>
                  <path d="M10.9066 16.7769L9.31445 20.7572" stroke="white" stroke-width="1.71001" stroke-linecap="round" stroke-linejoin="round"></path>
                  <path d="M14.0898 16.7769L15.682 20.7572" stroke="white" stroke-width="1.71001" stroke-linecap="round" stroke-linejoin="round"></path>
                  <path d="M7.7207 20.7568H17.2736" stroke="white" stroke-width="1.71001" stroke-linecap="round" stroke-linejoin="round"></path>
                </svg>-->
                <img :src="purchaseButtonIconUrl" height="24" width="25" />
                {{purchaseButtonText}}
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="account-action order-nef-electricity full-height-section" v-if="currentStep==='success'">
    <div class="container">
      <h2 class="action-title">{{successPage.Heading}}</h2>
      <div class="row">
        <div class="col-lg-4">
          <div class="order-complete-Bx">
            <img :src="successPage.SuccessIcon" />
            <h4 class="title">{{successPage.SuccessTitle}}</h4>
            <p v-html="successPage.SuccessDescription"></p>
          </div>
        </div>
      </div>
      <div class="multiple-buttons">
        <a :href="successPage.ButtonUrl" type="button" class="btn dark_blue_btn">
          {{successPage.ButtonText}}
        </a>
      </div>
      <template v-for="positionImage in successPage.PositionImages">
        <div :class="['position-image',positionImage.Position]">
          <img :src="positionImage.ImageUrl" alt="positionImage">
        </div>
      </template>
    </div>
  </section>
</template>
