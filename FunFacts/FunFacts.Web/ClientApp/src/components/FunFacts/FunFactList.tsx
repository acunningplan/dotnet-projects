import axios from "axios";
import React, { useEffect } from "react";
import { Col, Row } from "reactstrap";
import { FunFactCard } from "./FunFact/FunFactCard";
import { environment } from "../../environment";
import { FunFact } from "./FunFact";
import Topic from "../Topic/Topic";

export class LoginResponse {
  bio = "";
  username = "";
  displayName = "Guest";
  lastLogin = "";
  funFacts: FunFact[] = [];
  token = "";
  refreshToken = "";
}

interface FunFactListProps {
  funFacts: FunFact[];
}

export const FunFactList: React.FC<FunFactListProps> = ({ funFacts }) => {
  useEffect(() => {}, []);

  const cards: Topic[] = [
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
    {
      title: "This is fourth title",
      content: "Some card content.",
    },
  ];

  const rowLength = 3;
  const numOfRows = (cards.length + 2) / rowLength;
  let groupsOfCards: Topic[][] = [];

  // Divide the cards into groups of 3 (or whatever rowLength is)
  for (let i = 0; i < numOfRows; i++) {
    let groupOfCards: Topic[] = [];
    for (let j = 0; j < rowLength; j++) {
      if (3 * i + j < cards.length) {
        groupOfCards.push(cards[3 * i + j]);
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
              <FunFactCard card={card}></FunFactCard>
            </Col>
          ))}
        </Row>
      ))}
    </>
  );
};
