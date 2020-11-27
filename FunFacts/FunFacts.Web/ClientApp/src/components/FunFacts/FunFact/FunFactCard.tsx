import React from "react";
import { Card, CardText, CardTitle } from "reactstrap";
import { Topic } from "../FunFactList";

export const FunFactCard = (props: { card: Topic }) => {
  const { card } = props;
  return (
    <Card color="red">
      <CardTitle>{card.title}</CardTitle>
      <CardText>{card.content}</CardText>
    </Card>
  );
};
