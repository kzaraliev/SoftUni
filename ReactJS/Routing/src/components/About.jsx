import { Link, Routes, Route } from "react-router-dom";

import AboutUs from "./AboutUs";
import Mission from "./Mission";
import OurValues from "./OurValues";

export default function About() {
  return (
    <>
      <h2>About Page</h2>
      <nav>
        <Link to="us">About Us</Link>
        <Link to="mission">Mission</Link>
        <Link to="values">Our Values</Link>
      </nav>

      <Routes>
        <Route path="/us" element={<AboutUs />} />
        <Route path="/mission" element={<Mission />} />
        <Route path="/values" element={<OurValues />} />
      </Routes>
    </>
  );
}
