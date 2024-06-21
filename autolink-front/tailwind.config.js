/** @type {import('tailwindcss').Config} */

const withMT = require("@material-tailwind/react/utils/withMT");

module.exports = withMT({
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        cerulean: {
          DEFAULT: '#437C90',
          dark: '#3c6f81',
          darker: '#356373',
          darkest: '#2e5664',
          light: '#55899b',
          lighter: '#6896a6',
          lightest: '#a1bdc7',
        },
        'dark-slate-gray': {
          DEFAULT: '#2F4F4F',
          dark: '#2C4747',
          darker: '#263D3D',
          darkest: '#203434',
          light: '#3B5959',
          lighter: '#466666',
          lightest: '#527373',
        },
        eggshell: {
          DEFAULT: '#F0EAD6',
          dark: '#D7D1C2',
          darker: '#BFB8AD',
          darkest: '#A7A096',
          light: '#F3EDD9',
          lighter: '#F5F0DD',
          lightest: '#F8F3E1',
        },
        darkred: {
          DEFAULT: '#8B0000',
          dark: '#7E0000',
          darker: '#710000',
          darkest: '#640000',
          light: '#960000',
          lighter: '#A10000',
          lightest: '#AC0000',
        },
        jasmine: {
          DEFAULT: '#F8DE7E',
          dark: '#EED56E',
          darker: '#E4CB5E',
          darkest: '#DAC24E',
          light: '#F9E08A',
          lighter: '#FAE296',
          lightest: '#FBE4A2',
        },
      },
    },
  },
  plugins: [],
});
