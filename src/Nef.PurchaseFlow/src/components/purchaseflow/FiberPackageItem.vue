<script setup>
  import { onMounted } from 'vue'

  const emit = defineEmits(['change-tab'])

  const props = defineProps({
    langArea: {
      type: String,
      default: "purchaseLanguage"
    },
    pkg: Object,
    packages: Array
  })


  onMounted(() => {
  })
</script>



<template>
  <div :class="'col-xl-'+ (packages.length == 1 || packages.length == 2 ? '5':packages.length==3 ? '4' : '3')+ ' col-md-6 mb-32'">
    <div class="package-card">
      <div class="card-detail">
        <div class="card-header">
          <div class="card-heading">

            <h4 v-if="pkg.name !==''"> {{pkg.name}} </h4>

            <p v-if="pkg.description !==''"> {{pkg.description}} </p>

          </div>
          <div class="price">

            <h3>{{pkg.priceprefix}} {{pkg.priceMonthlyDKK}} Kr.</h3>

            <p>{{pkg.unit}}</p>

          </div>
        </div>
        <div class="card-body">
          <ul>
            <li v-for="(usp, index) in pkg.usps" :key="index">
              <template v-if="usp.name && usp.name.trim()">

                <p>
                  <img :src="usp.icon ? usp.icon : '/assets/img/icons/checkmark-green.svg'" class="img-fluid" alt="icon svg" />
                  {{usp.name}}
                </p>

                <span v-if="usp.infotext" data-bs-container="body" data-bs-toggle="popover" data-bs-placement="right" :data-bs-content="usp.infotext">
                  <img src="/assets/img/icons/info-popup.svg" class="img-fluid" alt="info-svg" />
                </span>
              </template>

            </li>
          </ul>
        </div>
      </div>
      <div class="package-footer">
        <div class="card-footer">
          <div class="footer-btn">
            <a href="javascript:void(0)"
               class="btn dark_blue_btn" @click="emit('change-tab',pkg)">
              Bestil Fiber
            </a>
            <a v-if="pkg.learnMore && pkg.learnMore.trim()" :href="'#readMorePopup-'+pkg.id" data-bs-toggle="modal" class="package-link">Læs mere</a>
            <p class="text-two-line">
              {{pkg.disclaimer}}
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div v-if="pkg.learnMore && pkg.learnMore.trim()" class="modal fade"
       :id="'readMorePopup-'+pkg.id"
       data-bs-keyboard="false"
       tabindex="-1"
       aria-labelledby="staticBackdropLabel"
       aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">

        <div class="modal-header flex-column align-items-start pb-0">
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          <h4 class="modal-title" id="staticBackdropLabel">{{pkg.name}}</h4>

          <p class="fw-600 black-950 price mb-32">{{pkg.priceMonthlyDKK}},- <span class="small">{{pkg.unit}}</span></p>
        </div>
        <div class="modal-body">
          <p>{{pkg.learnMore}}</p>
        </div>

      </div>
    </div>
  </div>
</template>
