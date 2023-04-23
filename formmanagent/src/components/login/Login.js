import { useFormik } from "formik";
import React from "react";
import { Button } from "react-bootstrap";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import AuthenticationService from "../redux/services/authenticationService";
export default function Login() {
  const service = new AuthenticationService();
  const navigate = useNavigate();
  const dispacth = useDispatch();
  const { handleSubmit, handleChange, handleBlur } = useFormik({
    initialValues: {
      userName: "",
      password: "",
    },
    onSubmit: async (values) => {
      const result = await service.createToken(values);
      if (result.status === 200) {
        navigate(`/userform/${values.userName}`);
      }
      if (result.status === 400) {
        navigate("/register");
      }
    },
  });
  return (
    <div className="container">
      <form onSubmit={handleSubmit}>
        <div class="form-floating mb-3">
          <input
            required
            name="userName"
            onChange={handleChange}
            onBlur={handleBlur}
            type="name"
            class="form-control"
            id="floatingInput"
            placeholder="Kullanıcı Adınız"
          ></input>
          <label for="floatingInput">Kullanıcı Adınız</label>
        </div>
        <div class="form-floating">
          <input
            required
            name="password"
            onChange={handleChange}
            onBlur={handleBlur}
            type="password"
            class="form-control"
            id="floatingPassword"
            placeholder="Password"
          ></input>
          <label for="floatingPassword">Password</label>
        </div>
        <div class="form-floating">
          <Button type="submit">Login</Button>
        </div>
      </form>
    </div>
  );
}
