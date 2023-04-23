import FormService from "../services/formService";
export const GET_FORM_LIST = "GET_FORM_LIST";
export const GET_BY_FORM = "GET_BY_FORM";
export const ADD_FORM = "ADD_FORM";
export const UPDATE_FORM = "UPDATE_FORM";
export const DELETE_FORM = "DELETE_FORM";
export const USER_FORM = "USER_FORM";
export const SEARCH_FORM = "SEARCH_FORM";

const service = new FormService();

export function getFormList() {
  return function (dispacth) {
    service
      .getFormList()
      .then((resp) => dispacth({ type: GET_FORM_LIST, payload: resp }));
  };
}
export function addForm(form) {
  return function (dispacth) {
    service
      .addForm(form)
      .then((resp) => dispacth({ type: ADD_FORM, payload: resp }));
  };
}
export function getByForm() {
  return function (dispacth) {
    service
      .getByForm()
      .then((resp) => dispacth({ type: GET_BY_FORM, payload: resp }));
  };
}
export function deleteForm(id) {
  return function (dispacth) {
    service
      .deleteForm(id)
      .then((resp) => dispacth({ type: DELETE_FORM, payload: id }));
  };
}
export function userForm(userId) {
  return function (dispacth) {
    service
      .userForm(userId)
      .then((resp) => dispacth({ type: USER_FORM, payload: resp }));
  };
}
export function searchForm(search) {
  return function (dispacth) {
    service
      .searchForm(search)
      .then((resp) => dispacth({ type: SEARCH_FORM, payload: resp }));
  };
}
