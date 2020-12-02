import React from "react";
import { Col, Row } from "reactstrap";
import { TopicCard } from "./Topic/TopicCard";
import Topic from "./Topic";

export const TopicList = (props: {
  topics: Topic[];
  selectedTopic: Topic | null;
  setSelectedTopic: Function;
}) => {
  const topics = props.topics;
  const rowLength = props.selectedTopic ? 2 : 3;
  const numOfRows = (topics.length + 2) / rowLength;
  let groupsOfCards: Topic[][] = [];

  // Divide the cards into groups of 3 (or whatever rowLength is)
  for (let i = 0; i < numOfRows; i++) {
    let groupOfCards: Topic[] = [];
    for (let j = 0; j < rowLength; j++) {
      if (rowLength * i + j < topics.length) {
        groupOfCards.push(topics[rowLength * i + j]);
      }
    }
    groupsOfCards.push(groupOfCards);
  }

  return (
    <>
      {groupsOfCards.map((group, key) => (
        <Row key={key}>
          {group.map((card, cardKey) => (
            <Col xs={12 / rowLength} key={cardKey}>
              <TopicCard
                card={card}
                setSelectedTopic={props.setSelectedTopic}
              ></TopicCard>
            </Col>
          ))}
        </Row>
      ))}
    </>
  );
};
