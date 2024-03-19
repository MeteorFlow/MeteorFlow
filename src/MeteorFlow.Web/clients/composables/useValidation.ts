import type { ValidateFunction, Validation } from "~/models";

const createRules = () => {
  return {
    required: () => async (value?: string) => !!value || 'This field is required.',
    email: () => async (value?: string) => {
      if (!value) return true
      const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return pattern.test(value) || 'Invalid e-mail.'
    },
    min: (min: number) => async (value?: string) => !value || (value.length >= min) || `Min. ${min} characters`,
    max: (max: number) => async (value?: string) => !value || (value.length <= max) || `Max. ${max} characters`,
    number: () => async (value?: string) => !isNaN(Number(value)) || 'Must be a number',
    url: () => async (value?: string) => {
      if (!value) return true
      const pattern = /[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)?/gi;
      return pattern.test(value) || 'Invalid URL.'
    },
    date: () => async (value?: string) => {
      if (!value) return true
      const pattern = /^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$/;
      return pattern.test(value) || 'Invalid date.'
    },
    time: () => async (value?: string) => {
      if (!value) return true
      const pattern = /^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/;
      return pattern.test(value) || 'Invalid time.'
    },
    password: () => async (value?: string) => {
      if (!value) return true
      // Password should be longer than 8 characters
      if (value.length < 8) return 'Password should be longer than 8 characters.'
      // Password must contain at least one number 
      if (!/\d/.test(value)) return 'Password must contain at least one number.'
      // Password must contain at least one uppercase and lowercase letter
      if (!/[a-z]/.test(value) || !/[A-Z]/.test(value)) return 'Password must contain at least one uppercase and lowercase letter.'
      // Password must contain at least 1 special character
      if (!/[!@#$%^&*(),.?":{}|<>]/.test(value)) return 'Password must contain at least 1 special character.'
      return true
    }
  }
}

export const useValidation = () => {
const id = `validation-${useId()}`;
  const validators = useState(id, () => ([] as ValidateFunction[]))

  const apply = (validation: ValidateFunction) => validators.value = [...new Set([...validators.value, validation])]

  const validate = async (value?: string) => {
    const results = await Promise.all(validators.value.map(v => v(value)));
    return results.find(r => typeof r === 'string') || true
  }
  const hasErrors = async (value?: string) => {
    const valid = await validate(value)
    return typeof valid === 'string' ? valid : false;
  }

  return {
    apply,
    validate,
    createRules,
    hasErrors
  }
}