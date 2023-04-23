import UserService from "../services/userService";
export const ADD_USER = "ADD_USER";
export const GET_BY_USER_MAIL = "GET_BY_USER_MAIL";
export const GET_BY_USER = "GET_BY_USER";

const service = new UserService();
export function addUser(user) {
  return function (dispacth) {
    service
      .addUser(user)
      .then((resp) => dispacth({ type: ADD_USER, payload: resp }));
  };
}
export function getByUser(id) {
  return function (dispacth) {
    service
      .getByUser(id)
      .then((resp) => dispacth({ type: GET_BY_USER, payload: resp }));
  };
}

export function getByUserMail(email) {
  return function (dispacth) {
    service
      .getByUserMail(email)
      .then((resp) => dispacth({ type: GET_BY_USER_MAIL, payload: resp }));
  };
}
