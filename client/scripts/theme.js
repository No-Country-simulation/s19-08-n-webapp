(() => {
  try {
    const isDarkMode = window.matchMedia('(prefers-color-scheme: dark)').matches;
    const theme = localStorage.getItem('theme');
    if (!theme || (theme !== 'dark' && theme !== 'light') || theme === 'system')
      return document.documentElement.setAttribute('data-theme', isDarkMode ? 'dark' : 'light');
    document.documentElement.setAttribute('data-theme', theme);
  } catch (e) {
    console.log(e);
  }
})();
