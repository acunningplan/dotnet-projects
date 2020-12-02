import React from "react";
import { Card, CardText, CardTitle } from "reactstrap";
import Topic from "../Topic";
import "./TopicCard.css";

export const TopicCard = (props: {
  card: Topic;
  setSelectedTopic: Function;
}) => {
  const { card } = props;
  const mainImage = props.card.pictures.find((p) => p.isMain);
  return (
    <Card onClick={() => props.setSelectedTopic(card)}>
      <div className="topic-card">
        <CardTitle>
          <h5>{card.name}</h5>
        </CardTitle>
        {mainImage && (
          <img
            src={mainImage.url}
            alt={mainImage.description}
            className="topic-card-image"
          ></img>
        )}
        <CardText>{card.introduction}</CardText>
      </div>
    </Card>
  );
};
