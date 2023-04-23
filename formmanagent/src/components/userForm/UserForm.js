import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { deleteForm, userForm } from "../redux/actions/formActions";
import { getByUserMail } from "../redux/actions/userActions";
import AddForm from "./AddForm";
import { Button } from "react-bootstrap";
import Search from "../search/Search";

export default function UserForm() {
  const { username } = useParams();
  const dispacth = useDispatch();
  const navigate = useNavigate();
  const { user } = useSelector((state) => state.user);
  const { forms } = useSelector((state) => state.form);
  const formDeleted = (id) => {
    dispacth(deleteForm(id));
  };
  useEffect(() => {
    dispacth(getByUserMail(username));
    dispacth(userForm(user.data?.id));
  }, [dispacth, username, user.data?.id]);
  return (
    <div>
      <h2>Formlarım</h2>
     <Search></Search>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Form Adı</th>
            <th scope="col">Form Açıklama</th>
            <th scope="col">Form Tarihi</th>
            <th scope="col">Kullanıcı</th>
            <th scope="col">Sil</th>
          </tr>
        </thead>
        <tbody>
          {forms.data?.map((form) => (
            <tr>
              <th scope="row">{form.formId}</th>
              <td>{form.formName}</td>
              <td>{form.formDescription}</td>
              <td>{form.formCreateAt.substring(0, 10)}</td>
              <td>
                {user.data?.firstName}-{user.data?.lastName}
              </td>
              <td>
                <Button onClick={() => formDeleted(form.formId)}>Sil</Button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <AddForm></AddForm>
    </div>
  );
}
