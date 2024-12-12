import i18n from '@/i18n';
import * as Yup from 'yup';

export const loginFormSchema = Yup.object({
  username: Yup.string().trim().required(),
  password: Yup.string().trim().required(),
});

export const registerFormSchema = Yup.object({
  firstName: Yup.string().trim().min(3).max(25).required(),
  lastName: Yup.string().trim().min(3).max(25).required(),
  username: Yup.string().trim().min(3).max(15).required(),
  email: Yup.string().email().required(),
  password: Yup.string()
    .trim()
    .min(6)
    .max(50)
    .matches(/[0-9]/, i18n.global.t('auth.register.form.custom_validations.password.req_number'))
    .matches(
      /[a-z]/,
      i18n.global.t('auth.register.form.custom_validations.password.req_lower_case'),
    )
    .matches(
      /[A-Z]/,
      i18n.global.t('auth.register.form.custom_validations.password.req_upper_case'),
    )
    .matches(/[^\w]/, i18n.global.t('auth.register.form.custom_validations.password.req_symbol'))
    .required(),
  confirmPassword: Yup.string()
    .trim()
    .oneOf(
      [Yup.ref('password')],
      i18n.global.t('auth.register.form.custom_validations.confirm_password'),
    )
    .required(),
});
