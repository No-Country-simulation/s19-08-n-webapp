(() => {
  try {
    const theme = localStorage.getItem('theme');
    if (!theme || (theme !== 'light' && theme !== 'dark' && theme !== 'system')) {
      localStorage.setItem('theme', 'system');
      document.documentElement.setAttribute('data-theme', 'system');
      return;
    }
    document.documentElement.setAttribute('data-theme', theme);
  } catch (e) {
    console.log(e);
  }
})();
