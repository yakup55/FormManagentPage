import React from "react";
import { useDispatch } from "react-redux";
import { searchForm } from "../redux/actions/formActions";

export default function Search() {
  const dispacth = useDispatch();
  const search = (form) => {
    dispacth(searchForm(form));
  };
  return (
    <div className="container">
      <div class="form-floating mb-3">
        <input
          name="form"
          class="form-control"
          placeholder="Form Ara"
          id="formDescription"
          onChange={(e) => search(e.target.value)}
          required
        ></input>
        <label for="floatingTextarea2Disabled">Form Ara</label>
      </div>
    </div>
  );
}
