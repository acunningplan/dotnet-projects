import React from "react";
import FunFact from "../../FunFact/FunFact";
import { ListGroup, ListGroupItem } from "reactstrap";

export const FunFactList = (props: { funFacts: FunFact[] }) => {
  const funFacts = props.funFacts;
  return (
    <>
      <ListGroup>
        {funFacts.map((funFact, key) => (
          <ListGroupItem key={key}>{funFact.description}</ListGroupItem>
        ))}
      </ListGroup>
    </>
  );
};
