import { ref, computed } from 'vue';
import type { User } from '~/models/User';
import {jwtDecode} from 'jwt-decode';

const token = ref<string | null>(null);
const user = ref<User | null>(null);

export function useUserSession() {
  const setSession = (jwtToken: string, userInfo: User) => {
    token.value = jwtToken;
    user.value = userInfo;
    if (process.browser) {
      localStorage.setItem('authToken', jwtToken);
      localStorage.setItem('user', JSON.stringify(userInfo));
    }
  };

  const clearSession = () => {
    token.value = null;
    user.value = null;
    if (process.browser) {
      localStorage.removeItem('authToken');
      localStorage.removeItem('user');
    }
  };

  const loadSession = () => {
    if (!process.browser) return;
    const storedToken = localStorage.getItem('authToken');
    const storedUser = localStorage.getItem('user');
    if (storedToken && storedUser) {
      token.value = storedToken;
      user.value = JSON.parse(storedUser);
    }
  };

  const isTokenValid = () => {
    if (!token.value) return false;
    try {
      const decodedToken = jwtDecode<{ exp: number }>(token.value);
      return decodedToken.exp * 1000 > Date.now();
    } catch (e) {
      return false;
    }
  };

  loadSession();

  return {
    token: computed(() => token.value),
    user: computed(() => user.value),
    setSession,
    clearSession,
    isTokenValid
  };
}
