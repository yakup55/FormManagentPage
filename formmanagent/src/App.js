import React from "react";
import Navbar from "./components/navbar/Navbar";
import Paths from "./Paths";
import Home from "./components/home/Home";
import SimpleSnacbar from "./components/snacbar/SimpleSnacbar";

function App() {
  return (
    <>
      <div className={`App`}>
        <Navbar></Navbar>

        <main>
          <Paths></Paths>
        </main>
      </div>
      <Home></Home>
      {/* <SimpleSnacbar></SimpleSnacbar> */}
    </>
  );
}

export default App;
