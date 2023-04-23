import { combineReducers } from "redux";
import formReducer from "../reducers/formReducer";
import userReducer from "./userReducer";
import authenticationReducer from "./authenticationReducer";
import {appReducer} from "./appReducer"
const rootReducer = combineReducers({
  form: formReducer,
  user: userReducer,
  auth: authenticationReducer,
  app: appReducer,
});

export default rootReducer;
