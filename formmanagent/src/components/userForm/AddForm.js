import { useFormik } from "formik";
import React, { useEffect } from "react";
import { Button } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { getByUserMail } from "../redux/actions/userActions";
import { addForm } from "../redux/actions/formActions";

export default function AddForm() {
  const navigate = useNavigate();
  const dispacth = useDispatch();
  const { username } = useParams();
  const { user } = useSelector((state) => state.user);
  const id = user.data?.id;
  const { handleSubmit, handleChange, handleBlur, values } = useFormik({
    initialValues: {
      formName: "",
      formDescription: "",
      userId: user.data?.id,
    },
    onSubmit: (values) => {
      dispacth(addForm(values));
    },
  });
  console.log(values);
  console.log(id);
  useEffect(() => {
    dispacth(getByUserMail(username));
  }, [dispacth, username]);
  return (
    <div class="form-floating mb-3">
      <h2>Form Ekle</h2>
      <div className="container">
        <form onSubmit={handleSubmit}>
          <div class="form-floating mb-3">
            <input
              onChange={handleChange}
              onBlur={handleBlur}
              name="formName"
              class="form-control"
              placeholder="Form Name"
              id="formName"
              required
            ></input>
            <label for="floatingTextarea2Disabled">Form Name</label>
          </div>
          <div class="form-floating mb-3">
            <input
              onChange={handleChange}
              onBlur={handleBlur}
              name="formDescription"
              class="form-control"
              placeholder="Form Description"
              id="formDescription"
              required
            ></input>
            <label for="floatingTextarea2Disabled">Form Description</label>
          </div>
          <Button type="submit">Form Ekle</Button>
        </form>
      </div>
    </div>
  );
}
