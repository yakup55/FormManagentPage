import AuthenticationService from "../services/authenticationService";
export const CREATE_TOKEN = "CREATE_TOKEN";
const service = new AuthenticationService();
export function createToken(user) {
  return function (dispacth) {
    service
      .createToken(user)
      .then((resp) => dispacth({ type: CREATE_TOKEN, payload: resp }));
  };
}
