import i18n from '@/i18n';
import { nextTick } from 'vue';
import type {
  NavigationGuardNext,
  RouteLocationNormalizedGeneric,
  RouteLocationNormalizedLoadedGeneric,
} from 'vue-router';

const Translation = {
  get defaultLocale(): string {
    return import.meta.env.VITE_DEFAULT_LOCALE;
  },

  get supportedLocales(): string[] {
    return import.meta.env.VITE_SUPPORTED_LOCALES.split(',');
  },

  get currentLocale(): string {
    return i18n.global.locale.value;
  },

  set currentLocale(newLocale: string) {
    i18n.global.locale.value = newLocale;
  },

  async switchLanguage(newLocale: string): Promise<void> {
    await Translation.loadLocaleMessages(newLocale);
    Translation.currentLocale = newLocale;
    document.querySelector('html')?.setAttribute('lang', newLocale);
    localStorage.setItem('user-locale', newLocale);
  },

  async loadLocaleMessages(locale: string): Promise<void> {
    if (!i18n.global.availableLocales.includes(locale)) {
      const messages = await import(`@/i18n/locales/${locale}.json`);
      i18n.global.setLocaleMessage(locale, messages.default);
    }

    return nextTick();
  },

  isLocaleSupported(locale: string): boolean {
    return Translation.supportedLocales.includes(locale);
  },

  getUserLocale() {
    const locale = window.navigator.language || Translation.defaultLocale;

    return {
      locale: locale,
      localeNoRegion: locale.split('-')[0],
    };
  },

  getPersistedLocale(): string | null {
    const persistedLocale = localStorage.getItem('user-locale') ?? '';

    if (Translation.isLocaleSupported(persistedLocale)) {
      return persistedLocale;
    } else {
      return null;
    }
  },

  guessDefaultLocale(): string {
    const userPersistedLocale = Translation.getPersistedLocale();
    if (userPersistedLocale) {
      return userPersistedLocale;
    }

    const userPreferredLocale = Translation.getUserLocale();

    if (Translation.isLocaleSupported(userPreferredLocale.locale)) {
      return userPreferredLocale.locale;
    }

    if (Translation.isLocaleSupported(userPreferredLocale.localeNoRegion)) {
      return userPreferredLocale.localeNoRegion;
    }

    return Translation.defaultLocale;
  },

  async routeMiddleware(
    to: RouteLocationNormalizedGeneric,
    from: RouteLocationNormalizedLoadedGeneric,
    next: NavigationGuardNext,
  ): Promise<void> {
    const paramLocale = to.params.locale as string;

    if (!Translation.isLocaleSupported(paramLocale)) {
      return next(Translation.guessDefaultLocale());
    }

    await Translation.switchLanguage(paramLocale);

    return next();
  },

  i18nRoute(to: RouteLocationNormalizedGeneric): RouteLocationNormalizedGeneric {
    return {
      ...to,
      params: {
        locale: Translation.currentLocale,
        ...to.params,
      },
    };
  },
};

export default Translation;
