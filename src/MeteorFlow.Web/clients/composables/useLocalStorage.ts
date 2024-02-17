
export default function useLocalStorage<T>(key: string, initialValue: T) {
  const state = useState<T>(() => {
    const storedItem = localStorage.getItem(key);
    return storedItem ? JSON.parse(storedItem) : initialValue;
  });

  // Watch for changes in storedValue and update localStorage
  watch(() => state.value, (value) => {
    localStorage.setItem(key, JSON.stringify(value));
  });

  // Function to remove the item from localStorage and reset storedValue
  const removeFromStorage = () => {
    localStorage.removeItem(key);
    state.value = initialValue;
  };

  return { state, removeFromStorage };
}

