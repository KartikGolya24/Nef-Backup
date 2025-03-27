
import { createApp } from 'vue/dist/vue.esm-bundler.js'
//import App from './App.vue'
import purchaseflow from './components/purchaseflow/purchase-flow.vue'

const app = createApp({})
app
  .component('purchase-flow',purchaseflow)
  //.directive('focus', {
  //  mounted(el) {
  //    el.focus()
  //  }
  //})

app.mount('#app');
