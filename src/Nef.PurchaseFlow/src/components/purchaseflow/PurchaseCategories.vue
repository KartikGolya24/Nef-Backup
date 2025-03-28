<script setup>
  import {ref,onMounted } from 'vue'

  const emit = defineEmits(['change-tab'])

  const props = defineProps({
    langArea: {
      type: String,
      default: "purchaseLanguage"
    },
    categoriesHeading: {
      type: String
    },
    categories: {
      type: Object
    }
  })

  //Data
  var selectedCategory = ref(props.categories[0])

  //Methods
  function backToPrevious() {
    emit('change-tab', 'lookup');
  }
  function orderPackage() {
    emit('change-tab', 'form', selectedCategory);
  }

  onMounted(() => {
    window.scrollTo(0,0)
  })
</script>

<template>
  <div class="account-action order-nef-tv">
    <!-- Watching Options -->
    <section class="tv-watching-options">
      <div class="container">
        <h2 class="section-title">{{categoriesHeading}}</h2>
        <div class="ordering-card-box-outer">
          <div class="row">
            <div class="col-lg-4 col-md-6 mb-32" v-for="category in categories">
              <div :class="['ordering-card', selectedCategory.CategoryName===category.CategoryName?'light_purple_bg border_dark_purple':'border_black-100']" @click="selectedCategory=category">
                <div class="card-head">
                  <div class="form-check radio-purple">
                    <input class="form-check-input" type="radio" name="orderTVOption" id="orderTVOption" :value="category" v-model="selectedCategory">
                  </div>
                </div>
                <div class="card-content">
                  <img :src="category.IconUrl" />
                  <h4 class="card-title fw-600 my-24">{{category.CategoryName}}</h4>
                  <p class="para">{{category.Description}}</p>
                  <div class="tv-box-cost black-bg-100 mt-32" v-if="category.TvCostText">{{category.TvCostText}}</div>
                </div>
              </div>
            </div>

            <div class="col-lg-12">
              <div class="multiple-buttons">
                <button type="button" class="btn white_bg_btn" @click="backToPrevious">
                  Tilbage
                </button>
                <a href="javascript:void(0)" type="button" :class="['btn', 'dark_purple_btn', selectedCategory == undefined ?'disabled': '']" @click="orderPackage">
                  <svg xmlns="http://www.w3.org/2000/svg" width="25" height="24" viewBox="0 0 25 24" fill="none">
                    <path d="M22.0503 3.24316H2.94451C2.50485 3.24316 2.14844 3.59958 2.14844 4.03924V15.9804C2.14844 16.42 2.50485 16.7764 2.94451 16.7764H22.0503C22.4899 16.7764 22.8464 16.42 22.8464 15.9804V4.03924C22.8464 3.59958 22.4899 3.24316 22.0503 3.24316Z" stroke="white" stroke-width="1.71001" stroke-linecap="round" stroke-linejoin="round" />
                    <path d="M10.9066 16.7769L9.31445 20.7572" stroke="white" stroke-width="1.71001" stroke-linecap="round" stroke-linejoin="round" />
                    <path d="M14.0898 16.7769L15.682 20.7572" stroke="white" stroke-width="1.71001" stroke-linecap="round" stroke-linejoin="round" />
                    <path d="M7.7207 20.7568H17.2736" stroke="white" stroke-width="1.71001" stroke-linecap="round" stroke-linejoin="round" />
                  </svg>
                  Bestil TV
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>
