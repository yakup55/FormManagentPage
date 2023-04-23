import React from "react";
import { Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import Home from "../home/Home";

export default function Navbar() {
  const navigate = useNavigate();
  return (
    <div>
      <nav class="navbar bg-body-tertiary">
        <div class="container-fluid">
          <span  class="navbar-brand mb-0 h1">
            Navbar
          </span>
          <h4
            onClick={() => navigate("/formlist")}
            class="navbar-brand mb-0 h1"
          >
            Formlar
          </h4>
          <Button
            onClick={() => navigate("/register")}
            style={{ marginLeft: 1050, textDecoration: "none" }}
          >
            Register
          </Button>
          <Button
            onClick={() => navigate("/login")}
            style={{ marginRight: 2, textDecoration: "none" }}
          >
            Login
          </Button>
        </div>
      </nav>
    </div>
  );
}
