import {
  ADD_FORM,
  DELETE_FORM,
  GET_BY_FORM,
  GET_FORM_LIST,
  SEARCH_FORM,
  UPDATE_FORM,
  USER_FORM,
} from "../actions/formActions";
import { form, forms } from "../initials/formInitials";
const initialValues = {
  form,
  forms,
};

export default function formReducer(state = initialValues, { type, payload }) {
  switch (type) {
    case GET_FORM_LIST:
      return {
        ...state,
        forms: payload,
      };
    case ADD_FORM:
      return {
        ...state,
        forms: [...forms, payload],
      };
    case GET_BY_FORM:
      return {
        ...state,
        form: payload,
      };
    case DELETE_FORM:
      return {
        ...state,
        forms: [...state.forms.filter((x) => x.formId !== payload)],
      };
    case UPDATE_FORM:
      return {
        ...state,
        forms: [
          ...state.forms.filter((x) => x.formId !== payload.formId),
          payload,
        ],
      };
    case USER_FORM:
      return {
        ...state,
        forms: payload,
      };
    case SEARCH_FORM:
      return {
        ...state,
        forms: payload,
      };
    default:
      return {
        ...state,
      };
  }
}
