import { useFormik } from "formik";
import React from "react";
import { Button } from "react-bootstrap";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { addUser } from "../redux/actions/userActions";
import { validationSchema } from "./validationSchema";
export default function Register() {
  const navigate = useNavigate();
  const dispacth = useDispatch();

  const { handleSubmit, handleChange, handleBlur, errors, touched } = useFormik(
    {
      initialValues: {
        firstName: "",
        userName: "",
        lastName: "",
        age: 0,
        password: "",
        email: "",
      },
      onSubmit: (values) => {
        dispacth(addUser(values));
        navigate(`/userform/${values.userName}`);
      },
      validationSchema,
    }
  );
  return (
    <div className="container">
      <form onSubmit={handleSubmit}>
        <div class="form-floating mb-3"></div>
        <div class="form-floating mb-3">
          <input
            required
            name="email"
            id="email"
            onChange={handleChange}
            onBlur={handleBlur}
            class="form-control"
            placeholder="Email Adres"
            error={errors.userName && touched.userName}
            helperText={
              errors.userName && touched.userName ? errors.userName : ""
            }
          ></input>
          <label for="floatingTextarea2Disabled">Email Adres</label>
        </div>
        <div class="form-floating mb-3">
          <input
            name="firstName"
            onChange={handleChange}
            onBlur={handleBlur}
            error={errors.firstName && touched.firstName}
            helperText={
              errors.firstName && touched.firstName ? errors.firstName : ""
            }
            class="form-control"
            placeholder="First Name"
            id="firstName"
            required
          ></input>
          <label for="floatingTextareaDisabled">First Name</label>
        </div>
        <div class="form-floating mb-3">
          <input
            required
            name="lastName"
            onChange={handleChange}
            onBlur={handleBlur}
            class="form-control"
            placeholder="Last Name"
            id="lastName"
            error={errors.lastName && touched.lastName}
            helperText={
              errors.lastName && touched.lastName ? errors.lastName : ""
            }
          ></input>
          <label for="floatingTextarea2Disabled">Last Name</label>
        </div>
        <div class="form-floating mb-3">
          <input
            required
            name="userName"
            id="userName"
            onChange={handleChange}
            onBlur={handleBlur}
            class="form-control"
            placeholder="User Name"
            error={errors.userName && touched.userName}
            helperText={
              errors.userName && touched.userName ? errors.userName : ""
            }
          ></input>
          <label for="floatingTextarea2Disabled">User Name</label>
        </div>
        <div class="form-floating mb-3">
          <input
            required
            name="age"
            onChange={handleChange}
            onBlur={handleBlur}
            class="form-control"
            placeholder="User Name"
            id="age"
            error={errors.age && touched.age}
            helperText={errors.age && touched.age ? errors.age : ""}
          ></input>
          <label for="floatingTextarea2Disabled">Yaşınız</label>
        </div>
        <div class="form-floating mb-3">
          <input
            required
            name="password"
            id="password"
            onChange={handleChange}
            onBlur={handleBlur}
            class="form-control"
            placeholder="Password"
            error={errors.password && touched.password}
            helperText={
              errors.password && touched.password ? errors.password : ""
            }
          ></input>
          <label for="floatingTextarea2Disabled">Password</label>
        </div>
        <div class="form-floating mb-3">
          <Button type="submit">Create</Button>
        </div>
      </form>
    </div>
  );
}
