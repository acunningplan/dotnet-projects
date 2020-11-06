import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import registerServiceWorker from "./registerServiceWorker";

let baseUrlString = document.getElementsByTagName("base")[0].getAttribute("href");
let baseUrl: string | undefined;
if (baseUrlString === null) baseUrl = undefined;
else baseUrl = baseUrlString as string;

const rootElement = document.getElementById("root");

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>,
  rootElement
);

registerServiceWorker();
