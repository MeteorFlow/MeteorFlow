import type { Config } from "tailwindcss";

export default <Partial<Config>>{
  theme: {
    extend: {
      colors: {
        lightgreen: {
          50: "#f2fbf8",
          100: "#d2f5e9",
          200: "#a5ead4",
          300: "#71d7bb",
          400: "#43bea0",
          500: "#2aa388",
          600: "#1f826e",
          700: "#1d6859",
          800: "#1b544a",
          900: "#1b463e",
          950: "#0a2925",
        },
      },
    },
  },
};
