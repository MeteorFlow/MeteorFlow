import { useUserSession } from "~/composables/useUserSession"

export default defineNuxtPlugin(() => {
  const { token } = useUserSession()
  const { public: config } = useRuntimeConfig()

  const https = $fetch.create({
    baseURL: `${config.apiUrl}`,
    onRequest({ request, options, error }) {
      if (token.value) {
        const headers = options.headers ||= {}
        if (Array.isArray(headers)) {
          headers.push(['Authorization', `Bearer ${token.value}`])
        } else if (headers instanceof Headers) {
          headers.set('Authorization', `Bearer ${token.value}`)
        } else {
          headers.Authorization = `Bearer ${token.value}`
        }
      }
    },
    async onResponseError({ response }) {
      if (response.status === 401) {
        await navigateTo('/login')
      }
    }
  })

  // Expose to useNuxtApp().$api
  return {
    provide: {
      https: https
    }
  }
})
