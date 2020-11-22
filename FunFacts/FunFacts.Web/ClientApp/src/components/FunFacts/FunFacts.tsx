import React from "react";
import { Button, Card, CardText, CardTitle, Col, Row } from "reactstrap";
import { FunFact } from "./FunFact/FunFact";

export interface CustomCard {
  title: string;
  content: string;
}

export const FunFacts = () => {
  const cards: CustomCard[] = [
    {
      title: "This is a title",
      content: "Some card content.",
    },
    {
      title: "This is second title",
      content: "Some card content.",
    },
    {
      title: "This is third title",
      content: "Some card content.",
    },
  ];

  return (
    <>
      <Row>
        {cards.map((card, key) => (
          <Col key={key}>
            <FunFact card={card}></FunFact>
          </Col>
        ))}
      </Row>
    </>
  );
};
