import { CREATE_TOKEN } from "../actions/authenticationActions";
import { auth, auths } from "../initials/authenticationInitials";
const initialValues = {
  auth,
  auths,
};

export default function authenticationReducer(
  state = initialValues,
  { type, payload }
) {
  switch (type) {
    case CREATE_TOKEN:
      return {
        auth: {
          ...payload,
        },
      };
    default:
      return {
        ...state,
      };
  }
}
