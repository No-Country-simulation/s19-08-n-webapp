import type { DateTimeFormat } from '@intlify/core-base';

const datetimeFormats: Record<string, DateTimeFormat> = {
  en: {
    short: {
      dateStyle: 'short',
    },
    long: {
      year: 'numeric',
      month: 'short',
      day: 'numeric',
      weekday: 'short',
      hour: 'numeric',
      minute: 'numeric',
    },
  },
  es: {
    short: {
      dateStyle: 'short',
    },
    long: {
      year: 'numeric',
      month: 'short',
      day: 'numeric',
      weekday: 'short',
      hour: 'numeric',
      minute: 'numeric',
    },
  },
};

export default datetimeFormats;
