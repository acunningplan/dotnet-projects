import React from "react";
import { FunFactList } from "./FunFacts/FunFacts";

export const Home = () => {
  // static displayName = Home.name;

  return (
    <div>
      <h2>Fun Facts</h2>
      <p>Here are some topics you may be interested in.</p>

      <FunFactList></FunFactList>
    </div>
  );
};
