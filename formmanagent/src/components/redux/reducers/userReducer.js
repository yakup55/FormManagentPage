import {
  ADD_USER,
  GET_BY_USER,
  GET_BY_USER_MAIL,
} from "../actions/userActions";
import { user, users } from "../initials/userInitials";
const initialValues = {
  user,
  users,
};
export default function userReducer(state = initialValues, { type, payload }) {
  switch (type) {
    case ADD_USER:
      return {
        ...state,
        users: [...state.users, payload],
      };
    case GET_BY_USER:
      return {
        ...state,
        user: payload,
      };
    case GET_BY_USER_MAIL:
      return {
        ...state,
        user: payload,
      };
    default:
      return {
        ...state,
      };
  }
}
