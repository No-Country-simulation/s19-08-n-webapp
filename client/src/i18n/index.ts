import { createI18n } from 'vue-i18n';

import en from './locales/en.json';
import es from './locales/es.json';
import datetimeFormats from './rules/datetime';

export default createI18n({
  locale: 'es',
  fallbackLocale: import.meta.env.VITE_FALLBACK_LOCALE,
  legacy: false,
  messages: {
    en,
    es,
  },
  datetimeFormats,
});
