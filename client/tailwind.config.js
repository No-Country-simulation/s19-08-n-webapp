/* eslint-disable @typescript-eslint/no-require-imports */
/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{js,ts,jsx,tsx,vue}'],
  theme: {
    extend: {},
  },
  daisyui: {
    themes: [
      {
        light: {
          ...require('daisyui/src/theming/themes')['light'],
          primary: '#2196F3',
          secondary: '#FF8600',
          accent: '#7209B7',
          info: '#9BF6FF',
          success: '#70E000',
          error: '#FF1B1C',
        },
        dark: {
          ...require('daisyui/src/theming/themes')['dark'],
          primary: '#2196F3',
          secondary: '#FF8600',
          accent: '#7209B7',
          info: '#9BF6FF',
          success: '#70E000',
          error: '#FF1B1C',
        },
      },
    ],
  },
  plugins: [require('daisyui')],
};
