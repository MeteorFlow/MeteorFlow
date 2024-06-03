import { useUserSession } from '~/composables/useUserSession';

export default defineNuxtRouteMiddleware((to, from) => {
  const { isTokenValid, clearSession } = useUserSession();
  console.log(to.path, isTokenValid())

  if (to.path !== '/' && !isTokenValid()) {
    clearSession();
    return navigateTo('/login');
  }
});
