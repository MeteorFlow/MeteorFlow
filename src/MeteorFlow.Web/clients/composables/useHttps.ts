import type { UseFetchOptions } from "nuxt/app";

export function useHttps<T>(
  url: string | (() => string),
  options: Omit<UseFetchOptions<T>, "default"> & { default: () => T | Ref<T> }
) {
  return useFetch(url, {
    ...options,
    $fetch: useNuxtApp().$https,
  });
}
