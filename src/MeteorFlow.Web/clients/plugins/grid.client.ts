import { defineNuxtPlugin } from '#app'
// @ts-ignore
import VueGridLayout from 'vue-grid-layout'


export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.use(VueGridLayout)
})