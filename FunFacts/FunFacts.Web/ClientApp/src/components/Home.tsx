import React from "react";
import { FunFact } from "./FunFacts/FunFact";
import { FunFactList } from "./FunFacts/FunFactList";

export const Home = () => {
  // static displayName = Home.name;
  let funFacts: FunFact[] = [];

  return (
    <div>
      <h2>Fun Facts</h2>
      <p>Here are some topics you may be interested in.</p>

      <FunFactList funFacts={funFacts}></FunFactList>
    </div>
  );
};
