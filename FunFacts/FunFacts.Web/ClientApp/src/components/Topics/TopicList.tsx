import React from "react";
import { Col, Row } from "reactstrap";
import { TopicCard } from "./Topic/TopicCard";
import Topic from "./Topic";


export const TopicList = (props: { topics: Topic[] }) => {
  const topics = props.topics;
  const rowLength = 3;
  const numOfRows = (topics.length + 2) / rowLength;
  let groupsOfCards: Topic[][] = [];

  // Divide the cards into groups of 3 (or whatever rowLength is)
  for (let i = 0; i < numOfRows; i++) {
    let groupOfCards: Topic[] = [];
    for (let j = 0; j < rowLength; j++) {
      if (3 * i + j < topics.length) {
        groupOfCards.push(topics[3 * i + j]);
      }
    }
    groupsOfCards.push(groupOfCards);
  }

  return (
    <>
      {groupsOfCards.map((group, key) => (
        <Row key={key}>
          {group.map((card, cardKey) => (
            <Col xs={rowLength} key={cardKey}>
              <TopicCard card={card}></TopicCard>
            </Col>
          ))}
        </Row>
      ))}
    </>
  );
};
