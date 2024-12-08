import { createI18n } from 'vue-i18n';

import datetimeFormats from './rules/datetime';

export default createI18n({
  fallbackLocale: import.meta.env.VITE_FALLBACK_LOCALE,
  legacy: false,
  datetimeFormats,
});
