<script setup>
  import { onMounted } from 'vue'

  const emit = defineEmits(['change-tab'])

  const props = defineProps({
    langArea: {
      type: String,
      default: "purchaseLanguage"
    },
    pkg:Object,
    packages:Array
  })


  onMounted(() => {
  })

</script>



<template >
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
                  <img :src="usp.icon ? usp.icon : '/assets/img/icons/checkmark-purple.svg'" class="img-fluid" alt="icon svg" />
                  {{usp.name}}
                </p>

                <!--<span v-if="usp.infotext" data-bs-container="body" data-bs-toggle="popover" data-bs-placement="right" :data-bs-content="usp.infotext">
                  <img src="/assets/img/icons/info-popup.svg" class="img-fluid" alt="info-svg" />
                </span>-->
              </template>

            </li>
          </ul>
        </div>
      </div>
      <div class="package-footer">
        <div class="card-footer">

          <ul class="company-logo" v-if="pkg.prioritizedchannels && pkg.prioritizedchannels.length>0">

            <li v-for="prioritizedChannel in pkg.prioritizedchannels"><img :src="prioritizedChannel.logourl !=='' ? prioritizedChannel.logourl :'/assets/img/bg-img/company1.svg'" class="img-fluid" /></li>

          </ul>

          <div class="footer-btn">
            <a href="javascript:void(0)"
               class="btn dark_purple_btn" @click="emit('change-tab',pkg)">
              Bestil pakke
            </a>
            <a :href="'#seeAllPackages-'+pkg.id" data-bs-toggle="modal" class="package-link">Se hele pakkens indhold</a>
            <p v-if="pkg.disclaimer && pkg.disclaimer.trim()" class="text-two-line">
              {{pkg.disclaimer}}
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="modal fade"
       :id="'seeAllPackages-'+pkg.id"
       data-bs-keyboard="false"
       tabindex="-1"
       aria-labelledby="staticBackdropLabel"
       aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header flex-column align-items-start pb-0">
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          <h4 class="modal-title" id="staticBackdropLabel">{{pkg.name}}</h4>
        </div>
        <div class="modal-body">
          <div class="overflow-box">
            <p class="fw-600 black-950 price mb-32">{{pkg.priceMonthlyDKK}},- <span class="small">{{pkg.unit}}.</span></p>

            <h5 v-if="pkg.channels && pkg.channels.length>0" class="box-inner-title mb-24">Kanaler</h5>
            <div class="flex-bx brands-wrap">

              <div class="item" v-for="channel in pkg.channels">
                <img :src="channel.logourl" class="img-fluid" />
                <h6 class="item-title">{{channel.name}}</h6>
              </div>

            </div>


            <template v-if="pkg.streamingServies && pkg.streamingServies.length > 0">

              <hr class="line-splitter" />
              <h5 class="box-inner-title mb-24">Streamingtjenester</h5>

              <div class="flex-bx brands-wrap mx272px">

                <div class="item" v-for="service in pkg.StreamingServies">
                  <img :src="service.logourl" class="img-fluid" />
                  <h6 class="item-title">{{service.name}}</h6>
                </div>

              </div>

            </template>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
