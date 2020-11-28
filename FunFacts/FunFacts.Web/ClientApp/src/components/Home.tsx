import React, { useEffect, useState } from "react";
import { environment } from "../environment";
import { TopicList } from "./Topics/TopicList";
import Topic from "./Topics/Topic";
import axios from "axios";

export const Home = () => {
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
    <div>
      <h2>Fun Facts</h2>
      <p>Here are some topics you may be interested in.</p>

      <TopicList topics={cards}></TopicList>
    </div>
  );
};
