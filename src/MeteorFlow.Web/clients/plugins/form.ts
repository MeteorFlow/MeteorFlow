import { defineNuxtPlugin } from '#app'
import { useFormStore } from '~/stores/useFormStore'

export default defineNuxtPlugin(async (nuxtApp) => {
  const forms = useFormStore();

  await forms.actions.loadForms()
})