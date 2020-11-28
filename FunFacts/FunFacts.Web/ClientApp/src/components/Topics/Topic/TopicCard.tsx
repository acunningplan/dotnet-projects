import React from "react";
import { Card, CardText, CardTitle } from "reactstrap";
import Topic from "../Topic";
import "./TopicCard.css";

export const TopicCard = (props: { card: Topic }) => {
  const { card } = props;
  return (
    <Card>
      <div className="topic-card">
        <CardTitle>
          <h5>{card.name}</h5>
        </CardTitle>
        <CardText>{card.introduction}</CardText>
      </div>
    </Card>
  );
};
