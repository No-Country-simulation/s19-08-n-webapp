import i18n from '@/i18n';
import * as yup from 'yup';

yup.setLocale({
  mixed: {
    default: () => i18n.global.t('yup.mixed.default'),
    required: () => i18n.global.t('yup.mixed.required'),
    oneOf: ({ values }) => i18n.global.t('yup.mixed.oneOf', { values }),
    notOneOf: ({ values }) => i18n.global.t('yup.mixed.notOneOf', { values }),
    defined: () => i18n.global.t('yup.mixed.defined'),
    notNull: () => i18n.global.t('yup.mixed.notNull'),
    notType: ({ values: type }) => i18n.global.t('yup.mixed.notType', { type }),
  },
  string: {
    length: ({ length }) => i18n.global.t('yup.string.length', { length }),
    min: ({ min }) => i18n.global.t('yup.string.min', { min }),
    max: ({ max }) => i18n.global.t('yup.string.max', { max }),
    matches: ({ regex }) => i18n.global.t('yup.string.matches', { regex }),
    email: () => i18n.global.t('yup.string.email'),
    url: () => i18n.global.t('yup.string.url'),
    uuid: () => i18n.global.t('yup.string.uuid'),
    trim: () => i18n.global.t('yup.string.trim'),
    lowercase: () => i18n.global.t('yup.string.lowercase'),
    uppercase: () => i18n.global.t('yup.string.uppercase'),
  },
  number: {
    min: ({ min }) => i18n.global.t('yup.number.min', { min }),
    max: ({ max }) => i18n.global.t('yup.number.max', { max }),
    lessThan: ({ less }) => i18n.global.t('yup.number.lessThan', { less }),
    moreThan: ({ more }) => i18n.global.t('yup.number.moreThan', { more }),
    positive: () => i18n.global.t('yup.number.positive'),
    negative: () => i18n.global.t('yup.number.negative'),
    integer: () => i18n.global.t('yup.number.integer'),
  },
  date: {
    min: ({ min }) => i18n.global.t('yup.date.min', { min }),
    max: ({ max }) => i18n.global.t('yup.date.max', { max }),
  },
  array: {
    min: ({ min }) => i18n.global.t('yup.array.min', { min }),
    max: ({ max }) => i18n.global.t('yup.array.max', { max }),
    length: ({ length }) => i18n.global.t('yup.array.length', { length }),
  },
  boolean: {
    isValue: ({ value }) => i18n.global.t('yup.boolean.isValue', { value }),
  },
  object: {
    noUnknown: ({ unknown }) => i18n.global.t('yup.object.noUnknown', { unknown }),
  },
});
