import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getFormList } from "../redux/actions/formActions";
import Search from "../search/Search";

export default function FormList() {
  const { forms } = useSelector((state) => state.form);
  
  const dispacth = useDispatch();
  useEffect(() => {
    dispacth(getFormList());
  }, [dispacth]);
  return (
    <div>
      <h2>Tüm Formlar</h2>
      <Search></Search>

      <table class="table">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Form Adı</th>
            <th scope="col">Form Açıklama</th>
            <th scope="col">Form Tarihi</th>
            <th scope="col">Kullanıcı</th>
          </tr>
        </thead>
        <tbody>
          {forms.data?.map((form) => (
            <tr>
              <th scope="row">{form.formId}</th>
              <td>{form.formName}</td>
              <td>{form.formDescription}</td>
              <td>{form.formCreateAt?.substring(0, 10)}</td>
              <td>{form.userId}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
