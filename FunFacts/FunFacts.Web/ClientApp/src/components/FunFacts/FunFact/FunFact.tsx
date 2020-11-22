import React from "react";
import { Card, CardText, CardTitle } from "reactstrap";
import { CustomCard } from "../FunFacts";

export const FunFact = (props: { card: CustomCard }) => {
  const card = props.card;
  return (
    <Card color="red">
      <CardTitle>{card.title}</CardTitle>
      <CardText>{card.content}</CardText>
    </Card>
  );
};
