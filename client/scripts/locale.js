(() => {
  try {
    const storedLocale = localStorage.getItem('locale');
    const supportedLocales = import.meta.env.VITE_SUPPORTED_LOCALES.split(',');
    if (!storedLocale || !supportedLocales.includes(storedLocale)) {
      const preferredLocale = window.navigator.language.split('-')[0];
      if (supportedLocales.includes(preferredLocale)) {
        localStorage.setItem('locale', preferredLocale);
        document.querySelector('html').setAttribute('lang', preferredLocale);
        return;
      }
      const defaultLocale = import.meta.env.VITE_DEFAULT_LOCALE;
      localStorage.setItem('locale', defaultLocale);
      document.querySelector('html').setAttribute('lang', defaultLocale);
      return;
    }
    document.querySelector('html').setAttribute('lang', storedLocale);
  } catch (e) {
    console.log(e);
  }
})();
