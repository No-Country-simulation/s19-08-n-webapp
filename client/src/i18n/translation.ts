import i18n from '@/i18n';
import { nextTick } from 'vue';

const Translation = {
  get supportedLocales(): string[] {
    return import.meta.env.VITE_SUPPORTED_LOCALES.split(',');
  },

  get currentLocale(): string {
    return i18n.global.locale.value;
  },

  set currentLocale(locale: string) {
    i18n.global.locale.value = locale;
  },

  async switchLanguage(locale: string): Promise<void> {
    await Translation.loadLocaleMessages(locale);
    Translation.currentLocale = locale;
    document.querySelector('html')?.setAttribute('lang', locale);
    localStorage.setItem('locale', locale);
  },

  async loadLocaleMessages(locale: string): Promise<void> {
    if (!i18n.global.availableLocales.includes(locale)) {
      const messages = await import(`@/i18n/locales/${locale}.json`);
      i18n.global.setLocaleMessage(locale, messages.default);
    }

    return nextTick();
  },
};

export default Translation;
