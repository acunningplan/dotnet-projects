import React from "react";
import Topic from "../Topics/Topic";
import { FunFactList } from "./FunFactList/FunFactList";

export const TopicPane = (props: {
  selectedTopic: Topic | null;
  setSelectedTopic: Function;
}) => {
  const topic = props.selectedTopic;
  return (
    <>
      {topic && (
        <>
          <p onClick={() => props.setSelectedTopic(null)}>X</p>
          <h3>{topic.name}</h3>
          {topic.pictures.map((p, key) => (
            <img
              key={key}
              src={p.url}
              alt={p.description}
              height="100"
              className="mr-3 mb-3"
            ></img>
          ))}
          <FunFactList funFacts={topic.funFacts}></FunFactList>
        </>
      )}
    </>
  );
};
