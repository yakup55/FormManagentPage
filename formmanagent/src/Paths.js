import React from "react";
import { Route, Routes } from "react-router-dom";
import Login from "./components/login/Login";
import Register from "./components/register/Register";
import UserForm from "./components/userForm/UserForm";
import FormList from "./components/home/FormList";
import NotFound from "./components/page/NotFound";

export default function Paths() {
  return (
    <Routes>
      <Route path="/" element={<FormList></FormList>}></Route>
      <Route path="/login" element={<Login></Login>}></Route>
      <Route path="/register" element={<Register></Register>}></Route>
      <Route path="/userform/:username" element={<UserForm></UserForm>}></Route>
      <Route path="*" element={<NotFound></NotFound>}></Route>
    </Routes>
  );
}
