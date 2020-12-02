import React from "react";
import ReactDOM from "react-dom";
import { MemoryRouter } from "react-router-dom";
import App from "./App";

describe("Simple tests", () => {
  it("renders without crashing", async () => {
    const div = document.createElement("div");
    ReactDOM.render(
      <MemoryRouter>
        <App />
      </MemoryRouter>,
      div
    );
    await new Promise((resolve) => setTimeout(resolve, 1000));
  });

  it("Should add correctly", () => {
    // Confused between jest and chai
    expect(1 + 2).toEqual(3);
  });
});
