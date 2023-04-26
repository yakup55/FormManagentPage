import React from "react";
import { Button, Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

export default function NotFound() {
  const navigate = useNavigate();
  return (
    <>
      <Container>
        <h2>Aradığınız Sayfa Bulunamadı</h2>
        <Button onClick={() => navigate("/")}>Anasayfaya Dön</Button>
      </Container>
    </>
  );
}
