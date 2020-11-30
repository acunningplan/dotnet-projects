import React from "react";
import Topic from "../Topics/Topic";
import { FunFactList } from "./FunFactList/FunFactList";

export const TopicPane = (props: {
  selectedTopic: Topic | null;
  setSelectedTopic: Function;
}) => {
  return (
    <>
      {props.selectedTopic && (
        <>
          <p onClick={() => props.setSelectedTopic(null)}>X</p>
          <h3>{Topic.name}</h3>
          <p>Topic pictures go here</p>
          <FunFactList funFacts={props.selectedTopic.funFacts}></FunFactList>
        </>
      )}
    </>
  );
};
