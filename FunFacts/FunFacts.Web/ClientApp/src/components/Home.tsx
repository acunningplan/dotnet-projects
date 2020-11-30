import React, { useEffect, useState } from "react";
import { environment } from "../environment";
import { TopicList } from "./Topics/TopicList";
import { TopicPane } from "./TopicPane/TopicPane";
import Topic from "./Topics/Topic";
import axios from "axios";
import { Col, Row } from "reactstrap";

export const Home = () => {
  const [selectedTopic, setSelectedTopic] = useState<Topic | null>(null);
  const [cards, setCards] = useState<Topic[]>([]);
  const components = [TopicPane, TopicList];

  useEffect(() => {
    const fetchTopics = async () => {
      const res = await axios.get<Topic[]>(`${environment.apiUrl}/topic`);
      console.log(res.data);
      setCards(res.data);
    };
    fetchTopics();
  }, []);

  return (
    <Row className="flex-md-row-reverse">
      {components.map((Component) => (
        <Col xs="12" md={selectedTopic ? "6" : "12"} className="mb-3">
          <Component
            selectedTopic={selectedTopic}
            setSelectedTopic={setSelectedTopic}
            topics={cards}
          ></Component>
        </Col>
      ))}
    </Row>
  );
};
