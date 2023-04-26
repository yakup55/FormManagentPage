import React from "react";
import Navbar from "./components/navbar/Navbar";
import Paths from "./Paths";

function App() {
  return (
    <>
      <div className={`App`}>
        <Navbar></Navbar>

        <main>
          <Paths></Paths>
        </main>
      </div>
    </>
  );
}

export default App;
