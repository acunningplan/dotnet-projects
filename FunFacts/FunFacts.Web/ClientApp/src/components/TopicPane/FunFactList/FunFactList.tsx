import React from "react";
import FunFact from "../../FunFact/FunFact";
import { ListGroup, ListGroupItem } from "reactstrap";
import { FunFactItem } from "./FunFactItem/FunFactItem";

export const FunFactList = (props: { funFacts: FunFact[] }) => {
  const funFacts = props.funFacts;
  return (
    <>
      <ListGroup>
        {funFacts.map((funFact, key) => (
          <ListGroupItem  key={key}>
            <FunFactItem funFact={funFact}></FunFactItem>
          </ListGroupItem>
        ))}
      </ListGroup>
    </>
  );
};
