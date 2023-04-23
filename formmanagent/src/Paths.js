import React from "react";
import { Route, Routes } from "react-router-dom";
import Login from "./components/login/Login";
import Register from "./components/register/Register";
import Home from "./components/home/Home";
import UserForm from "./components/userForm/UserForm";
import FormList from "./components/home/FormList";

export default function Paths() {
  return (
    <Routes>
      <Route path="/formlist" element={<FormList></FormList>}></Route>
      <Route path="/login" element={<Login></Login>}></Route>
      <Route path="/register" element={<Register></Register>}></Route>
      <Route path="/userform/:username" element={<UserForm></UserForm>}></Route>
    </Routes>
  );
}
