import React, { useEffect, useState } from "react";
import { environment } from "../environment";
import { TopicList } from "./Topics/TopicList";
import { TopicPane } from "./TopicPane/TopicPane";
import Topic from "./Topics/Topic";
import axios from "axios";
import { Col, Row } from "reactstrap";
import FunFact from "./FunFact/FunFact";

export const Home = () => {
  const [selectedTopic, setSelectedTopic] = useState<Topic | null>(null);
  const [cards, setCards] = useState<Topic[]>([]);
  useEffect(() => {
    const fetchTopics = async () => {
      const res = await axios.get<Topic[]>(`${environment.apiUrl}/topic`);
      console.log(res.data);
      setCards(res.data);
    };
    fetchTopics();
  }, []);

  return (
    <Row>
      <Col xs={selectedTopic ? "6" : "12"}>
        <h2>Fun Facts</h2>
        <p>Here are some topics you may be interested in.</p>
        <TopicList
          selectedTopic={selectedTopic}
          setSelectedTopic={setSelectedTopic}
          topics={cards}
        ></TopicList>
      </Col>
      {selectedTopic && (
        <Col xs="6">
          <TopicPane
            selectedTopic={selectedTopic}
            setSelectedTopic={setSelectedTopic}
          ></TopicPane>
        </Col>
      )}
    </Row>
  );
};
