import React from "react";
import { Card, CardText, CardTitle } from "reactstrap";
import Topic from "../Topic";
import "./TopicCard.css";

export const TopicCard = (props: { card: Topic, setSelectedTopic: Function }) => {
  const { card } = props;
  return (
    <Card 
    onClick={() => props.setSelectedTopic(card)}>
      <div className="topic-card">
        <CardTitle>
          <h5>{card.name}</h5>
        </CardTitle>
        <CardText>{card.introduction}</CardText>
      </div>
    </Card>
  );
};
